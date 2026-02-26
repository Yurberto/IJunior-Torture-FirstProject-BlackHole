using System;
using UnityEngine;

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

            Debug.Log($"Add_Money - {amount}"); // удалить unityEngine

            _moneyAmount += amount;
            MoneyAmountChanged?.Invoke(_moneyAmount);
        }

        public bool TryPay(int amount)
        {
            if (amount  < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (_moneyAmount - amount < 0)
                return false;

            Debug.Log($"TryPay_Money"); // удалить unityEngine
            _moneyAmount -= amount;
            MoneyAmountChanged?.Invoke(_moneyAmount);

            return true;
        }
    }
}

