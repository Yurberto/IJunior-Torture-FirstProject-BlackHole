using Assets.Scripts.Audio;
using Assets.Scripts.Game.Interfases;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    public class Pause : MonoBehaviour, GameCanvas
    {
        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private Settings _settings;
        [SerializeField] private Level _level;
        [Space(16)]
        [SerializeField] private Button _closeButton;
        [Space]
        [SerializeField] private Button _backToMenuButton;
        [SerializeField] private Button _openSettingsButton;
        [SerializeField] private Button _continueButton;

        public event Action BackToMenuPressed;

        public void Open()
        {
            Time.timeScale = 0;

            _closeButton.onClick.AddListener(Continue);

            _backToMenuButton.onClick.AddListener(BackToMenu);
            _openSettingsButton.onClick.AddListener(OpenSettings);
            _continueButton.onClick.AddListener(Continue);

            gameObject.SetActive(true);
        }

        private void Close()
        {
            _closeButton.onClick.RemoveListener(Continue);

            _backToMenuButton.onClick.RemoveListener(BackToMenu);
            _openSettingsButton.onClick.RemoveListener(OpenSettings);
            _continueButton.onClick.RemoveListener(Continue);

            gameObject.SetActive(false);
        }

        private void BackToMenu()
        {
            Time.timeScale = 1;

            Close();
            _level.Close();
            _mainMenu.Open();

            BackToMenuPressed?.Invoke();
        }

        private void OpenSettings()
        {
            UnityEngine.Debug.Log($"Pause_OpenSettings");
            _settings.SetPrevious(this);
            _settings.Open();
        }

        private void Continue()
        {
            Time.timeScale = 1;

            Close();
        }
    }
}
