using Assets.Scripts.AbilitySystem;
using Assets.Scripts.AbilitySystem.ScriptableObjects;
using Assets.Scripts.Game;
using Assets.Scripts.Game.LevelSystem;
using Assets.Scripts.Game.LevelSystem.Award;
using Assets.Scripts.Game.LevelSystem.Time;
using Assets.Scripts.Game.Time;
using Assets.Scripts.Hole;
using Assets.Scripts.Hole.Scale;
using Assets.Scripts.WalletSystem;
using System;
using UnityEngine;
using YG;

namespace Assets.Scripts.Test
{
    public class TestAbsorptionBootstrapper : MonoBehaviour
    {
        [SerializeField] private MainMenu _mainMenu;
        [Header("Ability")]
        [SerializeField] private BaseAbilityStats _startSizeBaseStats;
        [SerializeField] private BaseAbilityStats _scaleBaseStats;
        [Header("Hole")]
        [SerializeField] private HoleScalerView _holeScalerView;
        [SerializeField] private HoleMover _holeMover;

        [Header("Absorbing")]
        [SerializeField] private AbsorbSetting _absorbSetting;
        [SerializeField] private Absorber _absorber;
        [SerializeField] private AbsorbBar _absorbBar;

        private GameHoleScaler _gameHoleScaler;
        private LevelHoleScaler _levelHoleScaler;

        private AbsorbHandler _absorbHandler;

        private Ability _startSize;
        private Ability _scale;

        private void Awake()
        {
            YG2.StickyAdActivity(true);

            _startSize = new Ability(_startSizeBaseStats);
            _scale = new Ability(_scaleBaseStats);

            _absorbHandler = new AbsorbHandler(_absorbSetting);
            _absorber.Init(_absorbHandler);
            _absorbBar.Init(_absorbHandler);

            _gameHoleScaler = new GameHoleScaler(_startSize);
            _levelHoleScaler = new LevelHoleScaler(_startSize, _scale, _absorbHandler);
            _holeScalerView.Init(_gameHoleScaler, _levelHoleScaler, _mainMenu);
            _holeScalerView.Subscribe();

            _holeMover.StartMoving();
        }

        private void OnApplicationQuit()
        {
            _holeScalerView.UnSubscribe();
            _holeMover.StopMoving();
        }
    }
}
