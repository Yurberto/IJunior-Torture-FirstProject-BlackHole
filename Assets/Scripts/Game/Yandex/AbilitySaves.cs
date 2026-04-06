using Assets.Scripts.AbilitySystem;
using System;

namespace YG
{
    public partial class SavesYG
    {
        private AbilityInfo _startSizeInfo = new();
        private AbilityInfo _scaleInfo = new();
        private AbilityInfo _moneyInfo = new();

        public AbilityInfo StartSizeInfo => _startSizeInfo;
        public AbilityInfo ScaleInfo => _scaleInfo;
        public AbilityInfo MoneyInfo => _moneyInfo;
    }

    public class AbilityInfo
    {
        private int _level;
        private int _cost;
        private float _ratio;

        public int Level => _level;
        public int Cost => _cost;
        public float Ratio => _ratio;

        public void Update(int level, int cost, float ratio)
        {
            if (level <= 0)
                throw new ArgumentOutOfRangeException(nameof(ratio));
            if (cost <= 0)
                throw new ArgumentOutOfRangeException(nameof(cost));
            if (ratio <= 0)
                throw new ArgumentOutOfRangeException(nameof(level));

            _level = level;   
            _cost = cost;
            _ratio = ratio;
        }
    }
}
