using Assets.Scripts.Game.Time;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Test
{
    public class TimerViewTest : MonoBehaviour
    {
        [SerializeField] private int _time;

        private TimerService _timerService;

        private void Awake()
        {
            _timerService = new TimerService();
            _timerService.Start(_time);
        }

        private void OnEnable()
        {
            _timerService.Tick += OnTick;
            _timerService.Finished += OnCompleted;
        }

        private void OnDisable()
        {
            _timerService.Tick -= OnTick;
            _timerService.Finished -= OnCompleted;
        }

        private void OnTick(int currentTime)
        {
            Debug.Log(currentTime);
        }
        private void OnCompleted()
        {
            Debug.Log("Completed");
        }
    }
}
