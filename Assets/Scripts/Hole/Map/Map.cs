using Assets.Scripts.Game.LevelSystem;
using System;
using UnityEngine;

namespace Assets.Scripts.Hole.Map
{
    public class Map
    {
        private Transform _map;
        private LevelConfigsHub _levelConfigsHub;

        private MapScaler _scaler;
        private MapMover _mover;

        public Map(Transform map, LevelConfigsHub levelConfigsHub)
        {
            if (map == null) 
                throw new ArgumentNullException(nameof(map));
            if (levelConfigsHub == null) 
                throw new ArgumentNullException(nameof(levelConfigsHub));

            _map = map;
            _levelConfigsHub = levelConfigsHub;

            _scaler = new MapScaler(_map);
            _mover = new MapMover(_map);
        }

        public void AdjustToCurrentLevel()
        {
            LevelConfig currentLevel = _levelConfigsHub.GetCurrent();

            _scaler.Scale(currentLevel.MapScale);
            _mover.MoveTo(currentLevel.MapPosition);
        }
    }
}
