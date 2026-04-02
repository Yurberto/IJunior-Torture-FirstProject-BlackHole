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

        public void Init(LevelSpawner levelSpawner)
        {
            if (levelSpawner == null) 
                throw new ArgumentNullException(nameof(levelSpawner));

            _levelSpawner = levelSpawner;
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
            YG2.RewardedAdvShow(RewardTypes.TimeAdd);
            YG2.onCloseRewardedAdv += OnCloseAdv;
        }

        private void OnCloseAdv()
        {

        }
    }
}
