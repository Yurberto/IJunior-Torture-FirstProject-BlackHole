using System;
using UnityEngine;

public class Absorber : MonoBehaviour
{
    [SerializeField] private Collider _map;
    [SerializeField] private AbsorberInternalTrigger _internalTrigger;

    private void OnEnable()
    {
        _internalTrigger.AbsorbingObjectEntered += Absorb;
    }

    private void OnDisable()
    {
        _internalTrigger.AbsorbingObjectEntered -= Absorb;
    }

    private void Absorb(Absorbable absorbable)
    {
        if (absorbable.IsReadyToAbsorb)
        {
            Physics.IgnoreCollision(_map, absorbable.Collider, true);
            Debug.Log("Absorb");
        }
    }
}
