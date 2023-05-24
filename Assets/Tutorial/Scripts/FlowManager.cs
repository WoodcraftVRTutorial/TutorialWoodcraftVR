using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlowManager : MonoBehaviour
{
    [SerializeField] CheckTrigger trigger;
    [SerializeField] NormalTextPanel textPanel;
    private void Update()
    {
        Debug.Log(textPanel.CurrentPageIndex);
    }


    public void FinishTask01()
    {
        if(textPanel.CurrentPageIndex == 2)
        {
            Debug.Log("Task finished!");
            textPanel.NextPage();
        }
    }
}
