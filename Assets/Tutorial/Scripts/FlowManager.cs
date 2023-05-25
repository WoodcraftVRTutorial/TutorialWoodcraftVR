using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.ParticleSystem;

public class FlowManager : MonoBehaviour
{
    [SerializeField] CheckTrigger trigger;
    [SerializeField] NormalTextPanel textPanel;
    [SerializeField] GameObject tool01;
    [SerializeField] GameObject particlePrefab;
    [SerializeField] GameObject particleSpawnPoint;

    private Vector3 tool01StartPos;
    private Outline tool01Outline;

    private void Awake()
    {
        tool01StartPos = tool01.transform.position;
        tool01StartPos.y += 0.1f;

        tool01.TryGetComponent<Outline>(out tool01Outline);
    }

    private void Update()
    {

        switch (textPanel.CurrentPageIndex)
        {
            case 0:
                break;

            case 1:
                break;

            case 2:
                tool01Outline.enabled = true;
                break;
        }
    }

    public void FinishTask01()
    {
        if (textPanel.CurrentPageIndex == 2)
        {
            textPanel.NextPage();
            SpawnParticles();
            tool01Outline.enabled = false;
        }
        else if (textPanel.CurrentPageIndex < 2)
        {
            tool01.transform.position = tool01StartPos;
        }
    }

    private void SpawnParticles()
    {
        Instantiate(particlePrefab, particleSpawnPoint.transform);
    }
}
