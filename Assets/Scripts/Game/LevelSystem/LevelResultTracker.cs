using Assets.Scripts.Game.LevelSystem;
using Assets.Scripts.Game.Time;
using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Assets.Scripts.Game.LevelSystem
{
    public class LevelResultTracker
    {
        private LevelAbsorbCounter _absorbCounter;
        private LevelTimer _timer;

        private CancellationTokenSource _cancellationTokenSource;

        public LevelResultTracker(LevelAbsorbCounter levelAbsorbCounter, LevelTimer timer)
        {
            if (levelAbsorbCounter == null) 
                throw new ArgumentNullException(nameof(levelAbsorbCounter));
            if (timer == null)
                throw new ArgumentNullException(nameof(timer)); 

            _absorbCounter = levelAbsorbCounter;
            _timer = timer;
        }

        public event Action<bool> ResultTracked;

        public void StartTracking(int time, int reachedAbsorptions)
        {
            if (time <= 0)
                throw new ArgumentOutOfRangeException(nameof(time));
            if (reachedAbsorptions <= 0)
                throw new ArgumentOutOfRangeException(nameof(reachedAbsorptions));

            _timer.StartTimer(time);
            _timer.HasOver += OnLose;

            TrackAbsorptions(reachedAbsorptions).Forget();
        }

        private async UniTaskVoid TrackAbsorptions(int reachedAbsorptions)
        {
            while (reachedAbsorptions > _absorbCounter.CurrentAbsorptions && _cancellationTokenSource.Token.IsCancellationRequested == false)
            {
                await UniTask.DelayFrame(1, PlayerLoopTiming.Update);
            }

            ResultTracked?.Invoke(true);
            CancelToken();
        }

        private void OnLose()
        {
            ResultTracked?.Invoke(false);
            _timer.HasOver -= OnLose;

            CancelToken();
        }

        private void CancelToken()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }
    }
}
