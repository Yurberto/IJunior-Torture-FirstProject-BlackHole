using System;
using UnityEngine;
using YG;

namespace Assets.Scripts.AbilitySystem
{
    public class Ability
    {
        private string _name;

        private int _level;
        private int _cost;
        private float _ratio;

        private BaseAbilityStats _baseStats;
        private AbilityInfo _abilityInfo;

        public Ability(BaseAbilityStats baseAbilityStats, AbilityInfo abilityInfo, bool isFirstLaunch)
        {
            if (baseAbilityStats == null)
                throw new ArgumentNullException(nameof(baseAbilityStats));
            if (abilityInfo == null)
                throw new ArgumentNullException(nameof(abilityInfo));

            _baseStats = baseAbilityStats;
            _abilityInfo = abilityInfo;

            _name = _baseStats.Name;

            if (isFirstLaunch)
            {
                _level = _baseStats.Level;
                _cost = _baseStats.Cost;
                _ratio = _baseStats.Ratio;

                _abilityInfo.Update(_level, _cost, _ratio);
            }
            else
            {
                _level = _abilityInfo.Level;
                _cost = _abilityInfo.Cost;
                _ratio = _abilityInfo.Ratio;
            }
        }

        public event Action LevelUp;

        public string Name => _name;
        public int Level => _level;
        public int Cost => _cost;
        public float Ratio => _ratio;


        public void UpLevel()
        {
            _ratio *= _baseStats.UpLevelRatioGrowth;
            _level++;
            _cost = (int)(_baseStats.Cost * Mathf.Pow(_level, _baseStats.UpLevelCostGrowth));

            _abilityInfo.Update(_level, _cost, _ratio);
            LevelUp?.Invoke();
        }

        public void Reset()
        {
            _level = _baseStats.Level;
            _cost = _baseStats.Cost;
            _ratio = _baseStats.Ratio;
        }
    }
}