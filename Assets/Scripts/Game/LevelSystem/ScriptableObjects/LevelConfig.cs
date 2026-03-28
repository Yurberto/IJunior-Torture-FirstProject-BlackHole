using UnityEngine;

namespace Assets.Scripts.Game.LevelSystem
{
    [CreateAssetMenu(fileName = nameof(LevelConfig), menuName = nameof(ScriptableObject) + "/" + nameof(LevelConfig))]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private Transform _level;
        [SerializeField] private int _time;
        [SerializeField] private int _reward;

        public Transform Level => _level;
        public int ObjectsCount => _level.childCount;
        public int Time => _time;
        public int Reward => _reward;
    }
}
