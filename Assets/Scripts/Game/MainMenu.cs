using Assets.Scripts.Game.Interfases;
using Assets.Scripts.Game.LevelSystem;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    public class MainMenu : MonoBehaviour, GameCanvas
    {
        [SerializeField] private Settings _settings;

        [Space]

        [SerializeField] private Button _startLevelButton;
        [SerializeField] private Button _openSettingsButton;
        [SerializeField] private Button _openShopButton;

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

        public void Open()
        {
            gameObject.SetActive(true);

            _startLevelButton.onClick.AddListener(StartLevel);
            _openSettingsButton.onClick.AddListener(OpenSettings);
            _openShopButton.onClick.AddListener(OpenShop);

            Opened?.Invoke();
        }

        public void Close()
        {
            _startLevelButton.onClick.RemoveListener(StartLevel);
            _openSettingsButton.onClick.RemoveListener(OpenSettings);
            _openShopButton.onClick.RemoveListener(OpenShop);

            gameObject.SetActive(false);

            Closed?.Invoke();
        }

        private void StartLevel()
        {
            Close();
            _levelStarter.StartLevel();
            _levelSpawner.SpawnCurrentLevel();
        }

        private void OpenSettings()
        {
            UnityEngine.Debug.Log($"MainMenu_OpenSettings");
            Close();
            _settings.SetPrevious(this);
            _settings.Open();
        }

        private void OpenShop()
        {
            Close();
        }
    }
}
