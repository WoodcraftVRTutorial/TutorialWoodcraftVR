using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableHomeButton : BaseSpawnableButton
{
    [SerializeField]
    private string _homePanelName = "Menu Screen";
    private GameObject _homePanel;
    
    public override void onClick()
    {
        _basePanel.transform.parent.parent.parent.gameObject.SetActive(false);
        _homePanel.transform.gameObject.SetActive(true);
        _homePanel.transform.gameObject.SetActive(true);

        _basePanel.ResetPanel();
    }

    public override void Start()
    {
        base.Start();
        var objectsInScene = FindObjectsOfType<GameObject>(true);
        foreach (var obj in objectsInScene)
        {
            if (obj.name.Equals(_homePanelName))
                _homePanel = obj;
        }
    }
}
