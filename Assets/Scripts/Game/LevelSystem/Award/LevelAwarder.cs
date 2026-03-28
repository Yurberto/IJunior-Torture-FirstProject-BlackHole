using Assets.Scripts.AbilitySystem;
using Assets.Scripts.WalletSystem;
using System;
using UnityEngine;

namespace Assets.Scripts.Game.LevelSystem
{
    public class LevelAwarder
    {
        private Wallet _wallet;
        private Ability _money;

        public LevelAwarder(Wallet wallet, Ability money)
        {
            if (wallet == null)
                throw new ArgumentNullException(nameof(wallet));
            if (money == null)
                throw new ArgumentNullException(nameof(money));

            _wallet = wallet;
            _money = money;
        }

        public event Action<int> LevelRewardAwarded;

        public void AwardLevelReward(LevelConfig levelConfig)
        {
            _wallet.Add(Mathf.CeilToInt(levelConfig.Reward * _money.Ratio));

            LevelRewardAwarded?.Invoke(levelConfig.Reward);
        }
    }
}
