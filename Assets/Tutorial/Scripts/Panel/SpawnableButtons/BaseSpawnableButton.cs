using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public abstract class BaseSpawnableButton : MonoBehaviour
{
    protected BasePanel _basePanel;

    public virtual void Start()
    {
        if (this.transform.parent == null) return;

        _basePanel = this.transform.parent.GetComponentInChildren<BasePanel>();
        if (_basePanel == null && this.transform.parent.parent != null)
            _basePanel = this.transform.parent.parent.GetComponentInChildren<BasePanel>();
        var btn = this.GetComponent<UnityEngine.UI.Button>();
        if (btn != null)
            btn.onClick.AddListener(onClick);
        var interactable = this.GetComponent<XRSimpleInteractable>();
        if (interactable != null)
            interactable.activated.AddListener(onVRClick);
    }

    public abstract void onClick();
    public void onVRClick(ActivateEventArgs args)
    {
        onClick();
    }
}
