using System;
using UnityEngine; // удалить

namespace Assets.Scripts.Hole
{
    public class AbsorbHandler
    {
        private AbsorbSetting _absorbSetting;

        private float _currentAbsorbMass;
        private float _levelOfRequirings;

        public AbsorbHandler(AbsorbSetting absorbSetting)
        {
            if (absorbSetting == null)
                throw new ArgumentNullException(nameof(absorbSetting));

            _absorbSetting = absorbSetting;
            Reset();
        }

        public event Action RequiredMassReached;
        public event Action<float> AbsorptionProgressUpdated;

        public void Handle(float mass)
        {
            if (mass <= 0)
                throw new ArgumentOutOfRangeException(nameof(mass));

            _currentAbsorbMass += mass;
            float requiringMass = _absorbSetting.UpScaleMass * _levelOfRequirings;

            if (_currentAbsorbMass >= requiringMass)
            {
                _currentAbsorbMass = 0;
                RequiredMassReached?.Invoke();
                _levelOfRequirings++;

                Debug.Log("RequiredMassReached_AbsorbHandler");
            }

            AbsorptionProgressUpdated?.Invoke(_currentAbsorbMass / requiringMass);

        }

        public void Reset()
        {
            _currentAbsorbMass = _absorbSetting.BaseAbsorbMass;
            _levelOfRequirings = _absorbSetting.BaseLevelOfRequirings;

            AbsorptionProgressUpdated?.Invoke(_currentAbsorbMass);
        }
    }
}