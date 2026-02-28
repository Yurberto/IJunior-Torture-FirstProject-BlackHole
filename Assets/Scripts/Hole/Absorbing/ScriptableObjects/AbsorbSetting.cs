using System;
using UnityEngine;

namespace Assets.Scripts.Hole
{
    [CreateAssetMenu(fileName = nameof(AbsorbSetting), menuName = nameof(ScriptableObject) + "/" + nameof(AbsorbSetting))]
    public class AbsorbSetting : ScriptableObject
    {
        [SerializeField] private float _upScaleMass = 10;

        public float UpScaleMass => _upScaleMass;
    }
}
