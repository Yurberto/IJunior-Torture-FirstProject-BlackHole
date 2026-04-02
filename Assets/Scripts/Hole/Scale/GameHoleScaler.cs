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

            _startSize.LevelUp += OnStartSizeChanged;
        }

        public void Dispose()
        {
            _startSize.LevelUp -= OnStartSizeChanged;
        }

        public event Action<float> SizeUpdated;
        public float StartSizeRatio => _startSize.Ratio;

        private void OnStartSizeChanged()
        {
            UnityEngine.Debug.Log("GameHoleScaler_OnStartSizeChanged");
            SizeUpdated?.Invoke(_startSize.Ratio);
        }
    }
}
