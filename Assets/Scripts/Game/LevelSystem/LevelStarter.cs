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

        private LevelTimer _levelTimer;
        private LevelResultTracker _resultTracker;

        private HoleMover _holeMover;
        private AbsorbBar _absorbBar;
        private AbsorbHandler _absorbHandler;
        private LevelHoleScaler _levelHoleScaler;

        public LevelStarter
            (
            CanvasSwitcher canvasSwitcher,
            LevelConfigsHub levelConfigsHub,
            LevelTimer levelTimer,
            LevelResultTracker resultTracker,
            HoleMover holeMover,
            AbsorbHandler absorbHandler,
            AbsorbBar absorbBar,
            LevelHoleScaler levelHoleScaler
            )
        {
            if (canvasSwitcher == null)
                throw new ArgumentNullException(nameof(canvasSwitcher));
            if (levelConfigsHub == null)
                throw new ArgumentException(nameof(levelConfigsHub));
            if (levelTimer == null)
                throw new ArgumentNullException(nameof(levelTimer));
            if (resultTracker == null)
                throw new ArgumentNullException(nameof(resultTracker));
            if (holeMover == null)
                throw new ArgumentNullException(nameof(holeMover));
            if (absorbHandler == null)
                throw new ArgumentNullException(nameof(absorbHandler));
            if (absorbBar == null)
                throw new ArgumentNullException(nameof(absorbBar));
            if (levelHoleScaler == null)
                throw new ArgumentNullException(nameof(levelHoleScaler));

            _canvasSwitcher = canvasSwitcher;
            _levelConfigsHub = levelConfigsHub;
            _levelTimer = levelTimer;
            _resultTracker = resultTracker;
            _holeMover = holeMover;
            _absorbHandler = absorbHandler;
            _absorbBar = absorbBar;
            _levelHoleScaler = levelHoleScaler;
        }

        public void StartLevel()
        {
            _canvasSwitcher.OpenLevel();

            LevelConfig currentLevelConfig = _levelConfigsHub.GetCurrent();

            _levelTimer.Start(currentLevelConfig.Time);
            _resultTracker.Track(currentLevelConfig.ObjectsCount);

            _resultTracker.LevelFailed += OnLevelFailed;
            _resultTracker.LevelCompleted += OnLevelCompleted;

            _holeMover.StartMoving();
            _absorbBar.Subscribe();
            _absorbHandler.Reset();
            _levelHoleScaler.Start();
        }

        private void OnLevelCompleted()
        {
            OnFinish();

            _canvasSwitcher.CloseLevel();
            _canvasSwitcher.OpenLevelCompletedWindow();
        }

        private void OnLevelFailed()
        {
            OnFinish();

            _canvasSwitcher.CloseLevel();
            _canvasSwitcher.OpenLevelFailedWindow();
        }

        private void OnFinish()
        {
            _holeMover.StopMoving();
            _holeMover.BackToStartPosition();

            _absorbBar.Unsubscribe();

            _levelHoleScaler.Stop();
            _levelTimer.Stop();

            _resultTracker.LevelFailed -= OnLevelFailed;
            _resultTracker.LevelCompleted -= OnLevelCompleted;
        }
    }
}
