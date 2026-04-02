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
            Persist();
        }

        public event Action<int> MoneyAmountUpdated;

        public int MoneyAmount => _moneyAmount;

        public void AddMoney(int amount)
        {
            if (amount <= 0) 
                throw new ArgumentOutOfRangeException(nameof(amount));

            _moneyAmount += amount;

            Persist();
        }

        public bool TryPay(int amount)
        {
            if (amount  < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (_moneyAmount - amount < 0)
                return false;

            _moneyAmount -= amount;
            Persist();

            return true;
        }

        private void Persist()
        {
            YG2.saves.SetMoneyCount(_moneyAmount);
            MoneyAmountUpdated?.Invoke(_moneyAmount);
        }
    }
}

