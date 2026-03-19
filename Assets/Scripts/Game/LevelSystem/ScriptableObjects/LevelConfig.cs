using UnityEngine;

namespace Assets.Scripts.Game.LevelSystem
{
    [CreateAssetMenu(fileName = nameof(LevelConfig), menuName = nameof(ScriptableObject) + "/" + nameof(LevelConfig))]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private int _objectsCount;
        [SerializeField] private int _time;

        public int ObjectsCount => _objectsCount;
        public int Time => _time;
    }
}
