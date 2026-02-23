using TMPro;
using UnityEngine;
using System;

namespace Assets.Scripts.Ability
{
    public class AbilityCostView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _startSizeCost;
        [SerializeField] private TextMeshProUGUI _scaleCost;
        [SerializeField] private TextMeshProUGUI _moneyCost;

        private AbilityLevel _abilityLevel;
        private AbilityCost _abilityCost;

        public void Init(AbilityLevel abilityLevel, AbilityCost abilityCost)
        {
            if (abilityLevel == null)
                throw new ArgumentNullException(nameof(abilityLevel));
            if (abilityCost == null) 
                throw new ArgumentNullException(nameof(abilityCost));

            _abilityLevel = abilityLevel;
            _abilityCost = abilityCost;

            _abilityLevel.StartSizeLevelChanged += UpdateStartSizeCost;
            _abilityLevel.ScaleLevelChanged += UpdateScaleCost;
            _abilityLevel.MoneyLevelChanged += UpdateMoneyCost;

            UpdateStartSizeCost();
            UpdateScaleCost();
            UpdateMoneyCost();
        }

        public void Dispose()
        {
            _abilityLevel.StartSizeLevelChanged -= UpdateStartSizeCost;
            _abilityLevel.ScaleLevelChanged -= UpdateScaleCost;
            _abilityLevel.MoneyLevelChanged -= UpdateMoneyCost;
        }

        private void UpdateStartSizeCost()
        {
            _startSizeCost.text = _abilityCost.StartSizeCost.ToString();
        }
        private void UpdateScaleCost()
        {
            _scaleCost.text = _abilityCost.ScaleCost.ToString();
        }
        private void UpdateMoneyCost()
        {
            _moneyCost.text = _abilityCost.MoneyCost.ToString();
        }
    }
}
