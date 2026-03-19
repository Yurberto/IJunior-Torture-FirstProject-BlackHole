using System;
using UnityEngine; //убрать

namespace Assets.Scripts.Game.LevelSystem
{
    public class LevelStarter
    {
        private LevelResultTracker _resultTracker;

        public LevelStarter(LevelResultTracker resultTracker)
        {
            if (resultTracker == null)
                throw new ArgumentNullException(nameof(resultTracker));

            _resultTracker = resultTracker;
        }

        public void Start(Level currentLevel)
        {
            _resultTracker.StartTracking(currentLevel.Config.Time, currentLevel.Config.ObjectsCount);
            _resultTracker.ResultTracked += OnResultTracked;
        }

        private void OnResultTracked(bool isComplete)
        {
            _resultTracker.ResultTracked -= OnResultTracked;

            Debug.Log("OnResultTRacked_LevelStarter");
        }
    }
}
