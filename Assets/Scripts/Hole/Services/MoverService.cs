using System;
using UnityEngine;

namespace Assets.Scripts.Hole
{
    public class MoverService
    {
        private Transform _movable;

        public MoverService(Transform movable)
        {
            if (movable == null)
                throw new ArgumentNullException(nameof(movable));

            _movable = movable;
        }

        public void MoveOnSurface(Vector3 direction, float speed)
        {
            if (direction == Vector3.zero)
                return;

            direction.y = 0;

            _movable.position += direction * speed;
        }
    }
}

