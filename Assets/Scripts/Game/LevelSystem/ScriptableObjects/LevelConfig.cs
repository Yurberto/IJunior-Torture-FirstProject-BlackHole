using UnityEngine;

namespace Assets.Scripts.Game.LevelGamplay
{
    [CreateAssetMenu(fileName = nameof(LevelConfig), menuName = nameof(ScriptableObject) + "/" + nameof(LevelConfig))]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private int _objectsCount;

        public int ObjectsCount => _objectsCount;
    }
}
