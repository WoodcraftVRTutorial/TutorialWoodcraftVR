using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using System;

public class SawTask : MonoBehaviour
{
    [SerializeField] GameObject sawHologram;
    [SerializeField] UnityEvent sawIsPlaced;


    private void Update()
    {
        if(transform.position == sawHologram.transform.position)
        {
            sawIsPlaced.Invoke();
        }
    }
}
