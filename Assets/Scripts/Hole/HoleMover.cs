using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace Assets.Scripts.Hole
{
    public class HoleMover : MonoBehaviour
    {
        [SerializeField] private Transform _transfrom;
        [SerializeField] private bl_Joystick _joystick;

        [SerializeField] private float _speed;

        private MoverService _moverService;

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

        private async UniTaskVoid MoveAsync()
        {
            while (_cancellationTokenSource.IsCancellationRequested == false)
            {
                float horizontal = _joystick.Horizontal;
                float vertical = _joystick.Vertical;

                if ((Mathf.Approximately(horizontal, 0) && Mathf.Approximately(vertical, 0)) == false)
                    _moverService.MoveOnSurface(new Vector3(_joystick.Horizontal, 0, _joystick.Vertical), _speed * Time.deltaTime);

                await UniTask.NextFrame(_cancellationTokenSource.Token);
            }
        }
    }
}
