using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Game.LevelSystem.Award
{
    public class LevelRewardView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private LevelAwarder _levelAwarder;

        public void Init(LevelAwarder levelAwarder)
        {
            if (levelAwarder == null) 
                throw new ArgumentNullException(nameof(levelAwarder));

            _levelAwarder = levelAwarder;

            _levelAwarder.LevelRewardAwarded += UpdateCurrentReward;
        }

        public void Dispose()
        {
            _levelAwarder.LevelRewardAwarded -= UpdateCurrentReward;
        }

        private void UpdateCurrentReward(int reward)
        {
           if (reward <= 0)
                throw new ArgumentOutOfRangeException(nameof(reward));

            _text.text = $"+{reward}";
        }
    }
}
