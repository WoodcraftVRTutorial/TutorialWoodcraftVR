using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DrawerTask : MonoBehaviour
{
    [SerializeField] UnityEvent sawIsPlaced;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Saw")
        {
            Debug.Log("Saw is in place");
            sawIsPlaced.Invoke();
        }
    }
}
