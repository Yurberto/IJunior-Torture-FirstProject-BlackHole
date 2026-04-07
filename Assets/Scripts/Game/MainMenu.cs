using Assets.Scripts.Game.LevelSystem;
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
        private LevelSpawner _levelSpawner;

        public void Init(LevelStarter levelStarter, LevelSpawner levelSpawner)
        {
            if (levelStarter == null)
                throw new ArgumentNullException(nameof(levelStarter));
            if (levelSpawner == null)
                throw new ArgumentException(nameof(levelSpawner));

            _levelStarter = levelStarter;
            _levelSpawner = levelSpawner;
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
            _levelStarter.StartLevel();
            _levelSpawner.SpawnCurrentLevel();
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
