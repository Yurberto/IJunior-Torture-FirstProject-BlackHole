using Assets.Scripts.AbilitySystem;
using Assets.Scripts.Game.LevelSystem;
using Assets.Scripts.WalletSystem;
using System;

namespace Assets.Scripts.Game
{
    public class AdAwarder
    {
        private Wallet _wallet;
        private Ability _money;

        private RewardsConfig _rewardsConfig;

        public AdAwarder(Wallet wallet, Ability money, RewardsConfig rewardsConfig)
        {
            if (wallet == null)
                throw new ArgumentNullException(nameof(wallet));
            if (money == null)
                throw new ArgumentNullException(nameof(money));
            if (rewardsConfig == null)
                throw new ArgumentNullException(nameof(rewardsConfig));

            _wallet = wallet;
            _money = money;

            _rewardsConfig = rewardsConfig;
        }

        public void AwardAddMoney()
        {
            _wallet.AddMoney(_rewardsConfig.AddMoney * _money.Ratio);
        }

        public void AwardMultiplyLevelReward(LevelConfig levelConfig)
        {
            _wallet.AddMoney(levelConfig.Reward * _money.Ratio * _rewardsConfig.MultiplyFactor);
        }
    }
}
