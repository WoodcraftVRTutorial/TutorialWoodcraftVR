using System;
using System.Collections;
using UnityEngine;

public class GrabState : MonoBehaviour
{
    public bool IsGrabbed { get { return _isGrabbed; } set { _isGrabbed = value; } }

    [SerializeField]
    private bool _isGrabbed = false;

}