using System;

namespace Assets.Scripts.Game.Time
{
    public class LevelTimer
    {
        private TimerService _timerService;

        public LevelTimer(TimerService timerService)
        {
            if (timerService == null)
                throw new ArgumentNullException(nameof(timerService));

            _timerService = timerService;
        }

        public event Action HasOver;

        public void Start(int time)
        {
            if (_timerService == null)
                throw new ArgumentNullException(nameof(_timerService));
            if (time <= 0)
                throw new ArgumentOutOfRangeException(nameof(time));

            _timerService.Start(time);
            _timerService.Finished += OnFinished;
        }

        public void Stop()
        {
            _timerService.Stop();
        }

        private void OnFinished()
        {
            _timerService.Finished -= OnFinished;

            HasOver?.Invoke();
        }
    }
}
