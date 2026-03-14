using Assets.Scripts.AbilitySystem;
using System;
using UnityEngine;

namespace Assets.Scripts.Hole.Scale
{
    public class HoleScalerView : MonoBehaviour
    {
        private const float EnterTriggerScaleFactor = 0.25f;

        [SerializeField] private SphereCollider _enterTrigger;
        [SerializeField] private BoxCollider _absorbTrigger;
        [SerializeField] private Transform _edging;
        [SerializeField] private Transform _cylinder;

        private GameHoleScaler _gameHoleScaler;
        private LevelHoleScaler _levelHoleScaler;

        public void Init(GameHoleScaler gameHoleScaler, LevelHoleScaler levelHoleScaler)
        {
            if (gameHoleScaler == null)
                throw new ArgumentNullException(nameof(gameHoleScaler));
            if (levelHoleScaler == null)
                throw new ArgumentNullException(nameof(levelHoleScaler));

            _gameHoleScaler = gameHoleScaler;
            _levelHoleScaler = levelHoleScaler;
        }

        public void Subscribe()
        {
            _gameHoleScaler.StartSizeUpdated += UpdateSize;
            _levelHoleScaler.CurrentSizeUpdated += UpdateSize;
        }

        public void UnSubscribe()
        {
            _gameHoleScaler.StartSizeUpdated -= UpdateSize;
            _levelHoleScaler.CurrentSizeUpdated -= UpdateSize;
        }

        private void UpdateSize(float newSize)
        {
            _enterTrigger.radius = newSize * EnterTriggerScaleFactor;
            _absorbTrigger.size = new Vector3(newSize, _absorbTrigger.size.y, newSize);

            _edging.localScale = new Vector3(newSize, _edging.localScale.y, newSize);
            _cylinder.localScale = new Vector3(newSize, _cylinder.localScale.y, newSize);
        }
    }
}

