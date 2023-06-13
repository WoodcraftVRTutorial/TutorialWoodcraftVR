using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDistanceToTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private float _distance;

    // Update is called once per frame
    void Update()
    {
        if (_target != null)
        {
            _distance = Vector3.Distance(transform.position, _target.position);
            Debug.Log($"Distance: {_distance} m");
        }
    }

    public void SetTarget(Transform targetTransform)
    {
        _target = targetTransform;
    }

    public float GetDistance()
    {
        return _distance;
    }
}
