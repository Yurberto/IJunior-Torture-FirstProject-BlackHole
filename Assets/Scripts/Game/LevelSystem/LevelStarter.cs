using Assets.Scripts.Game.LevelSystem.ScriptableObjects;
using Assets.Scripts.Game.Time;
using Assets.Scripts.Hole;
using Assets.Scripts.Hole.Scale;
using System;

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
        private AbsorbBar _absorbBar;
        private LevelHoleScaler _levelHoleScaler;

        public LevelStarter
            (
            CanvasSwitcher canvasSwitcher,
            LevelConfigsHub levelConfigsHub,
            LevelTimer timer,
            LevelResultTracker resultTracker,
            LevelFinisher finisher,
            HoleMover holeMover,
            AbsorbBar absorbBar,
            LevelHoleScaler levelHoleScaler
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
            if (absorbBar == null)
                throw new ArgumentNullException(nameof(absorbBar));
            if (levelHoleScaler == null)
                throw new ArgumentNullException(nameof(levelHoleScaler));

            _canvasSwitcher = canvasSwitcher;
            _levelConfigsHub = levelConfigsHub;
            _timer = timer;
            _resultTracker = resultTracker;
            _finisher = finisher;
            _holeMover = holeMover;
            _absorbBar = absorbBar;
            _levelHoleScaler = levelHoleScaler;
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
            _absorbBar.Subscribe();
            _levelHoleScaler.Start();
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
            _holeMover.BackToStartPosition();
            _absorbBar.Unsubscribe();
            _levelHoleScaler.Stop();

            _resultTracker.LevelFailed -= OnLevelFailed;
            _resultTracker.LevelCompleted -= OnLevelCompleted;
        }
    }
}
