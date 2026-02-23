using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.MoneyClasses
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private Money _money;

        public void Init(Money money)
        {
            if (money == null)
                throw new ArgumentNullException(nameof(money));

            _money = money;

            _money.ValueChanged += UpdateText;
        }

        public void Dispose()
        {
            _money.ValueChanged -= UpdateText;
        }

        private void UpdateText(int value)
        {
            if (_money == null)
                throw new ArgumentNullException(nameof(_money));
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            Debug.Log($"UpdateText_MoneyView - " + value.ToString());
            _text.text = value.ToString();
        }
    }
}
