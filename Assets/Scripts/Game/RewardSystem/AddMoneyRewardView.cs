using Assets.Scripts.AbilitySystem;
using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Game.RewardSystem
{
    public class AddMoneyRewardView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        [SerializeField] private RewardsConfig _rewardsConfig;

        private Ability _money;

        public void Init(Ability money)
        {
            if (money == null) 
                throw new ArgumentNullException(nameof(money));

            _money = money;
        }

        private void OnEnable()
        {
            _text.text = $"+{Mathf.CeilToInt(_rewardsConfig.AddMoney * _money.Ratio)}";
        }
    }
}
