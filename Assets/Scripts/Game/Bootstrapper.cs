using Assets.Scripts.AbilitySystem;
using Assets.Scripts.Game.LevelSystem;
using Assets.Scripts.Hole;
using Assets.Scripts.Hole.Scale;
using Assets.Scripts.WalletSystem;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class Bootstrapper : MonoBehaviour
    {
        //game
        [SerializeField] private _Game _game;

        //wallet
        [SerializeField] private WalletView _walletView;
        private Wallet _wallet;

        //level
        private LevelActivator _levelActivator;
        private LevelHoleScaler _levelHoleScaler;

        //hole
        [SerializeField] private Absorber _absorber; 
        [SerializeField] private AbsorbBar _absorbBar; 
        [SerializeField] private HoleMover _holeMover;
        [SerializeField] private bl_Joystick _joystick;

        //abilities
        private Ability _startSize;
        private Ability _scale;
        private Ability _money;

        private void Awake()
        {
            Debug.Log("Awake_Bootstrapper");

            //game
            _game.Activate();

            //wallet
            _wallet = new Wallet(0);
            _walletView.Init(_wallet);

            //level
            _levelActivator = new LevelActivator(_absorber, _absorbBar,  _holeMover, _joystick, _levelHoleScaler, _startSize, _scale);
        }
    }
}
