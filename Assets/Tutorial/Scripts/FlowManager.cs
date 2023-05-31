using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.ParticleSystem;

public class FlowManager : MonoBehaviour
{
    [SerializeField] CheckTrigger trigger;
    [SerializeField] NormalTextPanel textPanel;
    [SerializeField] GameObject tool01;
    [SerializeField] GameObject hammer;
    [SerializeField] GameObject particlePrefab;
    [SerializeField] GameObject particleSpawnPoint;
    [SerializeField] GameObject teleportTarget;
    [SerializeField] GameObject sawHologram;
    [SerializeField] MeshRenderer sawHologramRenderer;
    [SerializeField] SawTask saw;

    private Vector3 tool01StartPos;
    private Outline tool01Outline;

    private Vector3 hammerStartPos;
    private Outline hammerOutline;



    private void Awake()
    {
        tool01StartPos = tool01.transform.position;
        tool01StartPos.y += 0.1f;
        tool01.TryGetComponent<Outline>(out tool01Outline);
        tool01Outline.enabled = false;

        sawHologram.TryGetComponent<MeshRenderer>(out sawHologramRenderer);
        sawHologramRenderer.enabled = false;

        hammerStartPos = hammer.transform.position;
        hammerStartPos.y += 0.1f;
        hammer.TryGetComponent<Outline>(out hammerOutline);
        hammerOutline.enabled = false;
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
            case 3:
                teleportTarget.SetActive(true);
                break;
            case 4:
                sawHologramRenderer.enabled = true;
                break;
            case 5:
                hammerOutline.enabled = true;
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

    public void FinishTask02()
    {
        if (textPanel.CurrentPageIndex == 3)
        {
            teleportTarget.SetActive(false);
            textPanel.NextPage();
            SpawnParticles();
        }
    }

    public void FinishTask03()
    {
        if(textPanel.CurrentPageIndex == 4)
        {
            sawHologramRenderer.enabled=false;
            textPanel.NextPage();
            SpawnParticles();
        }       
    }

    public void FinishTask04()
    {
        if (textPanel.CurrentPageIndex == 5)
        {
            textPanel.NextPage();
            SpawnParticles();
            hammerOutline.enabled = false;
        }
        else if (textPanel.CurrentPageIndex < 5)
        {
            hammer.transform.position = hammerStartPos;
        }
    }

    private void SpawnParticles()
    {
        Instantiate(particlePrefab, particleSpawnPoint.transform);
    }
}
