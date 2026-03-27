using Assets.Scripts.Game.ScriptableObjects;
using System;
using UnityEngine;

namespace Assets.Scripts.Hole
{
    public class Absorber : MonoBehaviour
    {
        [SerializeField] private LayersData _layersData;
        [SerializeField] private AudioSource _audioSource;

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
                GameObject otherGameObject = other.gameObject;

                if (otherGameObject.layer == _layersData.FallingObject)
                {
                    _absorbHandler.Handle(rigidbody.mass);
                    _audioSource.Play();
                    FallingObjectAbsorbed?.Invoke();

                    Debug.Log("OnTrggerExit:FallingObjectAbsorbed_Absorber");
                }

                otherGameObject.SetActive(false);
            }
            else
                throw new ArgumentException("Not found \"Rigidbody\" on \"FallingObject\"");
        }
    }
}
