using Assets.Scripts.Game.LevelSystem;
using Assets.Scripts.Hole.Scale;
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

        private LevelStarter _levelStarter;

        public void Init(LevelStarter levelStarter)
        {
            if (levelStarter == null)
                throw new ArgumentNullException(nameof(levelStarter));

            _levelStarter = levelStarter;
        }

        public event Action Opened;
        public event Action Closed;

        private void OnEnable()
        {
            _startLevelButton.onClick.AddListener(StartLevel);
            _openSettingsButton.onClick.AddListener(OpenSettings);
            _openShopButton.onClick.AddListener(OpenShop);

            Opened?.Invoke();
        }

        private void OnDisable()
        {
            _startLevelButton.onClick.RemoveListener(StartLevel);
            _openSettingsButton.onClick.RemoveListener(OpenSettings);
            _openShopButton.onClick.RemoveListener(OpenShop);

            Closed?.Invoke();
        }

        private void StartLevel()
        {
            _canvasSwitcher.CloseMainMenu();
            _levelStarter.Start();
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
