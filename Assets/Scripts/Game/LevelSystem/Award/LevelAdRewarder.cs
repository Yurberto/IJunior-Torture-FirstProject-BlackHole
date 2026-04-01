using Assets.Scripts.AbilitySystem;
using Assets.Scripts.WalletSystem;
using System;
using UnityEngine;

namespace Assets.Scripts.Game.LevelSystem.Award
{
    public class LevelAdRewarder
    {
        private const int MultiplyFactor = 5;

        private Ability _money;
        private Wallet _wallet;

        private LevelConfigsHub _levelConfigsHub;

        public LevelAdRewarder(Ability money, Wallet wallet, LevelConfigsHub levelConfigsHub)
        {
            if (money == null)
                throw new ArgumentNullException(nameof(money));
            if (wallet == null)
                throw new ArgumentNullException(nameof(wallet));
            if (levelConfigsHub == null)
                throw new ArgumentNullException(nameof(levelConfigsHub));

            _money = money;
            _wallet = wallet;
            _levelConfigsHub = levelConfigsHub;
        }

        public void Reward(RewardType rewardType)
        {
            int reward = 0;
            LevelConfig currentLevel = _levelConfigsHub.GetCurrent();

            switch (rewardType)
            {
                case RewardType.CoinsMultiply:
                    reward = Mathf.CeilToInt(currentLevel.Reward * MultiplyFactor * _money.Ratio);
                    break;

                case RewardType.CoinsAdd:
                    reward = Mathf.CeilToInt(currentLevel.Reward * _money.Ratio);
                    break;

                default:
                    throw new Exception("Unknowing rewardType");
            }

            _wallet.Add(reward);
        }

    }
}
