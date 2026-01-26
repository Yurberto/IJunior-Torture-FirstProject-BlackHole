using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AbsorberInternalTrigger : MonoBehaviour
{
    public event Action<Absorbable> AbsorbingObjectEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Absorbable absorbingObject))
        {
            AbsorbingObjectEntered?.Invoke(absorbingObject);
            Debug.Log($"InternalEnter");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, GetComponent<SphereCollider>().radius);
    }
}
