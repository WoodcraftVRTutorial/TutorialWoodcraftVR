using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportTarget : MonoBehaviour
{
    public UnityEvent onTargetReached;
    public GameObject targetIndicator;
    public GameObject rig;

    private void Update()
    {
        float distanceToRig = Vector3.Distance(transform.position, rig.transform.position);
        Debug.Log(distanceToRig);
        
        if(distanceToRig < 1f)
        {
            
            onTargetReached.Invoke();
            targetIndicator.SetActive(false);
        }
    }
}
