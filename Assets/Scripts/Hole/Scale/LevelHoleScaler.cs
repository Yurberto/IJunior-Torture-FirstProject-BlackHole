using Assets.Scripts.AbilitySystem;
using System;

namespace Assets.Scripts.Hole.Scale
{
    public class LevelHoleScaler
    {
        private float _currentSize;
        private float _scaleRatio;

        private AbsorbHandler _absorbHandler;

        public LevelHoleScaler(AbsorbHandler absorbHandler)
        {
            if (absorbHandler == null)
                throw new ArgumentNullException(nameof(absorbHandler));

            _absorbHandler = absorbHandler;
        }

        public event Action<float> CurrentSizeUpdated;

        public void Start(float currentSize, float scaleRatio)
        {
            if (currentSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(currentSize));
            if (scaleRatio <= 0)
                throw new ArgumentOutOfRangeException(nameof(scaleRatio));

            _currentSize = currentSize;
            _scaleRatio = scaleRatio;

            _absorbHandler.RequiredMassReached += OnRequiredMassReached;
        }

        public void Stop()
        {
            _absorbHandler.RequiredMassReached -= OnRequiredMassReached;
        }

        private void OnRequiredMassReached()
        {
            _currentSize *= _scaleRatio;
            CurrentSizeUpdated?.Invoke(_currentSize);
        }
    }
}
