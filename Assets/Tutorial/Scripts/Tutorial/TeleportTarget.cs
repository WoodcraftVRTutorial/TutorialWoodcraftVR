using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportTarget : MonoBehaviour
{
    public UnityEvent onTargetReached;
    public GameObject targetIndicator;
    public GameObject rig;
    [SerializeField] private float targetRange = 1.1f;

    private void Update()
    {
        float distanceToRig = Vector3.Distance(transform.position, rig.transform.position);
      
        if(distanceToRig < targetRange)
        {          
            onTargetReached.Invoke();
            targetIndicator.SetActive(false);
        }
    }
}
