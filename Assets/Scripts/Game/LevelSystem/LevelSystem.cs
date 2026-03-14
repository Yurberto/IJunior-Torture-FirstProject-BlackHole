using Assets.Scripts.Game.Time;
using System;
using UnityEngine;

namespace Assets.Scripts.Game.LevelGamplay
{
    public class LevelSystem : MonoBehaviour
    {
        private LevelActivator _levelActivator;
        private LevelResultTracker _resultTracker;

        private LevelTimer _timer;

        public void Init(LevelActivator levelActivator, LevelResultTracker levelResultTracker)
        { 
            if (levelActivator == null)
                throw new ArgumentNullException(nameof(levelActivator));
            if (levelResultTracker == null)
                throw new ArgumentNullException(nameof(levelResultTracker));
 
            _levelActivator = levelActivator;
            _resultTracker = levelResultTracker;

            _timer.Init();
        }

        public event Action<bool> LevelFinished;

        public void StartLevel()
        {
            _levelActivator.Activate();
            _timer.StartTimer(99);

            _resultTracker.Start(_timer);
            _resultTracker.ResultDetermined += StopLevel;
        }

        public void StopLevel(bool isLevelComplete)
        {
            _resultTracker.ResultDetermined -= StopLevel;

            _levelActivator.Deactivate();
            LevelFinished?.Invoke(isLevelComplete);
        }
    }
}
