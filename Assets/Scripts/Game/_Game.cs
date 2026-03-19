using Assets.Scripts.Game.LevelSystem;
using System;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class _Game : MonoBehaviour
    {
        [SerializeField] private GameEvents _gameEvents;
        [SerializeField] private CanvasManager _canvasManager;
        [SerializeField] private LevelHub _levelHub;

        private LevelStarter _levelStarter;

        public void Activate()
        {
            Debug.Log("Activate_Game");

            _canvasManager.OpenMainMenu();
        }

        public void Init(LevelStarter levelStarter)
        {
            if (levelStarter == null)
                throw new ArgumentNullException(nameof(levelStarter));

            _levelStarter = levelStarter;
        }

        private void OnEnable()
        {
            Debug.Log("OnEnable_Game");

            _gameEvents.StartLevelButtonClicked += StartLevel;
            _gameEvents.OpenSettingsButtonClicked += OpenSettings;
            _gameEvents.OpenShopButtonClicked += OpenShop;
        }

        private void OnDisable()
        {
            Debug.Log("OnDisable_Game");

            _gameEvents.StartLevelButtonClicked -= StartLevel;
            _gameEvents.OpenSettingsButtonClicked -= OpenSettings;
            _gameEvents.OpenShopButtonClicked -= OpenShop;
        }

        private void StartLevel()
        {
            Debug.Log("StartLevel_Game");
            _canvasManager.CloseMainMenu();
            _canvasManager.OpenLevel();

            _levelStarter.Start(_levelHub.GetCurrent());
        }

        private void OpenSettings()
        {
            Debug.Log("OpenSettings_Game");

            _canvasManager.OpenSettings();
        }

        private void OpenShop()
        {

        }
    }
}
