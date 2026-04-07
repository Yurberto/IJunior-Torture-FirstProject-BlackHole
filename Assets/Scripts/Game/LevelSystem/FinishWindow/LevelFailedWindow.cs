using Assets.Scripts.Game.ScriptableObjects;
using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Assets.Scripts.Game.LevelSystem
{
    public class LevelFailedWindow : MonoBehaviour
    {
        [SerializeField] private Button _backToMenu;
        [SerializeField] private Button _watchRewardAd;

        [SerializeField] private CanvasSwitcher _canvasSwitcher;

        private LevelSpawner _levelSpawner;
        private AdAwarder _adAwarder;

        public void Init(LevelSpawner levelSpawner, AdAwarder adAwarder)
        {
            if (levelSpawner == null) 
                throw new ArgumentNullException(nameof(levelSpawner));
            if (adAwarder == null)
                throw new ArgumentNullException(nameof(adAwarder));

            _levelSpawner = levelSpawner;
            _adAwarder = adAwarder;
        }

        private void OnEnable()
        {
            _backToMenu.onClick.AddListener(BackToMenu);
            _watchRewardAd.onClick.AddListener(WatchRevardAd);
        }

        private void OnDisable()
        {
            _backToMenu.onClick.RemoveListener(BackToMenu);
            _watchRewardAd.onClick.RemoveListener(WatchRevardAd);
        }

        private void BackToMenu()
        {
            _levelSpawner.DestroyLastSpawned();

            _canvasSwitcher.CloseLevelFailed();
            _canvasSwitcher.OpenMainMenu();
        }

        private void WatchRevardAd()
        {
            YG2.RewardedAdvShow(RewardTypes.CoinsAdd);
            YG2.onCloseRewardedAdv += OnCloseAdv;
        }

        private void OnCloseAdv()
        {
            YG2.onCloseRewardedAdv -= OnCloseAdv;

            _adAwarder.AwardAddMoney();
            BackToMenu();
        }
    }
}
