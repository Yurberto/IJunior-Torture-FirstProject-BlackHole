using Assets.Scripts.Hole;
using System;

namespace Assets.Scripts.Game.LevelSystem
{
    public class LevelAbsorbCounter
    {
        private Absorber _absorber;
        private int _currentAbsorptions;

        public LevelAbsorbCounter(Absorber absorber)
        {
            if (absorber == null)
                throw new ArgumentNullException(nameof(absorber));

            _absorber = absorber;

            Reset();
        }

        public int CurrentAbsorptions => _currentAbsorptions;

        public void Subscribe()
        {
            _absorber.FallingObjectAbsorbed += AddAbsorption;
        }

        public void UnSubscribe()
        {
            _absorber.FallingObjectAbsorbed -= AddAbsorption;
        }

        public void Reset()
        {
            _currentAbsorptions = 0;
        }

        private void AddAbsorption()
        {
            ++_currentAbsorptions;
        }
    }
}
