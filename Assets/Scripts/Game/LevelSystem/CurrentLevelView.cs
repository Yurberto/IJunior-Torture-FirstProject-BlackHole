using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Game.LevelSystem
{
    public class CurrentLevelView : MonoBehaviour
    {
        private const string Beginning = "Level";

        [SerializeField] private TextMeshProUGUI _text;

        private LevelConfigsHub _levelConfigsHub;

        public void Init(LevelConfigsHub levelConfigsHub)
        {
            if (levelConfigsHub == null)
                throw new ArgumentNullException(nameof(levelConfigsHub));

            _levelConfigsHub = levelConfigsHub;

            _levelConfigsHub.IndexUpdated += UpdateIndexView;
            UpdateIndexView();
        }

        public void Dispose()
        {
            _levelConfigsHub.IndexUpdated -= UpdateIndexView;

            Debug.Log("OnDisable_CurrentLevelView");
        }

        private void UpdateIndexView()
        {
            _text.text = $"{Beginning} {_levelConfigsHub.CurrentLevelIndex + 1}";

        }
    }
}
