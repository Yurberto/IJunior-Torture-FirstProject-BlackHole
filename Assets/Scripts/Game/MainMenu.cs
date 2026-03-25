using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _startLevelButton;
        [SerializeField] private Button _openSettingsButton;
        [SerializeField] private Button _openShopButton;
        [Space]
        [SerializeField] private CanvasSwitcher _canvasSwitcher;

        private void OnEnable()
        {
            _startLevelButton.onClick.AddListener(StartLevel);
            _openSettingsButton.onClick.AddListener(OpenSettings);
            _openShopButton.onClick.AddListener(OpenShop);
        }

        private void OnDisable()
        {
            _startLevelButton.onClick.RemoveListener(StartLevel);
            _openSettingsButton.onClick.RemoveListener(OpenSettings);
            _openShopButton.onClick.RemoveListener(OpenShop);
        }

        private void StartLevel()
        {
            _canvasSwitcher.CloseMainMenu();
            _canvasSwitcher.OpenLevel();
        }

        private void OpenSettings()
        {
            _canvasSwitcher.CloseMainMenu();
            _canvasSwitcher.OpenSettings();
        }

        private void OpenShop()
        {
            _canvasSwitcher.CloseMainMenu();
        }
    }
}
