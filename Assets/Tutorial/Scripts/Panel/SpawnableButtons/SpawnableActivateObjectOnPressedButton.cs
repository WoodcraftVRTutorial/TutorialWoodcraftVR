using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableActivateObjectOnPressedButton : BaseSpawnableButton
{
    [SerializeField]
    private string _objectName = "";
    private GameObject _object = null;

    public override void onClick()
    {
        _object.SetActive(true);
    }

    public override void Start()
    {
        base.Start();

        var objectsInScene = FindObjectsOfType<GameObject>(true);
        foreach (var foundObject in objectsInScene)
        {
            if (foundObject.name == _objectName)
                _object = foundObject;
        }
    }

}
