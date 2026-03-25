using Assets.Scripts.AbilitySystem;
using Assets.Scripts.AbilitySystem.ScriptableObjects;
using Assets.Scripts.Game.LevelSystem.Time;
using Assets.Scripts.Game.Time;
using Assets.Scripts.Hole;
using Assets.Scripts.Hole.Scale;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private CanvasSwitcher _canvasSwitcher;

        [Header("Ability")]
        [SerializeField] private BaseAbilityStats _startSizeBaseStats;
        [SerializeField] private BaseAbilityStats _scaleBaseStats;
        [SerializeField] private BaseAbilityStats _moneyBaseStats;

        [Header("Hole")]
        [SerializeField] private HoleScalerView _holeScalerView;

        [Header("Absorbing")]
        [SerializeField] private AbsorbSetting _absorbSetting;
        [SerializeField] private Absorber _absorber;
        [SerializeField] private AbsorbBar _absorbBar;

        [Header("Timer")]
        [SerializeField] private LevelTimerView _levelTimerView;

        private GameHoleScaler _gameHoleScaler;
        private LevelHoleScaler _levelHoleScaler;

        private AbsorbHandler _absorbHandler;

        private Ability _startSize;
        private Ability _scale;
        private Ability _money;

        private TimerService _timerService;

        private void Awake()
        {
            _startSize = new Ability(_startSizeBaseStats);
            _scale = new Ability(_scaleBaseStats);
            _money = new Ability(_moneyBaseStats);

            _absorbHandler = new AbsorbHandler(_absorbSetting);
            _absorber.Init(_absorbHandler);
            _absorbBar.Init(_absorbHandler);

            _gameHoleScaler = new GameHoleScaler(_startSize);
            _levelHoleScaler = new LevelHoleScaler(_absorbHandler);
            _holeScalerView.Init(_gameHoleScaler, _levelHoleScaler);

            _timerService = new TimerService();
            _levelTimerView.Init(_timerService);

            _canvasSwitcher.OpenMainMenu();
        }
    }
}
