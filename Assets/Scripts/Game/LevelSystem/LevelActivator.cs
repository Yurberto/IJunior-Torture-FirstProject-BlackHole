using Assets.Scripts.AbilitySystem;
using Assets.Scripts.Hole;
using Assets.Scripts.Hole.Scale;
using System;

namespace Assets.Scripts.Game.LevelSystem
{
    public class LevelActivator
    {
        private Absorber _absorber;
        private AbsorbBar _absorbBar;
        private HoleMover _holeMover;
        private bl_Joystick _joystick;

        private LevelHoleScaler _levelHoleScaler;

        private Ability _startSize;
        private Ability _scale;

        public LevelActivator
            (
            Absorber absorber,
            AbsorbBar absorbBar,
            HoleMover holeMover,
            bl_Joystick joystick,
            LevelHoleScaler levelHoleScaler,
            Ability startSize,
            Ability scale
            )
        {
            if (absorber == null)
                throw new ArgumentNullException(nameof(absorber));
            if (absorbBar == null)
                throw new ArgumentNullException(nameof(absorbBar));
            if (holeMover == null)
                throw new ArgumentNullException(nameof(holeMover));
            if (joystick == null)
                throw new ArgumentNullException(nameof(joystick));
            if (levelHoleScaler == null)
                throw new ArgumentNullException(nameof(levelHoleScaler));
            if (startSize == null)
                throw new ArgumentNullException(nameof(startSize));
            if (scale == null)
                throw new ArgumentNullException(nameof(scale));

            _absorber = absorber;
            _absorbBar = absorbBar;
            _holeMover = holeMover;
            _joystick = joystick;
            _levelHoleScaler = levelHoleScaler;
            _startSize = startSize;
            _scale = scale;
        }

        public void Activate()
        {
            SetActivity(true);
            _absorbBar.Subscribe();
            _levelHoleScaler.Start(_startSize.Ratio, _scale.Ratio);
        }

        public void Deactivate()
        {
            SetActivity(false);
            _absorbBar.Unsubscribe();
            _levelHoleScaler.Stop();
        }

        private void SetActivity(bool isActive)
        {
            _holeMover.gameObject.SetActive(isActive);
            _joystick.gameObject.SetActive(isActive);

            _absorber.gameObject.SetActive(isActive);
            _absorbBar.gameObject.SetActive(isActive);
        }
    }
}
