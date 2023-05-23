using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnablePreviousBtn : BaseSpawnableButton
{
    public override void onClick()
    {
        _basePanel.PreviousPage();
    }
}
