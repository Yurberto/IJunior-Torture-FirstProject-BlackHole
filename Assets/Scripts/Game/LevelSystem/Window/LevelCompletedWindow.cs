using Assets.Scripts.Game.LevelSystem.Award;
using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Assets.Scripts.Game.LevelSystem.Window
{
    public class LevelCompletedWindow : MonoBehaviour
    {
        [SerializeField] private Button _backToMenu;
        [SerializeField] private Button _watchRewardAd;

        [SerializeField] private CanvasSwitcher _canvasSwitcher;

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
            _canvasSwitcher.CloseLevelCompleted();
            _canvasSwitcher.OpenMainMenu();
        }

        private void WatchRevardAd()
        {
            YG2.RewardedAdvShow(RewardTypes.CoinsMultiply);
            YG2.onCloseRewardedAdv += OnCloseAdv;
        }

        private void OnCloseAdv()
        {

        }
    }
}
