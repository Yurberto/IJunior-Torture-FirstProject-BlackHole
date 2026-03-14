using Assets.Scripts.Game.LevelGamplay;
using System;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class _Game : MonoBehaviour
    {
        [SerializeField] private GameEvents _gameEvents;
        [SerializeField] private CanvasManager _canvasManager;
        [SerializeField] private LevelSystem _levelSystem;

        public void Activate()
        {
            Debug.Log("Activate_Game");

            _canvasManager.OpenMainMenu();
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
