using Assets.Scripts.AbilitySystem;
using Assets.Scripts.Game;
using System;
using UnityEngine;

namespace Assets.Scripts.Hole.Scale
{
    public class HoleScalerView : MonoBehaviour
    {
        private const float TriggerEnterScaleFactor = 0.25f;
        private const float AbsorberScaleFactor = 2f;
        private const float ParticleScaleFactor = 4;

        [SerializeField] private SphereCollider _enterTrigger;
        [SerializeField] private Transform _absorber;
        [SerializeField] private Transform _edging;
        [SerializeField] private Transform _cylinder;
        [SerializeField] private Transform _particleSystem;

        private GameHoleScaler _gameHoleScaler;
        private LevelHoleScaler _levelHoleScaler;

        private MainMenu _mainMenu;

        public void Init(GameHoleScaler gameHoleScaler, LevelHoleScaler levelHoleScaler, MainMenu mainMenu)
        {
            if (gameHoleScaler == null)
                throw new ArgumentNullException(nameof(gameHoleScaler));
            if (levelHoleScaler == null)
                throw new ArgumentNullException(nameof(levelHoleScaler));
            if (mainMenu == null)
                throw new ArgumentNullException(nameof(mainMenu));

            _gameHoleScaler = gameHoleScaler;
            _levelHoleScaler = levelHoleScaler;
            _mainMenu = mainMenu;
        }

        public event Action<float> SizeUpdated;

        public void Subscribe()
        {
            _gameHoleScaler.SizeUpdated += UpdateSize;
            _levelHoleScaler.CurrentSizeUpdated += UpdateSize;

            _mainMenu.Opened += ResetToStartSize;
        }

        public void UnSubscribe()
        {
            _gameHoleScaler.SizeUpdated -= UpdateSize;
            _levelHoleScaler.CurrentSizeUpdated -= UpdateSize;

            _mainMenu.Opened -= ResetToStartSize;
        }

        private void UpdateSize(float newSize)
        {
            if (newSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(newSize));

            _enterTrigger.radius = newSize * TriggerEnterScaleFactor;
            _absorber.localScale = new Vector3(newSize * AbsorberScaleFactor, _absorber.localScale.y, newSize * AbsorberScaleFactor);

            _edging.localScale = new Vector3(newSize, _edging.localScale.y, newSize);
            _cylinder.localScale = new Vector3(newSize, _cylinder.localScale.y, newSize);
            _particleSystem.localScale = new Vector3(newSize * ParticleScaleFactor, _particleSystem.localScale.y, newSize * ParticleScaleFactor);
            
            SizeUpdated?.Invoke(newSize);
        }

        private void ResetToStartSize()
        {
            UpdateSize(_gameHoleScaler.StartSizeRatio);
        }
    }
}

