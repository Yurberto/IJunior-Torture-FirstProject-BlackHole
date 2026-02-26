using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.WalletSystem
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private Wallet _wallet;

        public void Init(Wallet wallet)
        {
            if (wallet == null)
                throw new ArgumentNullException(nameof(wallet));

            _wallet = wallet;

            _wallet.MoneyAmountChanged += UpdateText;
        }

        public void Dispose()
        {
            _wallet.MoneyAmountChanged -= UpdateText;
        }

        private void UpdateText(int value)
        {
            if (_wallet == null)
                throw new ArgumentNullException(nameof(_wallet));
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            Debug.Log($"UpdateText_MoneyView - " + value.ToString());
            _text.text = value.ToString();
        }
    }
}
