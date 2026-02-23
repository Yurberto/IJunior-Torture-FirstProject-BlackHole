using System;
using UnityEngine;

namespace Assets.Scripts.Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = nameof(LayersData), menuName = nameof(ScriptableObject) + "/" +  nameof(LayersData))]
    public class LayersData : ScriptableObject
    {
        [SerializeField] private int _normalObject = 6;
        [SerializeField] private int _fallingObject = 7;

        public int NormalObject => _normalObject;
        public int FallingObject => _fallingObject;
    }
}
