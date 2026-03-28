using Assets.Scripts.Game.LevelSystem.ScriptableObjects;
using System;
using UnityEngine;

namespace Assets.Scripts.Game.LevelSystem
{
    public class LevelFinisher
    {
        private CanvasSwitcher _canvasSwitcher;

        private LevelConfigsHub _levelConfigsHub;

        public LevelFinisher(CanvasSwitcher canvasSwitcher, LevelConfigsHub levelConfigsHub)
        {
            if (canvasSwitcher == null)
                throw new ArgumentNullException(nameof(canvasSwitcher));
            if (levelConfigsHub == null)
                throw new ArgumentNullException(nameof(levelConfigsHub));

            _canvasSwitcher = canvasSwitcher;
            _levelConfigsHub = levelConfigsHub;
        }

        public void OnlevelFailed()
        {
            _canvasSwitcher.CloseLevel();
            _canvasSwitcher.OpenLevelFailed();
        }

        public void OnLevelCompleted()
        {
            _canvasSwitcher.CloseLevel();
            _canvasSwitcher.OpenLevelCompleted();

            _levelConfigsHub.SwitchToNextLevel();
        }
    }
}
