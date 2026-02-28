using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Transform _follower;
    [SerializeField] private Transform _target;

    [SerializeField] private float _height = 2;
    [SerializeField] private float _horizontalOffset = 0;
    [SerializeField] private float _distance = 3;

    private void Update()
    {
        _follower.position = _target.position + new Vector3(_horizontalOffset, _height, _distance);
    }
}
