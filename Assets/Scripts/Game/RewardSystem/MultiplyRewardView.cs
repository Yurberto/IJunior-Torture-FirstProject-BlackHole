using TMPro;
using UnityEngine;

namespace Assets.Scripts.Game.RewardSystem
{
    public class MultiplyRewardView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private RewardsConfig _rewardsConfig;

        private void OnEnable()
        {
            _text.text = $"X{_rewardsConfig.MultiplyFactor}";
        }
    }
}
