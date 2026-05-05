using TMPro;
using UnityEngine;

namespace Assets.Scripts.Game.LevelSystem
{
    public class CurrentLevelNumberView : MonoBehaviour
    {
        private const string Beginning = "Level";

        [SerializeField] private LevelConfigsHub _levelConfigsHub;
        [SerializeField] private TextMeshProUGUI _text;

        private void OnEnable()
        {
            UpdateIndexView();

            _levelConfigsHub.IndexUpdated += UpdateIndexView;
        }

        private void OnDisable()
        {
            _levelConfigsHub.IndexUpdated -= UpdateIndexView;
        }

        private void UpdateIndexView()
        {
            _text.text = $"{Beginning} {_levelConfigsHub.CurrentLevelIndex + 1}";
        }
    }
}
