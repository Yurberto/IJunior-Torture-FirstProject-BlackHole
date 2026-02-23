using System;
using UnityEngine;

namespace Assets.Scripts.Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = nameof(DefaultAbilityCosts), menuName = nameof(ScriptableObject) + "/" + nameof(DefaultAbilityCosts))]
    public class DefaultAbilityCosts : ScriptableObject
    {
        [Header("Costs")]
        [SerializeField] private int _startSizeCost = 100;
        [SerializeField] private int _scaleCost = 150;
        [SerializeField] private int _moneyCost = 200;
        [Header("GrowthFactor")]
        [SerializeField] private float _growthFactor = 1.6f;

        public int StartSizeCost => _startSizeCost;
        public int ScaleCost => _scaleCost;
        public int MoneyCost => _moneyCost;

        public float GrowthFactor => _growthFactor;
    }
}
