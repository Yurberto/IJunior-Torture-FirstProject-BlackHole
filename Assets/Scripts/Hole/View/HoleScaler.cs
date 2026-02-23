using Assets.Scripts.Game;
using System;
using UnityEngine;

namespace Assets.Scripts.Hole
{
    public class HoleScaler : MonoBehaviour
    {
        private const float TriggerScaleFactor = 0.25f;

        [SerializeField] private SphereCollider _trigger;
        [SerializeField] private Transform _edging;
        [SerializeField] private Transform _cylinder;

        private PlayerStats _playerStats;

        public void Init(PlayerStats playerStats)
        {
            if (playerStats == null)
                throw new ArgumentNullException(nameof(playerStats));

            _playerStats = playerStats;

            _playerStats.CurrentSizeUpdated += UpdateSize;
        }

        public void Dispose()
        {
            if (_playerStats == null)
                throw new ArgumentNullException(nameof(_playerStats));

            _playerStats.CurrentSizeUpdated -= UpdateSize;
        }

        private void UpdateSize(float newSize)
        {
            if (newSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(newSize));

            _trigger.radius = newSize * TriggerScaleFactor;

            _edging.localScale = new Vector3(newSize, _edging.localScale.y, newSize);
            _cylinder.localScale = new Vector3(newSize, _cylinder.localScale.y, newSize);

        }
    }
}

