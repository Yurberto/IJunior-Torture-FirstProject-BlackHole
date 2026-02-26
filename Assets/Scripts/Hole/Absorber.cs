using Assets.Scripts.Game.ScriptableObjects;
using System;
using UnityEngine;

namespace Assets.Scripts.Hole
{
    public class Absorber : MonoBehaviour
    {
        [SerializeField] private LayersData _layersData;

        public event Action<float> FallingObjectAbsorbed;

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Rigidbody rigidbody))
            {
                GameObject otherGameObject = other.gameObject;

                if (otherGameObject.layer == _layersData.FallingObject)
                {
                    FallingObjectAbsorbed?.Invoke(rigidbody.mass);
                    Debug.Log("Absorber_FallingObjectAbsorbed.Invoke()");
                }

                otherGameObject.SetActive(false);
            }
            else
                throw new ArgumentException("Not found \"Rigidbody\" on \"FallingObject\"");
        }
    }
}
