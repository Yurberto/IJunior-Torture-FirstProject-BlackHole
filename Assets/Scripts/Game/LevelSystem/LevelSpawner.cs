using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Game.LevelSystem
{
    public class LevelSpawner
    {
        private LevelConfigsHub _levelConfigsHub;

        private Transform _lastSpawned;

        public LevelSpawner(LevelConfigsHub levelConfigsHub)
        {
            if (levelConfigsHub == null)
                throw new ArgumentNullException(nameof(levelConfigsHub));

            _levelConfigsHub = levelConfigsHub;
        }

        public Transform SpawnCurrentLevel()
        {
            if (_lastSpawned != null)
                DestroyLastSpawned();

            _lastSpawned = Object.Instantiate(_levelConfigsHub.GetCurrent().Level);
            _lastSpawned.position = new Vector3(0, 0, 0);

            return _lastSpawned;
        }

        private void DestroyLastSpawned()
        {
            Object.Destroy(_lastSpawned.gameObject);
            _lastSpawned = null;
        }
    }
}
