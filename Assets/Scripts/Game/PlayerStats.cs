using Assets.Scripts.Game.ScriptableObjects;
using System;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class PlayerStats
    {
        private float _startSizeRatio;
        private float _scaleRatio;
        private float _moneyRatio;

        private float _currentSize;

        private DefaultPlayerStats _defaultStats;

        public PlayerStats(DefaultPlayerStats defaultStats)
        {
            if (defaultStats == null)
                throw new ArgumentNullException(nameof(defaultStats));

            _defaultStats = defaultStats;

            Reset();
        }

        public event Action<float> StartSizeUpdated;
        public event Action<float> ScaleUpdated;

        public event Action<float> CurrentSizeUpdated;

        public float MoneyRatio => _moneyRatio;

        public void Reset()
        {
            if (_defaultStats == null)
                throw new ArgumentNullException(nameof(_defaultStats));

            _startSizeRatio = _defaultStats.BaseStartSize;
            _scaleRatio = _defaultStats.BaseScale;
            _moneyRatio = _defaultStats.BaseMoney;

            _currentSize = _startSizeRatio;

            CurrentSizeUpdated?.Invoke(_currentSize);
        }

        public void OnObjectAbsorbed(float mass)
        {
            if (mass <= 0)
                throw new ArgumentOutOfRangeException(nameof(mass));

            _currentSize += _scaleRatio * mass;

            CurrentSizeUpdated?.Invoke(_currentSize);
        }

        public void UpgradeStartSize()
        {
            if (_defaultStats == null)
                throw new ArgumentNullException(nameof(_defaultStats));

            Debug.Log($"UpgradeStartSize_PlayerStats - {_startSizeRatio}");

            _startSizeRatio *= _defaultStats.StartSizeGrowth;
            _currentSize = _startSizeRatio;

            StartSizeUpdated?.Invoke(_startSizeRatio);
            CurrentSizeUpdated?.Invoke(_currentSize);

        }

        public void UpgradeScale()
        {
            if (_defaultStats == null)
                throw new ArgumentNullException(nameof(_defaultStats));


            _scaleRatio *= _defaultStats.ScaleGrowth;
            Debug.Log($"UpgradeScale_PlayerStats - {_scaleRatio}");

            ScaleUpdated?.Invoke(_scaleRatio);
        }

        public void UpgradeMoney()
        {
            if (_defaultStats == null)
                throw new ArgumentNullException(nameof(_defaultStats));

            Debug.Log($"UpgradeMoney_PlayerStats - {_moneyRatio}");

            _moneyRatio *= _defaultStats.MoneyGrowth;

            Debug.Log("Когда начнешь делать награду за уровень, бери money отсюда, это коэефициент");
        }
    }
}
