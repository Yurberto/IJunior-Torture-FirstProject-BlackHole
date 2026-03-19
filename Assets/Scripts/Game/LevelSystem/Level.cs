using UnityEngine;

namespace Assets.Scripts.Game.LevelSystem
{ 
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private LevelConfig _config;

        public Transform Transform => _transform;
        public LevelConfig Config => _config;
    }
}
