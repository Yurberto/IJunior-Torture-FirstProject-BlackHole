using System;

namespace Assets.Scripts.Game.Time
{
    public class LevelTimer
    {
        private const int MaxTime = 99;

        private TimerService _timerService;

        public LevelTimer(TimerService timerService)
        {
            if (timerService == null)
                throw new ArgumentNullException(nameof(timerService));

            _timerService = timerService;
        }

        public event Action HasOver;

        public void StartTimer(int time)
        {
            if (_timerService == null)
                throw new ArgumentNullException(nameof(_timerService));
            if (time <= 0 || time > MaxTime)
                throw new ArgumentOutOfRangeException(nameof(time));

            _timerService.Start(time);
            _timerService.Completed += StopTicking;
        }

        private void StopTicking()
        {
            _timerService.Stop();
            _timerService.Completed -= StopTicking;

            HasOver?.Invoke();
        }
    }
}
