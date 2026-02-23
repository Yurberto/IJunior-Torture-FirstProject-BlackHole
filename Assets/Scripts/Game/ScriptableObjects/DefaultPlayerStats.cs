using UnityEngine;

namespace Assets.Scripts.Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = nameof(DefaultPlayerStats), menuName = nameof(ScriptableObject) + "/" + nameof(DefaultPlayerStats))]
    public class DefaultPlayerStats : ScriptableObject
    {
        [Header("Core")]
        [SerializeField] private float _baseStartSize = 1f;
        [SerializeField] private float _baseScale = 0.1f;
        [SerializeField] private float _baseMoney = 1f;

        [Header("UpgradeGrowth")]
        [SerializeField] private float _startSizeGrowth = 1.2f;
        [SerializeField] private float _scaleGrowth = 1.1f;
        [SerializeField] private float _moneyGrowth = 1.15f;

        public float BaseStartSize => _baseStartSize;
        public float BaseScale => _baseScale;
        public float BaseMoney => _baseMoney;

        public float StartSizeGrowth => _startSizeGrowth;
        public float ScaleGrowth => _scaleGrowth;
        public float MoneyGrowth => _moneyGrowth;
    }
}
