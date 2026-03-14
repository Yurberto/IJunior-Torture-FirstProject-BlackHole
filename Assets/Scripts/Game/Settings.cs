using Assets.Scripts.Audio;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Button _closeButton;

        [SerializeField] private Slider _masterVolume;
        [SerializeField] private Slider _musicVolume;
        [SerializeField] private Slider _sfxVolume;

        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private AudioGroupNames _audioGroupNames;

        private void Awake()
        {
            UpdateMasterVolume(_masterVolume.value);
            UpdateMusicVolume(_musicVolume.value);
            UpdateSFXVolume(_sfxVolume.value);
        }

        private void OnEnable()
        {
            Debug.Log("OnEnable_Settings");
            _closeButton.onClick.AddListener(Close);

            Subscribe();
        }

        private void OnDisable()
        {
            Debug.Log("OnDisable_Settings");
            _closeButton.onClick.RemoveListener(Close);

            UnSubscribe();
        }

        private void Close()
        {
            Debug.Log("Close_Settings");

            _canvas.gameObject.SetActive(false);
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

            _audioMixer.SetFloat(_audioGroupNames.Master, value.FloatToDecibel());
        }

        private void UpdateMusicVolume(float value)
        {
            if (value > 1 || value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _audioMixer.SetFloat(_audioGroupNames.Music, value.FloatToDecibel());
        }

        private void UpdateSFXVolume(float value)
        {
            if (value > 1 || value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _audioMixer.SetFloat(_audioGroupNames.SFX, value.FloatToDecibel());
        }
    }
}
