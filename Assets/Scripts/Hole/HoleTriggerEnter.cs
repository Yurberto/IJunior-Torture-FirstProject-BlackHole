using Assets.Scripts.Game.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.Hole
{
    public class HoleTriggerEnter : MonoBehaviour
    {
        [SerializeField] private LayersData _layersData;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == _layersData.NormalObject)
                other.gameObject.layer = _layersData.FallingObject;
        }

        private void OnTriggerStay(Collider other)
        {
            other.attachedRigidbody?.WakeUp();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == _layersData.FallingObject)
                other.gameObject.layer = _layersData.NormalObject;
        }
    }
}

