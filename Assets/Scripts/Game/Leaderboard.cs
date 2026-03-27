using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    public class Leaderboard : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;

        [SerializeField] private CanvasSwitcher _canvasSwitcher;

        private void OnEnable()
        {
            if (_closeButton != null)
                _closeButton.onClick.AddListener(Close);
        }

        private void OnDisable()
        {
            if (_closeButton != null)
                _closeButton.onClick.RemoveListener(Close);
        }

        private void Close()
        {
            _canvasSwitcher.CloseLeaderboard();
            _canvasSwitcher.OpenMainMenu();
        }
    }
}
