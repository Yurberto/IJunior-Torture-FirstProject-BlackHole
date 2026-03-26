using System;
namespace YG
{
    public partial class SavesYG
    {
        private int _moneyCount;
        private int _currentLevel;

        public int MoneyCount => _moneyCount;
        public int CurrentLevel => _currentLevel;

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
    }
}

