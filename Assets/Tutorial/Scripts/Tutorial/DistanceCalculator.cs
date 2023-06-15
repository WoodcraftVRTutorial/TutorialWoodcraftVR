using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    [SerializeField] private Transform _target = null;
    private float _distance;

    public void SetTarget(Transform targetTransform)
    {
        _target = targetTransform;
    }

    public float CalculateDistance()
    {
        if (_target != null)
        {
            _distance = Vector3.Distance(transform.position, _target.position);
            return _distance;
        }
        else
        {
            return -1;
        }
    }

    public float CalculateDistance(Transform targetTransform)
    {
        _target = targetTransform;
        
        if (_target != null)
        {
            _distance = Vector3.Distance(transform.position, _target.position);
            return _distance;
        }
        else
        {
            return -1;
        }
    }
}
