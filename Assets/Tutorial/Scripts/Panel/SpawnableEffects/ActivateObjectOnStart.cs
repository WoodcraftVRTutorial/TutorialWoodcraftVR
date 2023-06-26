using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectOnStart : BaseSpawnableEffect
{
    [SerializeField]
    private string _objectName = "";
    
    public override void Start()
    {
        var allFoundObjects = FindObjectsOfType<GameObject>(true);
        foreach (var obj in allFoundObjects)
        {
            if (obj.name == _objectName)
                obj.SetActive(true);
        }
    }
}
