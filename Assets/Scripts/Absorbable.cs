using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Absorbable : MonoBehaviour
{
    private Collider _collider;
    private bool _isReadyToAbsorb;

    public bool IsReadyToAbsorb => _isReadyToAbsorb;
    public Collider Collider => _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out AbsorberExternalTrigger _))
            _isReadyToAbsorb = true;
        Debug.Log($"ExternalEnter");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out AbsorberExternalTrigger _))
            _isReadyToAbsorb = false;
        Debug.Log($"ExternalExit");
    }
}
