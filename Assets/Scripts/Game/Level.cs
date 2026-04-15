using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Button _openPause;

        [SerializeField] private CanvasSwitcher _canvasSwitcher;

        private void OnEnable()
        {
            _openPause.onClick.AddListener(OpenPause);
        }

        private void OnDisable()
        {
            _openPause.onClick.RemoveListener(OpenPause);
        }

        private void OpenPause()
        {
            _canvasSwitcher.CloseLevel();
            _canvasSwitcher.OpenPause();
        }
    }
}
