using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbingScript : MonoBehaviour
{
    [SerializeField] private float _bobDistance = 0.2f;
    [SerializeField] private float _bobSpeed = 0.5f;

    private bool _goUp = true;
    private float _y = 0;
    private float _maxY = 0;
    private float _minY = 0;
    private void Start()
    {
        _y = this.transform.position.y;
        _maxY = this.transform.position.y + _bobDistance;
        _minY = this.transform.position.y - _bobDistance;
    }
    void Update()
    {
        var pos = this.transform.position;
        pos.y = _goUp ? _maxY : _minY;
        this.transform.position = Vector3.Slerp(this.transform.position, pos, Time.deltaTime * _bobSpeed);


        if (Vector3.Distance(this.transform.position, pos) < 0.1f)
            _goUp = !_goUp;

    }
}
