using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.AbilitySystem
{
    public class AbilityUpgraderView : MonoBehaviour
    {
        [SerializeField] private Button _startSize;
        [SerializeField] private Button _scale;
        [SerializeField] private Button _money;

        private AbilityUpgrader _abilityUpgrader;

        public void Init(AbilityUpgrader abilityUpgrader)
        {
            if (abilityUpgrader == null) 
                throw new ArgumentNullException(nameof(abilityUpgrader));

            _abilityUpgrader = abilityUpgrader;

            _startSize.onClick.AddListener(UpgradeStartSize);
            _scale.onClick.AddListener(UpgradeScale);
            _money.onClick.AddListener(UpgradeMoney);
        }

        public void Dispose()
        {
            _startSize.onClick.RemoveListener(UpgradeStartSize);
            _scale.onClick.RemoveListener(UpgradeScale);
            _money.onClick.RemoveListener(UpgradeMoney);
        }

        private void UpgradeStartSize()
        {
            if (_abilityUpgrader.TryUpgradeStartSize() == false)
            {
                Debug.Log("Дописать логику отработчика ошибок");
            }
        }

        private void UpgradeScale()
        {
            if (_abilityUpgrader.TryUpgradeScale() == false)
            {
                Debug.Log("Дописать логику отработчика ошибок");
            }
        }

        private void UpgradeMoney()
        {
            if (_abilityUpgrader.TryUpgradeMoney() == false)
            {
                Debug.Log("Дописать логику отработчика ошибок");
            }
        }
    }
}
