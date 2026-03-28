using System;
using System.Collections.Generic;
using UnityEngine;
using YG;

namespace Assets.Scripts.Game.LevelSystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = nameof(LevelConfigsHub), menuName = nameof(ScriptableObject) + "/" + nameof(LevelConfigsHub))]
    public class LevelConfigsHub : ScriptableObject
    {
        [SerializeField] private List<LevelConfig> _configs;

        private int _currentIndex;

        public void Init(int currentIndex)
        {
            if (currentIndex < 0 || currentIndex >= _configs.Count)
                throw new ArgumentOutOfRangeException(nameof(currentIndex));

            _currentIndex = currentIndex;
        }

        public void SwitchToNextLevel()
        {
            YG2.saves.SetCurrentLevel(++_currentIndex);
        }

        public LevelConfig GetCurrent()
        {
            if (_currentIndex < 0 || _currentIndex >= _configs.Count)
                    throw new ArgumentOutOfRangeException(nameof(_currentIndex));

            return _configs[_currentIndex];
        }
    }
}
