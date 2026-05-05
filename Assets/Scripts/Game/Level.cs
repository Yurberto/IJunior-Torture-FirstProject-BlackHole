using Assets.Scripts.Game.Interfases;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    public class Level : MonoBehaviour, GameCanvas
    {
        [SerializeField] private Pause _pause;
        [SerializeField] private Button _openPause;

        public void Open()
        {
            gameObject.SetActive(true);
            _openPause.onClick.AddListener(OpenPause);
        }

        public void Close()
        {
            gameObject.SetActive(false);
            _openPause.onClick.RemoveListener(OpenPause);
        }

        private void OpenPause()
        {
            _pause.Open();
        }
    }
}
