using System;
using UnityEngine;

namespace Assets.Scripts.Hole.Map
{
    public class MapScaler
    {
        private Transform _map;

        private float _scaleY;

        public MapScaler(Transform map)
        {
            if (map == null) 
                throw new ArgumentNullException(nameof(map));

            _map = map;
            _scaleY = _map.localScale.y;
        }

        public void Scale(Vector3 scale)
        {
            _map.localScale = new Vector3 (scale.x, _scaleY, scale.z);
        }
    }
}
