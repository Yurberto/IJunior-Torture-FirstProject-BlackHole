using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace Assets.Scripts.Hole
{
    public class HoleMover : MonoBehaviour
    {
        [SerializeField] private Transform _transfrom;
        [SerializeField] private Joystick _joystick;

        [SerializeField, Min(0)] private float _maxSpeed = 0.17f;
        [SerializeField, Min(0)] private float _acceleration = 6;
        [SerializeField, Min(0)] private float _deceleration = 3;

        private MoverService _moverService;

        private Vector3 _currentVelocity;

        private CancellationTokenSource _cancellationTokenSource;

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
            _currentVelocity = Vector3.zero;
        }

        private async UniTaskVoid MoveAsync()
        {
            while (_cancellationTokenSource != null &&
                       !_cancellationTokenSource.IsCancellationRequested)
            {
                await UniTask.NextFrame(_cancellationTokenSource.Token);

                float horizontal = _joystick.Horizontal;
                float vertical = _joystick.Vertical;

                Vector3 inputDirection = new Vector3(horizontal, 0, vertical);
                bool hasInput = inputDirection.sqrMagnitude > 0.001f;

                Vector3 targetVelocity = hasInput ? inputDirection.normalized * _maxSpeed : Vector3.zero;
                float accelerationRate = hasInput ? _acceleration : _deceleration;

                _currentVelocity = Vector3.Lerp(_currentVelocity, targetVelocity, accelerationRate * Time.deltaTime);

                _moverService.MoveOnSurface(_currentVelocity, 1f);
            }
        }
    }
}
