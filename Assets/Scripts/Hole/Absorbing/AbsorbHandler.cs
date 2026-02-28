using System;

namespace Assets.Scripts.Hole
{
    public class AbsorbHandler
    {
        private AbsorbSetting _absorbSetting;

        private float _currentAbsorbMass = 0;
        private float _requiringLevel = 1;

        public AbsorbHandler(AbsorbSetting absorbSetting)
        {
            if (absorbSetting == null)
                throw new ArgumentNullException(nameof(absorbSetting));

            _absorbSetting = absorbSetting;
        }

        public event Action RequiredMassReached;

        public void Handle(float mass)
        {
            if (mass <= 0)
                throw new ArgumentOutOfRangeException(nameof(mass));

            _currentAbsorbMass += mass;

            if (_currentAbsorbMass >= _absorbSetting.UpScaleMass * _requiringLevel)
            {
                _currentAbsorbMass = 0;
                RequiredMassReached?.Invoke();
            }
        }

        public void Reset()
        {
            _requiringLevel = 1;
        }
    }
}