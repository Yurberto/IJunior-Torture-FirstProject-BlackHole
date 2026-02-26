using Assets.Scripts.Game.ScriptableObjects;
using Assets.Scripts.WalletSystem;
using System;
using UnityEngine;

namespace Assets.Scripts.AbilityNew
{
    public class AbilityUpgrader
    {
        private Ability _startSize;
        private Ability _scale;
        private Ability _money;

        private Wallet _wallet;

        public AbilityUpgrader(Ability startSize, Ability scale, Ability money, Wallet wallet)
        {
            if (startSize == null) 
                throw new ArgumentNullException(nameof(startSize));
            if (scale == null)
                throw new ArgumentNullException(nameof(scale));
            if (money == null)
                throw new ArgumentNullException(nameof(money));
            if (wallet == null)
                throw new ArgumentNullException(nameof(wallet));

            _startSize = startSize;
            _scale = scale;
            _money = money;

            _wallet = wallet;
        }

        public bool TryUpgradeStartSize()
        {
            Debug.Log($"UpgradeStartSize_AbilityUpgrader - {_startSize.Ratio}");

            if (_wallet.TryPay(_startSize.Cost))
            {
                _startSize.UpLevel();
                return true;
            }

            return false;
        }

        public bool TryUpgradeScale()
        {
            Debug.Log($"UpgradeScale_AbilityUpgrader - {_scale.Ratio}");

            if (_wallet.TryPay(_scale.Cost))
            {
                _scale.UpLevel();
                return true;
            }

            return false;
        }

        public bool TryUpgradeMoney()
        {
            Debug.Log($"UpgradeMoney_AbilityUpgrader - {_money.Ratio}");

            if (_wallet.TryPay(_money.Cost))
            {
                _money.UpLevel();
                return true;
            }

            return false;
        }
    }
}
