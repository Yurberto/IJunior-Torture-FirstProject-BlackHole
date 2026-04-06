using Assets.Scripts.AbilitySystem;
using Assets.Scripts.Game.LevelSystem;
using Assets.Scripts.Game.LevelSystem.Award;
using Assets.Scripts.Game.LevelSystem.Time;
using Assets.Scripts.Game.Time;
using Assets.Scripts.Hole;
using Assets.Scripts.Hole.Scale;
using Assets.Scripts.WalletSystem;
using UnityEngine;
using YG;

namespace Assets.Scripts.Game
{
    public class Bootstrapper : MonoBehaviour
    {
        [Header("Core")]
        [SerializeField] private CanvasSwitcher _canvasSwitcher;
        [SerializeField] private MainMenu _mainMenu;

        [Header("Camera")]
        [SerializeField] private TargetFollower _targetFollower;

        [Header("AbilityStats")]
        [SerializeField] private BaseAbilityStats _startSizeBaseStats;
        [SerializeField] private BaseAbilityStats _scaleBaseStats;
        [SerializeField] private BaseAbilityStats _moneyBaseStats;

        [Header("AbilityUpgradeView")]
        [SerializeField] private AbilityUpgraderView _startSizeUpgraderView;
        [SerializeField] private AbilityUpgraderView _scaleUpgraderView;
        [SerializeField] private AbilityUpgraderView _moneyUpgraderView;

        [Header("AbilityView")]
        [SerializeField] private AbilityView _startSizeView;
        [SerializeField] private AbilityView _scaleView;
        [SerializeField] private AbilityView _moneyView;

        [Header("Hole")]
        [SerializeField] private HoleScalerView _holeScalerView;
        [SerializeField] private HoleMover _holeMover;

        [Header("Absorbing")]
        [SerializeField] private AbsorbSetting _absorbSetting;
        [SerializeField] private Absorber _absorber;
        [SerializeField] private AbsorbBar _absorbBar;

        [Header("LevelSystem")]
        [SerializeField] private LevelConfigsHub _levelConfigsHub;

        [SerializeField] private LevelRewardView _levelRewardView;
        [SerializeField] private CurrentLevelNumberView _currentLevelView;
        [SerializeField] private LevelCompletedWindow _levelCompletedWindow;
        [SerializeField] private LevelFailedWindow _levelFailedWindow;

        [Header("Wallet")]
        [SerializeField] private WalletView _walletView;

        [Header("Timer")]
        [SerializeField] private LevelTimerView _levelTimerView;

        private GameHoleScaler _gameHoleScaler;
        private LevelHoleScaler _levelHoleScaler;

        private AbsorbHandler _absorbHandler;

        private Ability _startSize;
        private Ability _scale;
        private Ability _money;

        private AbilityUpgrader _startSizeUpgrader;
        private AbilityUpgrader _scaleUpgrader;
        private AbilityUpgrader _moneyUpgrader;

        private AbilityUpgradePresenter _startSizeUpgradePresenter;
        private AbilityUpgradePresenter _scaleUpgradePresenter;
        private AbilityUpgradePresenter _moneyUpgradePresenter;

        private TimerService _timerService;

        private LevelSpawner _levelSpawner;
        private LevelAwarder _levelAwarder;

        private LevelTimer _levelTimer;
        private LevelStarter _levelStarter;
        private LevelFinisher _levelFinisher;
        private LevelResultTracker _levelResultTracker;
        private LevelAdRewarder _levelAdRewarder;

        private Wallet _wallet;

