using Assets.Scripts.Game.Time;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game.LevelSystem.Time
{
    public class LevelTimerView : MonoBehaviour
    {
        [SerializeField] private Image _fillArea;
        [SerializeField] private TextMeshProUGUI _text;

        private int _startedTime = 0;
        private TimerService _timerService;

        public void Init(TimerService timerService)
        {
            if (timerService == null) 
                throw new ArgumentNullException(nameof(timerService));

            _timerService = timerService;
        }

        private void OnEnable()
        {
            _timerService.Started += OnStarted;
            _timerService.Tick += UpdateInfo;
        }

        private void OnDisable()
        {
            _timerService.Started += OnStarted;
            _timerService.Tick += UpdateInfo;
        }

        private void OnStarted(int startedTime)
        {
            _startedTime = startedTime;
            UpdateInfo(_startedTime);
        }

        private void UpdateInfo(int currentTime)
        {
            _text.text = currentTime.ToString();
            _fillArea.fillAmount = Mathf.Clamp01((float)currentTime /  _startedTime);
        }
    }
}
