using Assets.Scripts.Game.ScriptableObjects;
using System;
using UnityEngine;

namespace Assets.Scripts.Ability
{
    public class AbilityCost
    {
        private DefaultAbilityCosts _defaultCosts;
        private AbilityLevel _abilityLevel;

        public AbilityCost(DefaultAbilityCosts defaultAbilityCosts, AbilityLevel abilityLevel)
        {
            if (defaultAbilityCosts == null)
                throw new ArgumentNullException(nameof(defaultAbilityCosts));
            if (abilityLevel == null)
                throw new ArgumentNullException(nameof(abilityLevel));

            _defaultCosts = defaultAbilityCosts;
            _abilityLevel = abilityLevel;
        }

        public int StartSizeCost
        {
            get
            {
                return (int)(_defaultCosts.StartSizeCost * Mathf.Pow(_abilityLevel.StartSize, _defaultCosts.GrowthFactor));
            }

        }

        public int ScaleCost
        {
            get
            {
                return (int)(_defaultCosts.ScaleCost * Mathf.Pow(_abilityLevel.Scale, _defaultCosts.GrowthFactor));
            }

        }

        public int MoneyCost
        {
            get
            {
                return (int)(_defaultCosts.MoneyCost * Mathf.Pow(_abilityLevel.Money, _defaultCosts.GrowthFactor));
            }
        }
    }
}
