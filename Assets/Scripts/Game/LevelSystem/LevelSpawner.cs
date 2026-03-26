using Assets.Scripts.Game.LevelSystem.ScriptableObjects;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Game.LevelSystem
{
    public class LevelSpawner
    {
        private LevelConfigsHub _levelConfigsHub;

        public LevelSpawner(LevelConfigsHub levelConfigsHub)
        {
            if (levelConfigsHub == null)
                throw new ArgumentNullException(nameof(levelConfigsHub));

            _levelConfigsHub = levelConfigsHub;
        }

        public Transform SpawnCurrentLevel()
        {
            Transform spawned = Object.Instantiate(_levelConfigsHub.GetCurrent().Level);
            spawned.position = new Vector3(0, 0, 0);

            return spawned;
        }
    }
}
