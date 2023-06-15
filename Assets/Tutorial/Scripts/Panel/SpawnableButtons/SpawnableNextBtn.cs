using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableNextBtn : BaseSpawnableButton
{
    public override void onClick()
    {
        _basePanel.NextPage();
    }
}
