using System;

namespace YG
{
    public partial class SavesYG
    {
        private int _moneyCount;
        private int _currentLevel;
        private bool _isFirstLaunch = true;

        public int MoneyCount => _moneyCount;
        public int CurrentLevel => _currentLevel;
        public bool IsFirstLaunch => _isFirstLaunch;

        public void SetMoneyCount(int moneyCount)
        {
            if (moneyCount < 0)
                throw new ArgumentOutOfRangeException(nameof(moneyCount));

            _moneyCount = moneyCount;
        }

        public void SetCurrentLevel(int currentLevel)
        {
            if (currentLevel < 0)
                throw new ArgumentException(nameof(currentLevel));

            _currentLevel = currentLevel;
        }

        public void OnFirstLaunch()
        {
            _moneyCount = 0;
            _currentLevel = 0;
            _isFirstLaunch = false;
        }
    }
}

