using UnityEngine;

namespace Assets.Scripts.Game
{
    public class CanvasSwitcher : MonoBehaviour
    {
        [Header("Core")]
        [SerializeField] private Canvas _mainMenu;
        [SerializeField] private Canvas _setting;
        [Header("Level")]
        [SerializeField] private Canvas _level;
        [SerializeField] private Canvas _pause;
        [SerializeField] private Canvas _levelFailed;
        [SerializeField] private Canvas _levelCompleted;

        public void OpenMainMenu()
        {
            _mainMenu.gameObject.SetActive(true);
        }
        public void CloseMainMenu()
        {
            _mainMenu.gameObject.SetActive(false);
        }

        public void OpenSettings()
        {
            _setting.gameObject.SetActive(true);
        }
        public void CloseSetting()
        {
            _setting.gameObject.SetActive(false);
        }

        public void OpenLevel()
        {
            _level.gameObject.SetActive(true);
        }
        public void CloseLevel()
        {
            _level.gameObject.SetActive(false);
        }

        public void OpenPause()
        {
            _pause.gameObject.SetActive(true);
        }
        public void ClosePause()
        {
            _pause.gameObject.SetActive(false);
        }

        public void OpenLevelFailedWindow()
        {
            _levelFailed.gameObject.SetActive(true);
        }
        public void CloseLevelFailedWindow()
        {
            _levelFailed.gameObject.SetActive(false);
        }

        public void OpenLevelCompletedWindow()
        {
            _levelCompleted.gameObject.SetActive(true);
        }
        public void CloseLevelCompletedWindow()
        {
            _levelCompleted.gameObject.SetActive(false);
        }
    }
}
