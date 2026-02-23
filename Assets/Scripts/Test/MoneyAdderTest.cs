using Assets.Scripts.MoneyClasses;
using Assets.Scripts.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Test
{
    internal class MoneyAdderTest : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private float _amount;

        private Money _money;
        private PlayerStats _playerStats;

        public void Init(Money money, PlayerStats playerStats)
        {
            _money = money;
            _playerStats = playerStats;
            Debug.Log("Удали потом");

            _button.onClick.AddListener(Add);
        }

        private void Add()
        {
            Debug.Log($"Add_moneyAdder");
            _money.Add((int)(_amount * _playerStats.MoneyRatio));
        }
    }
}
