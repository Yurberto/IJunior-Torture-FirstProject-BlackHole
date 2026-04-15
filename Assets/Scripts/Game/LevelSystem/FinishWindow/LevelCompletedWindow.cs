using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Assets.Scripts.Game.LevelSystem
{
    public class LevelCompletedWindow : MonoBehaviour
    {
        [SerializeField] private Button _backToMenu;
        [SerializeField] private Button _watchRewardAd;

        [SerializeField] private CanvasSwitcher _canvasSwitcher;
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

        private void OnEnable()
        {
            _backToMenu.onClick.AddListener(OnBackToMenuButtonClicked);
            _watchRewardAd.onClick.AddListener(WatchRevardAd);
        }

        private void OnDisable()
        {
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
            _canvasSwitcher.CloseLevelCompletedWindow();
            _canvasSwitcher.OpenMainMenu();

            _levelSpawner.DestroyLastSpawned();
            _levelConfigsHub.SwitchToNextLevel();
        }
    }
}
