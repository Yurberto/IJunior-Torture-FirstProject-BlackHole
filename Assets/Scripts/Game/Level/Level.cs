using System;
using UnityEngine;

namespace Assets.Scripts.Game
{ 
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _transform;

        public Transform Transform => _transform;
    }
}
