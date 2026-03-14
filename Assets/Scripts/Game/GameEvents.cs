using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    public class GameEvents : MonoBehaviour
    {
        [SerializeField] private Button _startLevelButton;
        [SerializeField] private Button _openSettingsButton;
        [SerializeField] private Button _openShopButton;

        public event Action StartLevelButtonClicked;
        public event Action OpenSettingsButtonClicked;
        public event Action OpenShopButtonClicked;

        private void OnEnable()
        {
            _startLevelButton.onClick.AddListener(StartLevelInvoke);
            _openSettingsButton.onClick.AddListener(OpenSettingsInvoke);
            _openShopButton.onClick.AddListener(OpenShopInvoke);
        }

        private void OnDisable()
        {
            _startLevelButton.onClick.RemoveListener(StartLevelInvoke);
            _openSettingsButton.onClick.RemoveListener(OpenSettingsInvoke);
            _openShopButton.onClick.RemoveListener(OpenShopInvoke);
        }

        private void StartLevelInvoke()
        {
            StartLevelButtonClicked?.Invoke();
        }

        private void OpenSettingsInvoke()
        {
            OpenSettingsButtonClicked?.Invoke();
        }

        private void OpenShopInvoke()
        {
            OpenShopButtonClicked?.Invoke();
        }
    }
}
