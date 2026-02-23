using Assets.Scripts.Game;
using Assets.Scripts.MoneyClasses;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ability
{
    public class AbilityUpgrader : MonoBehaviour
    {
        [SerializeField] private Button _startSize;
        [SerializeField] private Button _scale;
        [SerializeField] private Button _money;

        private PlayerStats _playerStats;
        private Money _moneyStats;

        private AbilityCost _abilityCost;
        private AbilityLevel _abilityLevel;

        public void Init(PlayerStats playerStats, Money moneyStats, AbilityCost abilityCost, AbilityLevel abilityLevel)
        {
            if (playerStats == null)
                throw new ArgumentNullException(nameof(playerStats));
            if (moneyStats == null)
                throw new ArgumentNullException(nameof(moneyStats));
            if (abilityCost == null)
                throw new ArgumentNullException(nameof(abilityCost));
            if (abilityLevel == null)
                throw new ArgumentNullException(nameof(abilityLevel));

            _playerStats = playerStats;
            _moneyStats = moneyStats;
            _abilityCost = abilityCost;
            _abilityLevel = abilityLevel;

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
            int cost = _abilityCost.StartSizeCost;

            if (_moneyStats.Value - cost < 0)
                return;

            Debug.Log($"UpgradeStartSize_AbilityUpgrader");

            _moneyStats.Pay(cost);
            _playerStats.UpgradeStartSize();
            _abilityLevel.UpgradeStartSize();
        }

        private void UpgradeScale()
        {
            int cost = _abilityCost.ScaleCost;

            if (_moneyStats.Value - cost < 0)
                return;

            Debug.Log($"UpgradeScale_AbilityUpgrader");

            _moneyStats.Pay(cost);
            _playerStats.UpgradeScale();
            _abilityLevel.UpgradeScale();
        }

        private void UpgradeMoney()
        {
            int cost = _abilityCost.MoneyCost;

            if (_moneyStats.Value - cost < 0)
                return;

            Debug.Log($"UpgradeMoney_AbilityUpgrader");

            _moneyStats.Pay(cost);
            _playerStats.UpgradeMoney();
            _abilityLevel.UpgradeMoney();
        }
    }
}
