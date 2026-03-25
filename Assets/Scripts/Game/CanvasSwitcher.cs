using System;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class CanvasSwitcher : MonoBehaviour
    {
        [SerializeField] private Canvas _mainMenu;
        [SerializeField] private Canvas _setting;
        [SerializeField] private Canvas _level;

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
    }
}
