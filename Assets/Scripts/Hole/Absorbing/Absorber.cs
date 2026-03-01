using Assets.Scripts.Game.ScriptableObjects;
using System;
using UnityEngine;

namespace Assets.Scripts.Hole
{
    public class Absorber : MonoBehaviour
    {
        [SerializeField] private LayersData _layersData;

        AbsorbHandler _absorbHandler;

        public void Init(AbsorbHandler absorbHandler)
        {
            if (absorbHandler == null)
                throw new ArgumentNullException(nameof(absorbHandler));

            _absorbHandler = absorbHandler;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Rigidbody rigidbody))
            {
                GameObject otherGameObject = other.gameObject;

                if (otherGameObject.layer == _layersData.FallingObject)
                {
                    _absorbHandler.Handle(rigidbody.mass);
                    Debug.Log("Absorber_OnTriggerExit");
                }

                otherGameObject.SetActive(false);
            }
            else
                throw new ArgumentException("Not found \"Rigidbody\" on \"FallingObject\"");
        }
    }
}
