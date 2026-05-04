using System;
using UnityEngine;

namespace Assets.Scripts.Hole.Scale.Particle
{
    public class ParticleScaler : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;


        private float _basePartsSize;
        private float _baseShapeRadius;
        private float _baseDuration;
        private float _baseMaxParticles;


        private void Awake()
        {
            
        }
    }
}
