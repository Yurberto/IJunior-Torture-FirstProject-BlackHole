using Assets.Scripts.Game.Timer;
using Assets.Scripts.Hole;
using Assets.Scripts.Hole.Scale;
using System;

namespace Assets.Scripts.Game.LevelSystem
{
    public class LevelStarter
    {
        private Level _level;
        private LevelCompletedWindow _levelCompletedWindow;
        private LevelFailedWindow _levelFailedWindow;

        private LevelConfigsHub _levelConfigsHub;
        private Pause _pauseMenu;

        private LevelTimer _levelTimer;
        private LevelResultTracker _resultTracker;

        private HoleMover _holeMover;
        private AbsorbBar _absorbBar;
        private AbsorbHandler _absorbHandler;
        private LevelHoleScaler _levelHoleScaler;

        public LevelStarter
            (
            Level level,
            LevelCompletedWindow levelCompletedWindow,
            LevelFailedWindow levelFailedWindow,
            LevelConfigsHub levelConfigsHub,
            Pause pauseMenu,
            LevelTimer levelTimer,
            LevelResultTracker resultTracker,
            HoleMover holeMover,
            AbsorbHandler absorbHandler,
            AbsorbBar absorbBar,
            LevelHoleScaler levelHoleScaler
            )
        {
            if (level == null)
                throw new ArgumentNullException(nameof(level));
            if (levelCompletedWindow == null)
                throw new ArgumentException(nameof(levelCompletedWindow));
            if (levelFailedWindow == null)
                throw new ArgumentException(nameof(levelFailedWindow));
            if (levelConfigsHub == null)
                throw new ArgumentException(nameof(levelConfigsHub));
            if (pauseMenu == null)
                throw new ArgumentException(nameof(pauseMenu));
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

            _level = level;
            _levelCompletedWindow = levelCompletedWindow;
            _levelFailedWindow = levelFailedWindow;

            _levelConfigsHub = levelConfigsHub;
            _pauseMenu = pauseMenu;

            _levelTimer = levelTimer;
            _resultTracker = resultTracker;

            _holeMover = holeMover;
            _absorbHandler = absorbHandler;
            _absorbBar = absorbBar;
            _levelHoleScaler = levelHoleScaler;
        }

        public void StartLevel()
        {
            _level.Open();
            LevelConfig currentLevelConfig = _levelConfigsHub.GetCurrent();

            _levelTimer.Start(currentLevelConfig.Time);
            _resultTracker.Track(currentLevelConfig.ObjectsCount);

            _resultTracker.LevelFailed += OnLevelFailed;
            _resultTracker.LevelCompleted += OnLevelCompleted;

            _holeMover.StartMoving();
            _absorbBar.Subscribe();
            _absorbHandler.Reset();
            _levelHoleScaler.Start();

            _pauseMenu.BackToMenuPressed += OnFinish;
        }

        private void OnLevelCompleted()
        {
            OnFinish();

            _level.Close();
            _levelCompletedWindow.Open();
        }

        private void OnLevelFailed()
        {
            OnFinish();

            _level.Close();
            _levelFailedWindow.Open();
        }

        private void OnFinish()
        {
            _pauseMenu.BackToMenuPressed -= OnFinish;

            _holeMover.StopMoving();
            _holeMover.BackToStartPosition();

            _absorbBar.Unsubscribe();

            _levelHoleScaler.Stop();
            _levelTimer.Stop();
            _resultTracker.StopTracking();

            _resultTracker.LevelFailed -= OnLevelFailed;
            _resultTracker.LevelCompleted -= OnLevelCompleted;
        }
    }
}
