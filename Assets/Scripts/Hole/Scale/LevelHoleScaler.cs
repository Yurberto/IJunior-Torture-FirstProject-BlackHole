using Assets.Scripts.AbilitySystem;
using System;

namespace Assets.Scripts.Hole.Scale
{
    public class LevelHoleScaler
    {
        private Ability _startSize;
        private Ability _scale;

        private AbsorbHandler _absorbHandler;

        private float _currentSize;

        public LevelHoleScaler(Ability startSize, Ability scale, AbsorbHandler absorbHandler)
        {
            if (startSize == null)
                throw new ArgumentNullException(nameof(startSize));
            if (scale == null)
                throw new ArgumentNullException(nameof(scale));
            if (absorbHandler == null)
                throw new ArgumentNullException(nameof(absorbHandler));

            _startSize = startSize;
            _scale = scale;
            _absorbHandler = absorbHandler;
        }

        public event Action<float> CurrentSizeUpdated;

        public void Start()
        {
            _currentSize = _startSize.Ratio;
            _absorbHandler.RequiredMassReached += OnRequiredMassReached;
        }

        public void Stop()
        {
            _absorbHandler.RequiredMassReached -= OnRequiredMassReached;
        }

        private void OnRequiredMassReached()
        {
            _currentSize *= _scale.Ratio;
            CurrentSizeUpdated?.Invoke(_currentSize);
        }
    }
}
