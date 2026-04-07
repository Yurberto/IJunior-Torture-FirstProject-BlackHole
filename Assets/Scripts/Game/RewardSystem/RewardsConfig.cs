using UnityEngine;

namespace Assets.Scripts.Game
{
    [CreateAssetMenu(fileName = nameof(RewardsConfig), menuName = nameof(ScriptableObject) + "/" + nameof(RewardsConfig))]
    public class RewardsConfig : ScriptableObject
    {
        [SerializeField] private int _addMoney = 100;
        [SerializeField] private int _multiplyFactor = 3;

        public int AddMoney => _addMoney;
        public int MultiplyFactor => _multiplyFactor;
    }
}
