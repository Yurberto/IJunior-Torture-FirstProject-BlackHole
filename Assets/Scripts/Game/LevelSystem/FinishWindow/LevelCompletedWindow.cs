using Assets.Scripts.Game.Interfases;
using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Assets.Scripts.Game.LevelSystem
{
    public class LevelCompletedWindow : MonoBehaviour, GameCanvas
    {
        [SerializeField] private MainMenu _mainMenu;
        [Space]
        [SerializeField] private Button _backToMenu;
        [SerializeField] private Button _watchRewardAd;

        [SerializeField] private LevelConfigsHub _levelConfigsHub;

        private AdAwarder _adAwarder;
        private LevelAwarder _levelAwarder;

        private LevelSpawner _levelSpawner;

        public void Init(AdAwarder adAwarder, LevelAwarder levelAwarder, LevelSpawner levelSpawner)
        {
            if (adAwarder == null) 
                throw new ArgumentNullException(nameof(adAwarder));
            if (levelAwarder == null)
                throw new ArgumentNullException(nameof(levelAwarder));
            if (levelSpawner == null)
                throw new ArgumentNullException(nameof(levelSpawner));

            _adAwarder = adAwarder;
            _levelAwarder = levelAwarder;
            _levelSpawner = levelSpawner;
        }

        public void Open()
        {
            gameObject.SetActive(true);
            _backToMenu.onClick.AddListener(OnBackToMenuButtonClicked);
            _watchRewardAd.onClick.AddListener(WatchRevardAd);
        }

        private void Close()
        {
            gameObject.SetActive(false);
            _backToMenu.onClick.RemoveListener(OnBackToMenuButtonClicked);
            _watchRewardAd.onClick.RemoveListener(WatchRevardAd);
        }

        private void OnBackToMenuButtonClicked()
        {
            _levelAwarder.AwardLevelReward(_levelConfigsHub.GetCurrent());
            BackToMenu();
        }

        private void WatchRevardAd()
        {
            YG2.RewardedAdvShow(RewardTypes.CoinsMultiply);
            YG2.onCloseRewardedAdv += OnCloseAdv;
        }

        private void OnCloseAdv()
        {
            YG2.onCloseRewardedAdv -= OnCloseAdv;

            _adAwarder.AwardMultiplyLevelReward(_levelConfigsHub.GetCurrent());
            BackToMenu();
        }

        private void BackToMenu()
        {
            Close();
            _mainMenu.Open();

            _levelSpawner.DestroyLastSpawned();
            _levelConfigsHub.SwitchToNextLevel();
        }
    }
}
