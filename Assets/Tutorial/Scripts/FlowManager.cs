using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlowManager : MonoBehaviour
{
    [SerializeField] CheckTrigger trigger;
    [SerializeField] NormalTextPanel textPanel;
    [SerializeField] GameObject tool01;

    private Vector3 tool01StartPos;

    private void Awake()
    {
        tool01StartPos = tool01.transform.position; 
        tool01StartPos.y += 0.1f;
    }


    private void Update()
    {
        Debug.Log(textPanel.CurrentPageIndex);
    }

    public void FinishTask01()
    {
        if(textPanel.CurrentPageIndex == 2)
        {
            textPanel.NextPage();
        }
        else if(textPanel.CurrentPageIndex < 2)
        {
            tool01.transform.position = tool01StartPos;
        }
    }
}
