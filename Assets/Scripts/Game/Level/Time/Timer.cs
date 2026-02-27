using Assets.Scripts.Utils;
using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class Timer : MonoBehaviour
    {
        private const int MaxTime = 99;

        [SerializeField] private TextMeshProUGUI _text;

        private TimerService _timerService;

        public void Init()
        {
            _timerService = new TimerService();
        }

        public void StartTimer(int time)
        {
            if (_timerService == null)
                throw new ArgumentNullException(nameof(_timerService));
            if (time <= 0 || time > MaxTime)
                throw new ArgumentOutOfRangeException(nameof(time));

            SetTimeText(time);

            _timerService.Start(time);
            _timerService.Tick += SetTimeText;
            _timerService.Completed += StopTicking;
        }

        private void SetTimeText(int time)
        {
            _text.text = time.ToString();
        }

        private void StopTicking()
        {
            _timerService.Stop();
            _timerService.Tick -= SetTimeText;
            _timerService.Completed -= StopTicking;
        }
    }
}
