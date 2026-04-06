using Assets.Scripts.Hole.Scale;
using System;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Transform _follower;
    [SerializeField] private Transform _target;

    [SerializeField] private float _height = 2;
    [SerializeField] private float _horizontalOffset = 0;
    [SerializeField] private float _distance = 3;

    private HoleScalerView _holeScalerView;

    private float _sizeFactor = 1;

    public void Init(HoleScalerView holeScalerView)
    {
        if (holeScalerView == null)
            throw new ArgumentNullException(nameof(holeScalerView));

        _holeScalerView = holeScalerView;

        _holeScalerView.SizeUpdated += UpdateSizeFactor;
    }

    public void Dispose()
    {
        _holeScalerView.SizeUpdated -= UpdateSizeFactor;
    }

    private void Update()
    {
        _follower.position = _target.position + new Vector3(_horizontalOffset, _height * _sizeFactor, _distance * _sizeFactor);
    }

    private void UpdateSizeFactor(float size)
    {
        _sizeFactor = size;
    }
}
