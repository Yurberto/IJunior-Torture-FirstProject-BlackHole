using System;
using UnityEngine;

namespace Assets.Scripts.Hole
{
    [CreateAssetMenu(fileName = nameof(AbsorbSetting), menuName = nameof(ScriptableObject) + "/" + nameof(AbsorbSetting))]
    public class AbsorbSetting : ScriptableObject
    {
        [SerializeField] private float _upScaleMass = 10;
        [SerializeField] private float _baseAbsorbMass = 0;
        [SerializeField] private float _baseLevelOfRequirings = 1;

        public float UpScaleMass => _upScaleMass;
        public float BaseAbsorbMass => _baseAbsorbMass;
        public float BaseLevelOfRequirings => _baseLevelOfRequirings;
    }
}
