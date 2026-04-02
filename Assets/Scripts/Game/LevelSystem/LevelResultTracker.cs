using Assets.Scripts.Game.Time;
using Assets.Scripts.Hole;
using System;
using UnityEngine;

namespace Assets.Scripts.Game.LevelSystem
{
    public class LevelResultTracker
    {
        private Absorber _absorber;
        private LevelTimer _timer;

        private int _currentAbsorbtions = 0;
        private int _reachedAbsorptions = 0;

        public LevelResultTracker(Absorber absorber, LevelTimer timer)
        {
            if (absorber == null)
                throw new ArgumentNullException(nameof(absorber));
            if (timer == null) 
                throw new ArgumentNullException(nameof(timer));

            _absorber = absorber;
            _timer = timer;
        }

        public event Action LevelCompleted;
        public event Action LevelFailed;

        public void Track(int reachedAbsorptions)
        {
            _currentAbsorbtions = 0;
            _reachedAbsorptions = reachedAbsorptions;

            _absorber.FallingObjectAbsorbed += OnFallingObjectAbsorbed;
            _timer.HasOver += OnTimerFinished;
        }

        private void StopTracking()
        {
            _absorber.FallingObjectAbsorbed -= OnFallingObjectAbsorbed;
            _timer.HasOver -= OnTimerFinished;
        }

        private void OnFallingObjectAbsorbed()
        {
            if (++_currentAbsorbtions >= _reachedAbsorptions)
            {
                LevelCompleted?.Invoke();
                StopTracking();
            }
        }

        private void OnTimerFinished()
        {
            LevelFailed?.Invoke();
            StopTracking();
        }
    }
}
