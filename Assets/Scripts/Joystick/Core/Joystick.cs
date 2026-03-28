using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    [Header("Settings")]
    [SerializeField, Range(1, 50)] private float _ratio = 5;
    [SerializeField, Range(0.01f, 1)] private float _smoothTime = 0.5f;
    [SerializeField, Range(0.5f, 4)] private float _onPressScale = 1.5f;

    [SerializeField] private Color _normalColor = new Color(1, 1, 1, 1);
    [SerializeField] private Color _pressColor = new Color(1, 1, 1, 1);

    [SerializeField, Range(0.1f, 5)] private float _duration = 1;

    [Header("Reference")]
    [SerializeField] private RectTransform _stickRect;
    [SerializeField] private RectTransform _centerRect;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Image _backImage;
    [SerializeField] private Image _stickImage;

    private Vector3 _deathArea;
    private Vector3 _currentVelocity;
    private bool _isFree = false;
    private int _lastId = -2;

    private float _diff;

    private Vector3 _pressScaleVector;

    private void Start()
    {
        _deathArea = _centerRect.position;
        _diff = _deathArea.magnitude;
        _pressScaleVector = new Vector3(_onPressScale, _onPressScale, _onPressScale);

        _backImage.CrossFadeColor(_normalColor, 0.1f, true, true);
        _stickImage.CrossFadeColor(_normalColor, 0.1f, true, true);
    }

    private void Update()
    {
        _deathArea = _centerRect.position;

        if (_isFree == false)
            return;

        _stickRect.position = Vector3.SmoothDamp(_stickRect.position, _deathArea, ref _currentVelocity, smoothTime);

        if (Vector3.Distance(_stickRect.position, _deathArea) < .1f)
        {
            _isFree = false;
            _stickRect.position = _deathArea;
        }
    }

    /// <param name="data"></param>
    public void OnPointerDown(PointerEventData data)
    {
        if (_lastId == -2)
        {
            _lastId = data.pointerId;
            StopAllCoroutines();
            StartCoroutine(ScaleJoysctick(true));
            OnDrag(data);
            if (_backImage != null)
            {
                _backImage.CrossFadeColor(_pressColor, _duration, true, true);
                _stickImage.CrossFadeColor(_pressColor, _duration, true, true);
            }
        }
    }

    /// <param name="data"></param>
    public void OnDrag(PointerEventData data)
    {
        if (data.pointerId == _lastId)
        {
            _isFree = false;

            Vector3 position = bl_JoystickUtils.TouchPosition(_canvas, GetTouchID);

            if (Vector2.Distance(_deathArea, position) < ratio)
            {
                _stickRect.position = position;
            }
            else
            {
                _stickRect.position = _deathArea + (position - _deathArea).normalized * ratio;
            }
        }
    }

    /// <param name="data"></param>
    public void OnPointerUp(PointerEventData data)
    {
        _isFree = true;
        _currentVelocity = Vector3.zero;

        if (data.pointerId == _lastId)
        {
            _lastId = -2;
            StopAllCoroutines();
            StartCoroutine(ScaleJoysctick(false));
            if (_backImage != null)
            {
                _backImage.CrossFadeColor(_normalColor, _duration, true, true);
                _stickImage.CrossFadeColor(_normalColor, _duration, true, true);
            }
        }
    }

    IEnumerator ScaleJoysctick(bool isIncrease)
    {
        float _time = 0;

        while (_time < _duration)
        {
            Vector3 stickScale = _stickRect.localScale;
            Vector3 targetScale = isIncrease ? _pressScaleVector : Vector3.one;

            stickScale = Vector3.Lerp(_stickRect.localScale, targetScale, (_time / _duration));

            _stickRect.localScale = stickScale;
            _time += Time.deltaTime;
            yield return null;
        }
    }

    public int GetTouchID
    {
        get
        {
            for (int i = 0; i < Input.touches.Length; i++)
            {
                if (Input.touches[i].fingerId == _lastId)
                {
                    return i;
                }
            }
            return -1;
        }
    }

    private float ratio { get { return (_ratio * 5 + Mathf.Abs((_diff - _centerRect.position.magnitude))); } }
    private float smoothTime { get { return (1 - (_smoothTime)); } }

    public float Horizontal
    {
        get
        {
            return (_stickRect.position.x - _deathArea.x) / _ratio;
        }
    }

    public float Vertical
    {
        get
        {
            return (_stickRect.position.y - _deathArea.y) / _ratio;
        }
    }
}