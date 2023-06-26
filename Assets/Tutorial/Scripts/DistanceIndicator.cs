using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DistanceCalculator))]
public class DistanceIndicator : MonoBehaviour
{
    public Canvas UICanvas;
    public TMP_Text TxtDistance;
    [HideInInspector] public DistanceCalculator Calculator;

    private void Start()
    {
        Calculator = GetComponent<DistanceCalculator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Calculator.CalculateDistance();
        distance = Mathf.Round(distance * 100)/100;

        if(distance >= 0)
        {
            TxtDistance.text = $"{distance} m";
        }
        else
        {
            TxtDistance.text = "";
        }
    }
}
