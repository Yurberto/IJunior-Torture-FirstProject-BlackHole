using System;
using UnityEngine;

namespace Assets.Scripts.Hole.Map
{
    public class MapMover
    {
        private Transform _map;

        public MapMover(Transform map)
        {
            if (map == null)
                throw new ArgumentNullException(nameof(map));

            _map = map;
        }

        public void MoveTo(Vector3 position)
        {
            _map.position = position;
        }
    }
}
