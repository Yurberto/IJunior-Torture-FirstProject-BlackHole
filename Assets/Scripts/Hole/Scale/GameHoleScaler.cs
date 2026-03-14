using Assets.Scripts.AbilitySystem;
using Assets.Scripts.Hole.Scale;
using System;

namespace Assets.Scripts.Hole.Scale
{
    public class GameHoleScaler
    {
        private Ability _startSize;

        public GameHoleScaler(Ability startSize)
        {
            if (startSize == null)
                throw new ArgumentNullException(nameof(startSize));

            _startSize = startSize;
        }

        public event Action<float> StartSizeUpdated;

        public void Subscribe()
        {
            _startSize.LevelUp += OnHoleSizeChanged;
        }

        public void UnSubscribe()
        {
            _startSize.LevelUp -= OnHoleSizeChanged;
        }

        private void OnHoleSizeChanged()
        {
            StartSizeUpdated?.Invoke(_startSize.Ratio);
        }
    }
}
