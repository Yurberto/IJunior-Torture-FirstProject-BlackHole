using Assets.Scripts.Hole;
using Assets.Scripts.Ability;
using Assets.Scripts.Game.ScriptableObjects;
using UnityEngine;
using Assets.Scripts.Test;
using Assets.Scripts.MoneyClasses;
using Assets.Scripts.Game.Level;

namespace Assets.Scripts.Game
{
    public class Bootstrapper : MonoBehaviour
    {
        // Привести все в порядок
        [Header("HoleView")]
        [SerializeField] private HoleScaler _holeScaler;
        [SerializeField] private HoleMover _holeMover;
        [SerializeField] private Absorber _absorber;

        [Header("AbilityView")]
        [SerializeField] private AbilityUpgrader _abilityUpgrader;
        [SerializeField] private AbilityCostView _abilityCostView;
        [SerializeField] private AbilityLevelView _abilityLevelView;

        [Header("MoneyView")]
        [SerializeField] private MoneyView _moneyView;

        [Header("ScriptableObjects")]
        [SerializeField] private DefaultPlayerStats _defaultPlayerStats;
        [SerializeField] private DefaultAbilityCosts _defaultAbilityCosts;

        [Header("Timer")]
        [SerializeField] private Timer _timer;

        [Header("Test")]
        [SerializeField] private MoneyAdderTest _adder; // Test

        private PlayerStats _playerStats;
        private Money _money;

        private AbilityLevel _abilityLevel;
        private AbilityCost _abilityCost;

        private void Awake()
        {
            _playerStats = new PlayerStats(_defaultPlayerStats);
            _playerStats.Reset();

            _money = new Money(0);
            _abilityLevel = new AbilityLevel(1, 1, 1);
            _abilityCost = new AbilityCost(_defaultAbilityCosts, _abilityLevel);

            _holeScaler.Init(_playerStats);
            _holeMover.Init();
            
            _abilityUpgrader.Init(_playerStats, _money, _abilityCost, _abilityLevel);
            _abilityCostView.Init(_abilityLevel, _abilityCost);
            _abilityLevelView.Init(_abilityLevel);  

            _adder.Init(_money, _playerStats); // Test
            _moneyView.Init(_money);

            _timer.Init();
            _timer.StartTimer(10);

            _absorber.FallingObjectAbsorbed += _playerStats.OnObjectAbsorbed;
        }

        private void OnDestroy()
        {
            _holeScaler.Dispose();

            _abilityUpgrader?.Dispose();
            _abilityCostView?.Dispose();
            _abilityLevelView?.Dispose();

            _moneyView?.Dispose();

            _absorber.FallingObjectAbsorbed -= _playerStats.OnObjectAbsorbed;
        }
    }
}
