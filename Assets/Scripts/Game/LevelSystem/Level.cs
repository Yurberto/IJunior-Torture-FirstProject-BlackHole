using System;
using UnityEngine;

namespace Assets.Scripts.Game.LevelGamplay
{ 
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private LevelConfig _config;

        public Transform Transform => _transform;
        public LevelConfig Config => _config;
    }
}
