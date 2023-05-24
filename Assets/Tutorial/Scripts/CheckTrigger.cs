using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckTrigger : MonoBehaviour
{
    public UnityEvent onToolEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tool01"))
        {
            onToolEntered.Invoke();
        }
    }
}
