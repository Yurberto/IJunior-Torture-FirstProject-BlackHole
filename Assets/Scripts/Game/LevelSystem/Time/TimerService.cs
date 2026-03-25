using System;
using System.Threading;
using Cysharp.Threading.Tasks;


namespace Assets.Scripts.Game.Time
{
    public class TimerService
    {
        private int _time;

        private CancellationTokenSource _cancellationTokenSource;

        public event Action<int> Started;
        public event Action Completed;
        public event Action<int> Tick;

        public int CurrentTime => _time;

        public void Start(int time)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            StartAsync(time).Forget();
            Started?.Invoke(time);
        }

        public void Stop()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }

        private async UniTaskVoid StartAsync(int time)
        {
            _time = time;

            while (_time > 0)
            {
                await UniTask.Delay(1000, _cancellationTokenSource.IsCancellationRequested);

                _time--;
                Tick?.Invoke(_time);
            }

            Completed?.Invoke();
        }
    }
}
