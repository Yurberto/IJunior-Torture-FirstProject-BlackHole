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

        private AbsorbHandler _absorbHandler;

        public void Init(Ability startSize, Ability scale, AbsorbHandler absorbHandler)
        {
            if (startSize == null)
                throw new ArgumentNullException(nameof(startSize));
            if (scale == null)
                throw new ArgumentNullException(nameof(scale));
            if (absorbHandler == null)
                throw new ArgumentNullException(nameof(absorbHandler));

            _startSize = startSize;
            _scale = scale;
            _absorbHandler = absorbHandler;

            _currentSize = _startSize.Ratio;

            _startSize.LevelUp += OnStartSizeLevelUp;
            _absorbHandler.RequiredMassReached += OnRequiredMassAbsorbed;
        }

        public void Dispose()
        {
            _startSize.LevelUp -= OnStartSizeLevelUp;
            _absorbHandler.RequiredMassReached += OnRequiredMassAbsorbed;
        }

        private void OnStartSizeLevelUp()
        {
            _currentSize = _startSize.Ratio;
            UpdateSize();
        }

        private void OnRequiredMassAbsorbed()
        {
            _currentSize *= _scale.Ratio;
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

