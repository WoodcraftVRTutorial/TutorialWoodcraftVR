using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpawnableEffect : MonoBehaviour
{
    protected BasePanel _basePanel;

    public virtual void Start()
    {
        if (this.transform.parent == null) return;

        _basePanel = this.transform.parent.GetComponentInChildren<BasePanel>();
        if (_basePanel == null && this.transform.parent.parent != null)
            _basePanel = this.transform.parent.parent.GetComponentInChildren<BasePanel>();
    }
}
