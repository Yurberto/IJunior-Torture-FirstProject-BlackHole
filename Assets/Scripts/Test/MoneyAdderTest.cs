using Assets.Scripts.WalletSystem;
using Assets.Scripts.Game;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.AbilitySystem;

namespace Assets.Scripts.Test
{
    internal class MoneyAdderTest : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private int _amount;

        private Wallet _wallet;
        private Ability _money;

        public void Init(Wallet wallet, Ability money)
        {
            _wallet = wallet;
            _money = money;
            Debug.Log("Удали потом");

            _button.onClick.AddListener(Add);
        }

        private void Add()
        {
            Debug.Log($"Add_moneyAdder");
            _wallet.AddMoney((int)(_amount * _money.Ratio));
        }
    }
}
