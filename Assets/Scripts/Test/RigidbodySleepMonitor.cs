using UnityEngine;

public class RigidbodySleepMonitor : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private bool _wasSleeping;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _wasSleeping = _rigidbody.IsSleeping();
    }

    private void FixedUpdate()
    {
        bool isSleeping = _rigidbody.IsSleeping();

        if (isSleeping && !_wasSleeping)
        {
            Debug.Log($"{gameObject.name} ЗАСНУЛ");
        }
        else if (!isSleeping && _wasSleeping)
        {
            Debug.Log($"{gameObject.name} ПРОСНУЛСЯ");
        }

        _wasSleeping = isSleeping;
    }
}