using Assets.Scripts.Audio;
using Assets.Scripts.Game.Interfases;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    public class Settings : MonoBehaviour, GameCanvas
    {
        [SerializeField] private Button _closeButton;

        [SerializeField] private Slider _masterVolume;
        [SerializeField] private Slider _musicVolume;
        [SerializeField] private Slider _sfxVolume;

        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private AudioGroupNames _audioGroupNames;

        private GameCanvas _previous;

        private void Awake()
        {
            UpdateMasterVolume(_masterVolume.value);
            UpdateMusicVolume(_musicVolume.value);
            UpdateSFXVolume(_sfxVolume.value);
        }

        public void SetPrevious(GameCanvas previous)
        {
            UnityEngine.Debug.Log($"Settings_SetPrevious");
            if (previous == null)
                throw new ArgumentNullException(nameof(previous));

            _previous = previous;
        }

        public void Open()
        {
            UnityEngine.Debug.Log($"Settings_Open");
            if (_previous == null)
                throw new ArgumentNullException(nameof(_previous));

            gameObject.SetActive(true);

            _closeButton.onClick.AddListener(BackToPrevious);
            Subscribe();
        }

        public void BackToPrevious()
        {
            UnityEngine.Debug.Log($"Settings_BackToPrevious");
            _closeButton.onClick.RemoveListener(BackToPrevious);
            UnSubscribe();

            gameObject.SetActive(false);
            _previous.Open();
            _previous = null;
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
