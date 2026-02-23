using System;
using UnityEngine;

namespace Assets.Scripts.MoneyClasses
{
    public class Money
    {
        private int _value;

        public Money(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _value = value;
        }

        public event Action<int> ValueChanged;

        public int Value => _value;

        public void Add(int amount)
        {
            if (amount <= 0) 
                throw new ArgumentOutOfRangeException(nameof(amount));

            Debug.Log($"Add_Money - {amount}"); // удалить unityEngine

            _value += amount;
            ValueChanged?.Invoke(_value);
        }

        public void Pay(int amount)
        {
            if (amount <= 0 || _value - amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            Debug.Log($"Pay_Money"); // удалить unityEngine
            _value -= amount;
            ValueChanged?.Invoke(_value);
        }
    }
}

