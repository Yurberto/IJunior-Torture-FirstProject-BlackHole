using System;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class CanvasSwitcher : MonoBehaviour
    {
        [Header("Core")]
        [SerializeField] private Canvas _mainMenu;
        [SerializeField] private Canvas _setting;
        [SerializeField] private Canvas _level;
        [Header("Level")]
        [SerializeField] private Canvas _levelFailed;
        [SerializeField] private Canvas _levelCompleted;

        public void OpenMainMenu()
        {
            _mainMenu.gameObject.SetActive(true);
        }
        
        public void OpenSettings()
        {
            _setting.gameObject.SetActive(true);
        }

        public void OpenLevel()
        {
            _level.gameObject.SetActive(true);
        }

        public void OpenLevelFailedWindow()
        {
            _levelFailed.gameObject.SetActive(true);
        }
        public void OpenLevelCompletedWindow()
        {
            _levelCompleted.gameObject.SetActive(true);
        }

        public void CloseMainMenu()
        {
            _mainMenu.gameObject.SetActive(false);
        }

        public void CloseSetting()
        {
            _setting.gameObject.SetActive(false);
        }

        public void CloseLevel()
        {
            _level.gameObject.SetActive(false);
        }

        public void CloseLevelFailed()
        {
            _levelFailed.gameObject.SetActive(false);
        }
        public void CloseLevelCompleted()
        {
            _levelCompleted.gameObject.SetActive(false);
        }
    }
}
