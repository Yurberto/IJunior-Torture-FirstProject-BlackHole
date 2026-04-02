using System;

namespace Assets.Scripts.AbilitySystem
{
    public class AbilityUpgradePresenter
    {
        private AbilityUpgrader _upgrader;
        private AbilityUpgraderView _upgraderView;

        public AbilityUpgradePresenter(AbilityUpgrader upgrader, AbilityUpgraderView upgraderView)
        {
            if (upgrader == null)
                throw new ArgumentNullException(nameof(upgrader));
            if (upgraderView == null)
                throw new ArgumentNullException(nameof(upgraderView));

            _upgrader = upgrader;
            _upgraderView = upgraderView;

            _upgraderView.Init(upgrader);

            _upgraderView.UpgradeButtonClicked += Upgrade;
        }

        public void Dispose()
        {
            _upgraderView.UpgradeButtonClicked -= Upgrade;
        }

        private void Upgrade()
        {
            _upgrader.TryUpgrade();
        }
    }
}
