using Assets.Scripts.WalletSystem;
using System;

namespace Assets.Scripts.AbilitySystem
{
    public class AbilityUpgrader
    {
        private Ability _ability;
        private Wallet _wallet;

        private bool _canUpgrade;

        public AbilityUpgrader(Ability ability, Wallet wallet)
        {
            if (ability == null)
                throw new ArgumentNullException(nameof(ability));
            if (wallet == null)
                throw new ArgumentNullException(nameof(wallet));

            _ability = ability;
            _wallet = wallet;

            _wallet.MoneyAmountUpdated += UpdateUpgradeAvailabilityInfo;

            UpdateUpgradeAvailabilityInfo(_wallet.MoneyAmount);
        }

        public void Dispose()
        {
            _wallet.MoneyAmountUpdated -= UpdateUpgradeAvailabilityInfo;
        }

        public event Action Upgraded;
        public event Action<bool> UpgradeAvailabilityToggled;

        public bool CanUpgrade => _canUpgrade;

        public bool TryUpgrade()
        {
            if (_canUpgrade == false)
                return false;

            if (_wallet.TryPay(_ability.Cost))
            {
                _ability.UpLevel();
                UpdateUpgradeAvailabilityInfo(_wallet.MoneyAmount);

                UnityEngine.Debug.Log($"AbilityUpgrader_Upgrade, cost - {_ability.Cost}");

                Upgraded?.Invoke();
                return true;
            }

            return false;
        }

        private void UpdateUpgradeAvailabilityInfo(int moneyAmount)
        {
            _canUpgrade = _ability.Cost <= moneyAmount;

            UnityEngine.Debug.Log($"AbilityUpgrader_UpdateUpgradeAvailabilityInfo - {_canUpgrade}");

            UpgradeAvailabilityToggled?.Invoke(_canUpgrade);
        }
    }
}
