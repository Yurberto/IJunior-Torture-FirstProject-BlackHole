using Assets.Scripts.Audio;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    public class Pause : MonoBehaviour
    {
        [SerializeField] private Slider _masterVolume;
        [SerializeField] private Slider _musicVolume;
        [SerializeField] private Slider _sfxVolume;

        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private AudioGroupNames _audioGroupNames;

        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _backToMenuButton;

        [SerializeField] private CanvasSwitcher _canvasSwitcher;

        public event Action BackToMenuPressed;

        private void OnEnable()
        {
            Time.timeScale = 0;

            _closeButton.onClick.AddListener(Continue);
            _continueButton.onClick.AddListener(Continue);
            _backToMenuButton.onClick.AddListener(BackToMenu);

            Subscribe();
        }

        private void OnDisable()
        {
            Time.timeScale = 1;

            _closeButton.onClick.RemoveListener(Continue);
            _continueButton.onClick.RemoveListener(Continue);
            _backToMenuButton.onClick.RemoveListener(BackToMenu);

            UnSubscribe();
        }

        private void Subscribe()
        {
            _masterVolume.onValueChanged.AddListener(UpdateMasterVolume);
            _musicVolume.onValueChanged.AddListener(UpdateMusicVolume);
            _sfxVolume.onValueChanged.AddListener(UpdateSFXVolume);
        }

        private void UnSubscribe()
        {
            _masterVolume.onValueChanged.RemoveListener(UpdateMasterVolume);
            _musicVolume.onValueChanged.RemoveListener(UpdateMusicVolume);
            _sfxVolume.onValueChanged.RemoveListener(UpdateSFXVolume);
        }

        private void Continue()
        {
            _canvasSwitcher.ClosePause();
            _canvasSwitcher.OpenLevel();
        }

        private void BackToMenu()
        {
            _canvasSwitcher.ClosePause();
            _canvasSwitcher.OpenMainMenu();

            BackToMenuPressed?.Invoke();
        }

        private void UpdateMasterVolume(float value)
        {
            if (value > 1 || value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _audioMixer.SetFloat(_audioGroupNames.Master, value.ToDecibel());
        }

        private void UpdateMusicVolume(float value)
        {
            if (value > 1 || value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _audioMixer.SetFloat(_audioGroupNames.Music, value.ToDecibel());
        }

        private void UpdateSFXVolume(float value)
        {
            if (value > 1 || value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _audioMixer.SetFloat(_audioGroupNames.SFX, value.ToDecibel());
        }
    }
}
