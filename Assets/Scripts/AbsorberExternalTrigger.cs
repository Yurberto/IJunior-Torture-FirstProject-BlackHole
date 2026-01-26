using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AbsorberExternalTrigger : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, GetComponent<SphereCollider>().radius);
    }
}
