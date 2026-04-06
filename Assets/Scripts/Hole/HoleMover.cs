using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using Assets.Scripts.Hole.Scale;
using System;

namespace Assets.Scripts.Hole
{
    public class HoleMover : MonoBehaviour
    {
        [SerializeField] private Transform _transfrom;
        [SerializeField] private Joystick _joystick;

        [SerializeField, Min(0)] private float _speed = 0.17f;

        private float _sizeFactor = 1;

        private MoverService _moverService;
        private HoleScalerView _scalerView;

        private CancellationTokenSource _cancellationTokenSource;

        public void Init(HoleScalerView scalerView)
        {
            if (scalerView == null) 
                throw new ArgumentNullException(nameof(scalerView));

            _scalerView = scalerView;

            _scalerView.SizeUpdated += UpdateSizeFactor;
        }

        public void Dispose()
        {
            _scalerView.SizeUpdated -= UpdateSizeFactor;
        }

        private void Start()
        {
            _moverService = new MoverService(_transfrom);
        }

        public void StartMoving()
        {
            if (_cancellationTokenSource != null)
                StopMoving();

            _cancellationTokenSource = new CancellationTokenSource();

            MoveAsync().Forget();
        }

        public void StopMoving()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }

        public void BackToStartPosition()
        {
            _transfrom.position = new Vector3(0f, 0f, 0f);
        }

        private void UpdateSizeFactor(float size)
        {
            _sizeFactor = size;
        }

        private async UniTaskVoid MoveAsync()
        {
            while (_cancellationTokenSource.IsCancellationRequested == false)
            {
                await UniTask.NextFrame(_cancellationTokenSource.Token);

                float horizontal = _joystick.Horizontal;
                float vertical = _joystick.Vertical;

                Vector3 inputDirection = new Vector3(horizontal, 0, vertical);
                bool hasInput = inputDirection.sqrMagnitude > 0.0001f;

                Vector3 velocity = hasInput ? inputDirection * _speed * _sizeFactor * Time.deltaTime : Vector3.zero;

                _moverService.MoveOnSurface(velocity, 1f);
            }
        }
    }
}
