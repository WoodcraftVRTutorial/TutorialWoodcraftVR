using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableSawbladeMachineButton : BaseSpawnableButton
{
    [SerializeField]
    private string _panelName = "Display Change Saw Blade";
    private GameObject _panel = null;

    public override void onClick()
    {
        _panel.SetActive(true);
        _basePanel.transform.parent.parent.parent.gameObject.SetActive(false);
    }

    public override void Start()
    {
        base.Start();

        var panels = FindObjectsOfType<BasePanel>(true);
        foreach (var panel in panels)
        {
            if (panel.transform.parent.parent.parent.name == _panelName)
                _panel = panel.transform.parent.parent.parent.gameObject;
        }
    }

}
