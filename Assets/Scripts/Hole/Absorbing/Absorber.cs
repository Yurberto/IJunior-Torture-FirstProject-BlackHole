using Assets.Scripts.Game.ScriptableObjects;
using System;
using UnityEngine;

namespace Assets.Scripts.Hole
{
    public class Absorber : MonoBehaviour
    {
        [SerializeField] private LayersData _layersData;

        private AbsorbHandler _absorbHandler;

        public void Init(AbsorbHandler absorbHandler)
        {
            if (absorbHandler == null)
                throw new ArgumentNullException(nameof(absorbHandler));

            _absorbHandler = absorbHandler;
        }

        public event Action FallingObjectAbsorbed;

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Rigidbody rigidbody))
            {
                _absorbHandler.Handle(rigidbody.mass);
                other.gameObject.SetActive(false);

                FallingObjectAbsorbed?.Invoke();
            }
            else
                throw new ArgumentException("Not found \"Rigidbody\" on \"Object\"");
        }
    }
}
