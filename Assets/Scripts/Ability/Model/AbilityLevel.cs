using System;
using UnityEngine;

namespace Assets.Scripts.Ability
{
    public class AbilityLevel
    {
        private int _startSize;
        private int _scale;
        private int _money;

        public AbilityLevel(int  startSize, int scale, int money)
        {
            if (startSize < 1) 
                throw new ArgumentOutOfRangeException(nameof(startSize));
            if (scale < 1)
                throw new ArgumentOutOfRangeException(nameof(scale));
            if (money < 1)
                throw new ArgumentOutOfRangeException(nameof(money));

            _startSize = startSize;
            _scale = scale;
            _money = money;
        }

        public event Action StartSizeLevelChanged;
        public event Action ScaleLevelChanged;
        public event Action MoneyLevelChanged;

        public int StartSize => _startSize;
        public int Scale => _scale;
        public int Money => _money;

        public void UpgradeStartSize()
        {
            Debug.Log($"UpgradeStartSize_AbilityLevel"); // UnityEngine удали
            _startSize++;
            StartSizeLevelChanged?.Invoke();
        }

        public void UpgradeScale()
        {
            Debug.Log($"UpgradeScale_AbilityLevel"); // UnityEngine удали
            _scale++;
            ScaleLevelChanged?.Invoke();
        }

        public void UpgradeMoney()
        {
            Debug.Log($"Upgrademoney_AbilityLevel"); // UnityEngine удали
            _money++;
            MoneyLevelChanged?.Invoke();
        }
    }
}
