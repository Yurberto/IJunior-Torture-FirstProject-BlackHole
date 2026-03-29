using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Time
{
    public class TimerService
    {
        private int _time;
        private CancellationTokenSource _cancellationTokenSource;

        public event Action<int> Started;
        public event Action Finished;

        public event Action<int> Tick;

        public void Start(int time)
        {
            if (time <= 0)
                throw new ArgumentOutOfRangeException(nameof(time));

            if (_cancellationTokenSource != null)
                Stop();

            _time = time;

            _cancellationTokenSource = new CancellationTokenSource();

            Started?.Invoke(_time);
            StartAsync(_cancellationTokenSource.Token).Forget();
        }

        public void Stop()
        {
            if (_cancellationTokenSource == null)
                return;

            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = null;
        }

        private async UniTaskVoid StartAsync(CancellationToken token)
        {
            while (_time > 0)
            {
                Tick?.Invoke(_time);

                await UniTask.Delay(1000, cancellationToken: token);

                --_time;
            }

            if (token.IsCancellationRequested == false)
                Finished?.Invoke();
        }
    }
}