using Assets.Scripts.Game.LevelSystem.Award;
using System;

namespace Assets.Scripts.Game.LevelSystem
{
    public class LevelFinisher
    {
        private CanvasSwitcher _canvasSwitcher;

        private LevelSpawner _levelSpawner;

        private LevelConfigsHub _levelConfigsHub;
        private LevelAwarder _levelAwarder;

        public LevelFinisher(CanvasSwitcher canvasSwitcher, LevelSpawner levelSpawner, LevelConfigsHub levelConfigsHub, LevelAwarder levelAwarder)
        {
            if (canvasSwitcher == null)
                throw new ArgumentNullException(nameof(canvasSwitcher));
            if (levelSpawner == null)
                throw new ArgumentException(nameof(levelSpawner));
            if (levelConfigsHub == null)
                throw new ArgumentNullException(nameof(levelConfigsHub));
            if (levelAwarder == null)
                throw new ArgumentNullException(nameof(levelAwarder));

            _canvasSwitcher = canvasSwitcher;
            _levelSpawner = levelSpawner;
            _levelConfigsHub = levelConfigsHub;
            _levelAwarder = levelAwarder;
        }

        public void OnlevelFailed()
        {
            _canvasSwitcher.CloseLevel();
            _canvasSwitcher.OpenLevelFailed();
        }

        public void OnLevelCompleted()
        {
            _levelSpawner.DestroyLastSpawned();

            _canvasSwitcher.CloseLevel();
            _canvasSwitcher.OpenLevelCompleted();

            _levelAwarder.AwardLevelReward(_levelConfigsHub.GetCurrent());
            _levelConfigsHub.SwitchToNextLevel();
        }
    }
}
