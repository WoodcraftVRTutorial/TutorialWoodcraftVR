using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnableResetBtn : BaseSpawnableButton
{
    public override void onClick()
    {
        SceneManager.LoadScene(0);
    }
}
