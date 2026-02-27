using Assets.Scripts.AbilityNew.ScriptableObjects;
using System;
using UnityEngine;

namespace Assets.Scripts.AbilityNew
{
    public class Ability
    {
        private string _name;

        private int _level;
        private int _cost;
        private float _ratio;

        private BaseAbilityStats _baseStats;

        public Ability(BaseAbilityStats baseAbilityStats)
        {
            if (baseAbilityStats == null) 
                throw new ArgumentNullException(nameof(baseAbilityStats));

            _baseStats = baseAbilityStats;

            _name = _baseStats.Name;
            _level = _baseStats.Level;
            _cost = _baseStats.Cost;
            _ratio = _baseStats.Ratio;
        }

        public event Action LevelUp;

        public string Name => _name;
        public int Level => _level;
        public int Cost => _cost;
        public float Ratio => _ratio;


        public void UpLevel()
        {
            _ratio *= _baseStats.UpLevelRatioGrowth;
            Upgrade();
        }

        private void Upgrade()
        {
            _level++;
            _cost = (int)(_baseStats.Cost * Mathf.Pow(_level, _baseStats.UpLevelCostGrowth));

            LevelUp?.Invoke();
        }
    }
}