        private void Awake()
        {
            YG2.StickyAdActivity(true);

            bool isFirstLaunch = YG2.saves.IsFirstLaunch;

            if (isFirstLaunch)
                YG2.saves.OnFirstLaunch();

            _levelConfigsHub.Init(YG2.saves.CurrentLevel);
            _wallet = new Wallet(YG2.saves.MoneyCount);
            //_wallet = new Wallet(10);

            _startSize = new Ability(_startSizeBaseStats, YG2.saves.StartSizeInfo, isFirstLaunch);
            _scale = new Ability(_scaleBaseStats, YG2.saves.ScaleInfo, isFirstLaunch);
            _money = new Ability(_moneyBaseStats, YG2.saves.MoneyInfo, isFirstLaunch);

            _startSizeView.Init(_startSize);
            _scaleView.Init(_scale);
            _moneyView.Init(_money);

            _startSizeUpgrader = new AbilityUpgrader(_startSize, _wallet);
            _scaleUpgrader = new AbilityUpgrader(_scale, _wallet);
            _moneyUpgrader = new AbilityUpgrader(_money, _wallet);

            _startSizeUpgradePresenter = new AbilityUpgradePresenter(_startSizeUpgrader, _startSizeUpgraderView);
            _scaleUpgradePresenter = new AbilityUpgradePresenter(_scaleUpgrader, _scaleUpgraderView);
            _moneyUpgradePresenter = new AbilityUpgradePresenter(_moneyUpgrader, _moneyUpgraderView);

            _startSizeUpgraderView.Subscibe();
            _scaleUpgraderView.Subscibe();
            _moneyUpgraderView.Subscibe();

            _absorbHandler = new AbsorbHandler(_absorbSetting);
            _absorber.Init(_absorbHandler);
            _absorbBar.Init(_absorbHandler);

            _gameHoleScaler = new GameHoleScaler(_startSize);
            _levelHoleScaler = new LevelHoleScaler(_startSize, _scale, _absorbHandler);
            _holeScalerView.Init(_gameHoleScaler, _levelHoleScaler, _mainMenu);
            _holeScalerView.Subscribe();

            _timerService = new TimerService();
            _levelTimerView.Init(_timerService);

            _levelSpawner = new LevelSpawner(_levelConfigsHub);
            _levelAwarder = new LevelAwarder(_wallet, _money);

            _levelTimer = new LevelTimer(_timerService);
            _levelFinisher = new LevelFinisher(_canvasSwitcher, _levelSpawner, _levelConfigsHub, _levelAwarder);
            _levelResultTracker = new LevelResultTracker(_absorber, _levelTimer);
            _levelAdRewarder = new LevelAdRewarder(_money, _wallet, _levelConfigsHub);

            _levelStarter = new LevelStarter(_canvasSwitcher, _levelConfigsHub, _levelSpawner, _levelTimer, _levelResultTracker, _levelFinisher, _holeMover, _absorbHandler, _absorbBar, _levelHoleScaler);
            _mainMenu.Init(_levelStarter);

            _walletView.Init(_wallet);
            _levelRewardView.Init(_levelAwarder);
            _currentLevelView.Init(_levelConfigsHub);

            _levelCompletedWindow.Init(_levelAdRewarder);
            _levelFailedWindow.Init(_levelSpawner);

            _targetFollower.Init(_holeScalerView);
            _holeMover.Init(_holeScalerView);

            _canvasSwitcher.OpenMainMenu();
        }

        private void OnApplicationQuit()
        {
            YG2.SaveProgress();

            _startSizeView.Dispose();
            _scaleView.Dispose();
            _moneyView.Dispose();

            _startSizeUpgrader.Dispose();
            _scaleUpgrader.Dispose();
            _moneyUpgrader.Dispose();

            _startSizeUpgradePresenter.Dispose();
            _scaleUpgradePresenter.Dispose();
            _moneyUpgradePresenter.Dispose();

            _startSizeUpgraderView.UnSubscribe();
            _scaleUpgraderView.UnSubscribe();
            _moneyUpgraderView.UnSubscribe();

            _gameHoleScaler.Dispose();
            _holeScalerView.UnSubscribe();
            _holeMover.StopMoving();

            _levelRewardView.Dispose();
            _currentLevelView.Dispose();

            _targetFollower.Dispose();
            _holeMover.Dispose();
        }
    }
}
