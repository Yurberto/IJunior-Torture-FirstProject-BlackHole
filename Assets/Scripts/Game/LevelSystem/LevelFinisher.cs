using System;
using UnityEngine;

namespace Assets.Scripts.Game.LevelSystem
{
    public class LevelFinisher
    {
        private CanvasSwitcher _canvasSwitcher;

        public LevelFinisher(CanvasSwitcher canvasSwitcher)
        {
            if (canvasSwitcher == null)
                throw new ArgumentNullException(nameof(canvasSwitcher));

            _canvasSwitcher = canvasSwitcher;
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
        }
    }
}
