using Assets.Scripts.Game.LevelSystem.ScriptableObjects;
using Assets.Scripts.Game.Time;
using Assets.Scripts.Hole;
using System;
using UnityEngine; // удалить

namespace Assets.Scripts.Game.LevelSystem
{
    public class LevelStarter
    {
        private CanvasSwitcher _canvasSwitcher;
        private LevelConfigsHub _levelConfigsHub;

        private LevelTimer _timer;
        private LevelResultTracker _resultTracker;
        private LevelFinisher _finisher;

        private HoleMover _holeMover;

        public LevelStarter
            (
            CanvasSwitcher canvasSwitcher, 
            LevelConfigsHub levelConfigsHub,
            LevelTimer timer,
            LevelResultTracker resultTracker,
            LevelFinisher finisher,
            HoleMover holeMover
            )
        {
            if (canvasSwitcher == null)
                throw new ArgumentNullException(nameof(canvasSwitcher));
            if (levelConfigsHub == null)
                throw new ArgumentException(nameof(levelConfigsHub));
            if (timer == null)
                throw new ArgumentNullException(nameof(timer));
            if (resultTracker == null)
                throw new ArgumentNullException(nameof(resultTracker));
            if (finisher == null)
                throw new ArgumentNullException(nameof(finisher));
            if (holeMover == null)
                throw new ArgumentNullException(nameof(holeMover));

            _canvasSwitcher = canvasSwitcher;
            _levelConfigsHub = levelConfigsHub;
            _timer = timer;
            _resultTracker = resultTracker;
            _finisher = finisher;
            _holeMover = holeMover;
        }

        public void Start()
        {
            _canvasSwitcher.OpenLevel();

            LevelConfig currentLevelConfig = _levelConfigsHub.GetCurrent();

            _timer.StartTimer(currentLevelConfig.Time);
            _resultTracker.Track(currentLevelConfig.ObjectsCount);

            _resultTracker.LevelFailed += OnLevelFailed;
            _resultTracker.LevelCompleted += OnLevelCompleted;
            _holeMover.StartMoving();
        }

        private void OnLevelCompleted()
        {
            OnFinish();
            _finisher.OnLevelCompleted();
        }

        private void OnLevelFailed()
        {
            OnFinish();
            _finisher.OnlevelFailed();
        }

        private void OnFinish()
        {
            _holeMover.StopMoving();

            _resultTracker.LevelFailed -= OnLevelFailed;
            _resultTracker.LevelCompleted -= OnLevelCompleted;
        }
    }
}
