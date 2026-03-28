using Assets.Scripts.AbilitySystem;
using Assets.Scripts.AbilitySystem.ScriptableObjects;
using Assets.Scripts.Game.LevelSystem;
using Assets.Scripts.Game.LevelSystem.ScriptableObjects;
using Assets.Scripts.Game.LevelSystem.Time;
using Assets.Scripts.Game.Time;
using Assets.Scripts.Hole;
using Assets.Scripts.Hole.Scale;
using UnityEngine;
using YG;

namespace Assets.Scripts.Game
{
    public class Bootstrapper : MonoBehaviour
    {
        [Header("Core")]
        [SerializeField] private CanvasSwitcher _canvasSwitcher;
        [SerializeField] private MainMenu _mainMenu;

        [Header("Ability")]
        [SerializeField] private BaseAbilityStats _startSizeBaseStats;
        [SerializeField] private BaseAbilityStats _scaleBaseStats;
        [SerializeField] private BaseAbilityStats _moneyBaseStats;

        [Header("Hole")]
        [SerializeField] private HoleScalerView _holeScalerView;
        [SerializeField] private HoleMover _holeMover;

        [Header("Absorbing")]
        [SerializeField] private AbsorbSetting _absorbSetting;
        [SerializeField] private Absorber _absorber;
        [SerializeField] private AbsorbBar _absorbBar;

        [Header("LevelSystem")]
        [SerializeField] private LevelConfigsHub _levelConfigsHub;

        [Header("Timer")]
        [SerializeField] private LevelTimerView _levelTimerView;

        private GameHoleScaler _gameHoleScaler;
        private LevelHoleScaler _levelHoleScaler;

        private AbsorbHandler _absorbHandler;

        private Ability _startSize;
        private Ability _scale;
        private Ability _money;

        private TimerService _timerService;

        private LevelSpawner _levelSpawner;

        private LevelTimer _levelTimer;
        private LevelStarter _levelStarter;
        private LevelFinisher _levelFinisher;
        private LevelResultTracker _levelResultTracker;

        private void Awake()
        {
            YG2.StickyAdActivity(true);

            _startSize = new Ability(_startSizeBaseStats);
            _scale = new Ability(_scaleBaseStats);
            _money = new Ability(_moneyBaseStats);

            _absorbHandler = new AbsorbHandler(_absorbSetting);
            _absorber.Init(_absorbHandler);
            _absorbBar.Init(_absorbHandler);

            _gameHoleScaler = new GameHoleScaler(_startSize);
            _levelHoleScaler = new LevelHoleScaler(_startSize, _scale, _absorbHandler);
            _holeScalerView.Init(_gameHoleScaler, _levelHoleScaler);
            _holeScalerView.Subscribe();

            _timerService = new TimerService();
            _levelTimerView.Init(_timerService);

            if (YG2.saves.IsFirstLaunch)
                YG2.saves.OnFirstLaunch();

            _levelConfigsHub.Init(YG2.saves.CurrentLevel);
            _levelSpawner = new LevelSpawner(_levelConfigsHub);

            _levelTimer = new LevelTimer(_timerService);
            _levelFinisher = new LevelFinisher(_canvasSwitcher);
            _levelResultTracker = new LevelResultTracker(_absorber, _levelTimer);
            _levelStarter = new LevelStarter(_canvasSwitcher, _levelConfigsHub, _levelTimer, _levelResultTracker, _levelFinisher, _holeMover, _absorbBar, _levelHoleScaler);
            _mainMenu.Init(_levelStarter);
            _mainMenu.Opened += OnMenuOpened;

            _canvasSwitcher.OpenMainMenu();
        }

        private void OnApplicationQuit()
        {
            YG2.SaveProgress();

            _holeScalerView.UnSubscribe();

            _mainMenu.Opened -= OnMenuOpened;
        }

        private void OnMenuOpened()
        {
            _levelSpawner.SpawnCurrentLevel();
        }
    }
}
