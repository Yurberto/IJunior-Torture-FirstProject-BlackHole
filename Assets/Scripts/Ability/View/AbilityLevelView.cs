using TMPro;
using System;
using UnityEngine;

namespace Assets.Scripts.Ability
{
    public class AbilityLevelView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _startSizeText;
        [SerializeField] private TextMeshProUGUI _scaleText;
        [SerializeField] private TextMeshProUGUI _moneyText;

        private AbilityLevel _abilityLevel;
        
        public void Init(AbilityLevel abilityLevel)
        {
            if (abilityLevel == null) 
                throw new ArgumentNullException(nameof(abilityLevel));

            _abilityLevel = abilityLevel;

            _abilityLevel.StartSizeLevelChanged += UpdateStartSizeText;
            _abilityLevel.ScaleLevelChanged += UpdateScaleText;
            _abilityLevel.MoneyLevelChanged += UpdateMoneyText;

            UpdateStartSizeText();
            UpdateScaleText();
            UpdateMoneyText();
        }

        public void Dispose()
        {
            _abilityLevel.StartSizeLevelChanged -= UpdateStartSizeText;
            _abilityLevel.ScaleLevelChanged -= UpdateScaleText;
            _abilityLevel.MoneyLevelChanged -= UpdateMoneyText;
        }

        private void UpdateStartSizeText()
        {
            _startSizeText.text = _abilityLevel.StartSize.ToString();
        }

        private void UpdateScaleText()
        {
            _scaleText.text = _abilityLevel.Scale.ToString();
        }

        private void UpdateMoneyText()
        {
            _moneyText.text = _abilityLevel.Money.ToString();
        }
    }
}
