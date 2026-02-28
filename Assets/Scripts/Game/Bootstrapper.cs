using Assets.Scripts.AbilityNew;
using Assets.Scripts.AbilityNew.ScriptableObjects;
using Assets.Scripts.Hole;
using Assets.Scripts.Test;
using Assets.Scripts.WalletSystem;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class Bootstrapper : MonoBehaviour
    {
        [Header("Ability")]
        [SerializeField] private BaseAbilityStats _startSizeBaseStats;
        [SerializeField] private BaseAbilityStats _scaleBaseStats;
        [SerializeField] private BaseAbilityStats _moneyBaseStats;
        [Space]
        [SerializeField] private AbilityView _startSizeView;
        [SerializeField] private AbilityView _scaleView;
        [SerializeField] private AbilityView _moneyView;
        [Space]
        [SerializeField] private AbilityUpgraderView _abilityUpgraderView;

        [Header("Hole")]
        [SerializeField] private HoleScaler _holeScaler;
        [SerializeField] private HoleMover _holeMover;
        [SerializeField] private Absorber _absorber;
        [SerializeField] private AbsorbSetting _absorbSetting;

        [Header("Wallet")]
        [SerializeField] private WalletView _walletView;
        [SerializeField] private MoneyAdderTest _moneyAdderTest;

        private AbsorbHandler _absorbHandler;

        private Ability _startSize;
        private Ability _scale;
        private Ability _money;

        private AbilityUpgrader _abilityUpgrader;

        private Wallet _wallet;

        private void Awake()
        {
            _absorbHandler = new AbsorbHandler(_absorbSetting);
            _absorber.Init(_absorbHandler);

            _startSize = new Ability(_startSizeBaseStats);
            _scale = new Ability(_scaleBaseStats);
            _money = new Ability(_moneyBaseStats);

            _startSizeView.Init(_startSize);
            _scaleView.Init(_scale);
            _moneyView.Init(_money);

            _wallet = new Wallet(0);
            _walletView.Init(_wallet);
            _moneyAdderTest.Init(_wallet, _money);

            _abilityUpgrader = new AbilityUpgrader(_startSize, _scale, _money, _wallet);
            _abilityUpgraderView.Init(_abilityUpgrader);

            _holeScaler.Init(_startSize, _scale, _absorbHandler);
            _holeMover.Init();

        }

        private void OnDestroy()
        {
            _abilityUpgraderView.Dispose();
            _holeScaler.Dispose();
        }
    }
}
