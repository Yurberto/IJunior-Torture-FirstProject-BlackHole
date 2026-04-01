using System;

namespace Assets.Scripts.Game
{
    public static class RewardTypes 
    {
        public static readonly string CoinsMultiply = nameof(CoinsMultiply);
        public static readonly string CoinsAdd = nameof(CoinsAdd);
        public static readonly string TimeAdd = nameof(TimeAdd);
    }

    public enum RewardType
    {
        CoinsMultiply,
        CoinsAdd
    }
}
