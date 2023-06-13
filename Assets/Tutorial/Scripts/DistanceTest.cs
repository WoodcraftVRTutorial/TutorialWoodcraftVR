using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class DistanceTest : MonoBehaviour
{
    public DistanceIndicator Indicator;
    public GameObject TargetSphere;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Indicator.Calculator.SetTarget(TargetSphere.transform);
        }
    }
}
