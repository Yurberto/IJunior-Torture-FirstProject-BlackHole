using Assets.Scripts.AbilitySystem;
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

        public event Action<float> SizeUpdated;
        public float StartSizeRatio => _startSize.Ratio;

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
            SizeUpdated?.Invoke(_startSize.Ratio);
        }
    }
}
