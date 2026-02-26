using Assets.Scripts.AbilityNew;
using System;
using UnityEngine;

namespace Assets.Scripts.Hole
{
    public class HoleScaler : MonoBehaviour
    {
        private const float EnterTriggerScaleFactor = 0.25f;

        [SerializeField] private SphereCollider _enterTrigger;
        [SerializeField] private BoxCollider _absorbTrigger;
        [SerializeField] private Transform _edging;
        [SerializeField] private Transform _cylinder;

        private float _currentSize;

        private Ability _startSize;
        private Ability _scale;

        private Absorber _absorber;

        public void Init(Ability startSize, Ability scale, Absorber absorber)
        {
            if (startSize == null)
                throw new ArgumentNullException(nameof(startSize));
            if (scale == null)
                throw new ArgumentNullException(nameof(scale));
            if (absorber == null)
                throw new ArgumentNullException(nameof(absorber));

            _startSize = startSize;
            _scale = scale;
            _absorber = absorber;

            _currentSize = _startSize.Ratio;

            _startSize.LevelUp += OnStartSizeLevelUp;
            _absorber.FallingObjectAbsorbed += OnFallingObjectAbsorbed;
        }

        public void Dispose()
        {
            _startSize.LevelUp -= OnStartSizeLevelUp;
            _absorber.FallingObjectAbsorbed += OnFallingObjectAbsorbed;
        }

        private void OnStartSizeLevelUp()
        {
            _currentSize = _startSize.Ratio;
            UpdateSize();
        }

        private void OnFallingObjectAbsorbed(float mass)
        {
            _currentSize += _scale.Ratio * mass;
            UpdateSize();
        }

        private void UpdateSize()
        {
            _enterTrigger.radius = _currentSize * EnterTriggerScaleFactor;
            _absorbTrigger.size = new Vector3(_currentSize, _absorbTrigger.size.y, _currentSize);

            _edging.localScale = new Vector3(_currentSize, _edging.localScale.y, _currentSize);
            _cylinder.localScale = new Vector3(_currentSize, _cylinder.localScale.y, _currentSize);
        }
    }
}

