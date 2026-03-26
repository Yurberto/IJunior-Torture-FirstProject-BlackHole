using Assets.Scripts.Game.LevelSystem.ScriptableObjects;
using Assets.Scripts.Game.Time;
using System;

namespace Assets.Scripts.Game.LevelSystem
{
    public class LevelStarter
    {
        private CanvasSwitcher _canvasSwitcher;
        private LevelConfigsHub _levelConfigsHub;

        private LevelTimer _timer;
        private LevelResultTracker _resultTracker;

        public LevelStarter(CanvasSwitcher canvasSwitcher, LevelConfigsHub levelConfigsHub, LevelTimer timer)
        {
            if (canvasSwitcher == null)
                throw new ArgumentNullException(nameof(canvasSwitcher));
            if (levelConfigsHub == null)
                throw new ArgumentException(nameof(levelConfigsHub));
            if (timer == null)
                throw new ArgumentNullException(nameof(timer));

            _canvasSwitcher = canvasSwitcher;
            _levelConfigsHub = levelConfigsHub;
            _timer = timer;
        }

        public void Start()
        {
            _canvasSwitcher.OpenLevel();

            LevelConfig currentLevelConfig = _levelConfigsHub.GetCurrent();

            _timer.StartTimer(currentLevelConfig.Time);
            _resultTracker.Track(currentLevelConfig.ObjectsCount);
        }
    }
}
