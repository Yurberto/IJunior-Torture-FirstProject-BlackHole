using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    [Header("Settings")]
    [SerializeField, Range(1, 5000)] private float _radius = 5;
    [SerializeField, Range(0.5f, 4)] private float _onPressScale = 1.5f;

    [SerializeField] private Color _normalColor = new Color(1, 1, 1, 1);
    [SerializeField] private Color _pressColor = new Color(1, 1, 1, 1);

    [SerializeField, Range(0.1f, 5)] private float _duration = 1;

    [Header("Reference")]
    [SerializeField] private RectTransform _stick;
    [SerializeField] private RectTransform _center;

    [SerializeField] private Image _backImage;
    [SerializeField] private Image _stickImage;

    private int _lastId = -2;

    private Vector3 _pressScaleVector;
    private Coroutine _scaleCoroutine;

    public float Horizontal
    {
        get
        {
            return (_stick.position.x - _center.position.x) / _radius;
        }
    }

    public float Vertical
    {
        get
        {
            return (_stick.position.y - _center.position.y) / _radius;
        }
    }

    private void Start()
    {
        _pressScaleVector = new Vector3(_onPressScale, _onPressScale, _onPressScale);

        _backImage.CrossFadeColor(_normalColor, _duration, true, true);
        _stickImage.CrossFadeColor(_normalColor, _duration, true, true);
    }

    private void OnDisable()
    {
        BackToCenter();
    }

    /// <param name="data"></param>
    public void OnPointerDown(PointerEventData data)
    {
        if (_lastId == -2)
        {
            _lastId = data.pointerId;

            if (_scaleCoroutine != null)
                StopCoroutine(_scaleCoroutine);

            _scaleCoroutine = StartCoroutine(ScaleJoysctick(true));

            OnDrag(data);

            _backImage.CrossFadeColor(_pressColor, _duration, true, true);
            _stickImage.CrossFadeColor(_pressColor, _duration, true, true);
        }
    }

    public void OnDrag(PointerEventData data)
    {
        if (data.pointerId == _lastId)
        {
            Vector3 touchPosition = JoystickUtils.GetTouchPosition(GetTouchID());
            Vector3 direction = touchPosition - _center.position;

            if (direction.sqrMagnitude < Mathf.Pow(_radius, 2))
            {
                _stick.position = touchPosition;
            }
            else
            {
                _stick.position = _center.position + direction.normalized * _radius;
            }
        }
    }

    /// <param name="data"></param>
    public void OnPointerUp(PointerEventData data)
    {
        if (data.pointerId == _lastId)
        {
            _lastId = -2;

            if (_scaleCoroutine != null)
                StopCoroutine(_scaleCoroutine);

            _scaleCoroutine = StartCoroutine(ScaleJoysctick(false));
            BackToCenter();

            _backImage.CrossFadeColor(_normalColor, _duration, true, true);
            _stickImage.CrossFadeColor(_normalColor, _duration, true, true);
        }
    }

    private void BackToCenter()
    {
        _stick.position = _center.position;
    }

    private IEnumerator ScaleJoysctick(bool isIncrease)
    {
        float _time = 0;

        while (_time < _duration)
        {
            Vector3 stickScale = _stick.localScale;
            Vector3 targetScale = isIncrease ? _pressScaleVector : Vector3.one;

            stickScale = Vector3.Lerp(_stick.localScale, targetScale, (_time / _duration));

            _stick.localScale = stickScale;
            _time += Time.deltaTime;

            yield return null;
        }
    }

    private int GetTouchID()
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