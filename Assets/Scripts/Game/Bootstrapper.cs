using Assets.Scripts.Hole;
using Assets.Scripts.Ability;
using Assets.Scripts.Game.ScriptableObjects;
using UnityEngine;
using Assets.Scripts.Test;
using Assets.Scripts.MoneyClasses;

namespace Assets.Scripts.Game
{
    public class Bootstrapper : MonoBehaviour
    {
        // Привести все в порядок
        [Header("HoleView")]
        [SerializeField] private HoleScaler _holeScaler;
        [SerializeField] private HoleMover _holeMover;
        [SerializeField] private Absorber _absorber;
        [SerializeField] private AbilityUpgrader _abilityUpgrader;

        [Header("MoneyView")]
        [SerializeField] private MoneyView _moneyView;
        [SerializeField] private AbilityCostView _abilityCostView;

        [Header("ScriptableObjects")]
        [SerializeField] private DefaultPlayerStats _defaultPlayerStats;
        [SerializeField] private DefaultAbilityCosts _defaultAbilityCosts;

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
            _abilityLevel = new AbilityLevel(1,1,1);
            _abilityCost = new AbilityCost(_defaultAbilityCosts, _abilityLevel);
            _adder.Init(_money, _playerStats); // Test

            _holeScaler.Init(_playerStats);
            _abilityUpgrader.Init(_playerStats, _money, _abilityCost, _abilityLevel);
            _abilityCostView.Init(_abilityLevel, _abilityCost);

            _holeMover.Init();

            _moneyView.Init(_money);

            _absorber.FallingObjectAbsorbed += _playerStats.OnObjectAbsorbed;
        }

        private void OnDestroy()
        {
            _holeScaler.Dispose();
            _abilityUpgrader?.Dispose();
            _moneyView?.Dispose();

            _absorber.FallingObjectAbsorbed -= _playerStats.OnObjectAbsorbed;
        }
    }
}
