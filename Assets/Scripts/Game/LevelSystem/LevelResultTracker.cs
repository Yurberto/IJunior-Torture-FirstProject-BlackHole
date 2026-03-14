using Assets.Scripts.Game.Time;
using System;

namespace Assets.Scripts.Game.LevelGamplay
{
    public class LevelResultTracker
    {
        private LevelAbsorbCounter _absorbCounter;
        private Level _currentLevel;

        private LevelTimer _currentTimer;

        public LevelResultTracker(LevelAbsorbCounter absorbCounter)
        {
            if (absorbCounter == null)
                throw new ArgumentNullException(nameof(absorbCounter));

            _absorbCounter = absorbCounter;
        }

        public event Action<bool> ResultDetermined;

        public void Start(LevelTimer levelTimer)
        {
            _currentTimer = levelTimer;

            _absorbCounter.AbsorbtionAdded += OnAbsorptionAdded;
            _currentTimer.IsOver += OnTimerIsOver;
        }

        private void OnAbsorptionAdded(int absorptionCount)
        {
            bool isLevelComplete = _currentLevel.Config.ObjectsCount <= absorptionCount;

            Stop(isLevelComplete);
        }

        private void OnTimerIsOver()
        {
            _currentTimer.IsOver -= OnTimerIsOver;

            Stop(false);
        }

        private void Stop(bool isLevelComplete)
        {
            _absorbCounter.AbsorbtionAdded -= OnAbsorptionAdded;

            ResultDetermined?.Invoke(isLevelComplete);
        }
    }
}
