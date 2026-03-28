using System;
using YG;

namespace Assets.Scripts.WalletSystem
{
    public class Wallet
    {
        private int _moneyAmount;

        public Wallet(int moneyAmount)
        {
            if (moneyAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(moneyAmount));

            _moneyAmount = moneyAmount;
        }

        public event Action<int> MoneyAmountChanged;

        public int MoneyAmount => _moneyAmount;

        public void Add(int amount)
        {
            if (amount <= 0) 
                throw new ArgumentOutOfRangeException(nameof(amount));

            _moneyAmount += amount;

            YG2.saves.SetMoneyCount(_moneyAmount);
            MoneyAmountChanged?.Invoke(_moneyAmount);
        }

        public bool TryPay(int amount)
        {
            if (amount  < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (_moneyAmount - amount < 0)
                return false;

            _moneyAmount -= amount;

            YG2.saves.SetMoneyCount(_moneyAmount);
            MoneyAmountChanged?.Invoke(_moneyAmount);

            return true;
        }
    }
}

