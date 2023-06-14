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
    [SerializeField] NormalTextPanel sidePanel;
    [SerializeField] GameObject tool01;
    [SerializeField] GameObject saw;
    [SerializeField] GameObject hammer;
    [SerializeField] GameObject particlePrefab;
    [SerializeField] GameObject particleSpawnPoint;
    [SerializeField] GameObject teleportTarget;
    [SerializeField] GameObject teleportTarget2;
    [SerializeField] GameObject sawHologram;
    MeshRenderer sawHologramRenderer;
    [SerializeField] SawTask sawBlade;
    [SerializeField] DistanceIndicator distIndicator;

    private Vector3 tool01StartPos;
    private Outline tool01Outline;

    private Outline sawOutline;

    private Vector3 hammerStartPos;
    private Outline hammerOutline;


    private void Awake()
    {
        sidePanel.enabled = false;
        
        tool01StartPos = tool01.transform.position;
        tool01StartPos.y += 0.1f;
        tool01.TryGetComponent<Outline>(out tool01Outline);
        tool01Outline.enabled = false;

        sawHologram.TryGetComponent<MeshRenderer>(out sawHologramRenderer);
        sawHologramRenderer.enabled = false;

        saw.TryGetComponent<Outline>(out sawOutline);

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
                distIndicator.Calculator.SetTarget(tool01.transform);
                break;
            case 3:             
                break;
            case 4:
                teleportTarget.SetActive(true);
                break;
            case 5:
                sawHologramRenderer.enabled = true;             
                break;
            case 6:  
                sawOutline.enabled = true;
                break;
            case 7:
                teleportTarget2.SetActive(true);
                hammerOutline.enabled = true;
                break;
        }
    }

    public void FinishRespawnTask()
    {
        if (textPanel.CurrentPageIndex == 2)
        {
            textPanel.NextPage();
            SpawnParticles();
        }
    }

    public void FinishToolboxTask()
    {
        if (textPanel.CurrentPageIndex == 3)
        {
            textPanel.NextPage();
            SpawnParticles();
            tool01Outline.enabled = false;
            distIndicator.Calculator.SetTarget(null);
        }
        else if (textPanel.CurrentPageIndex < 3)
        {
            tool01.transform.position = tool01StartPos;
        }
    }

    public void FinishTeleportationTask()
    {
        if (textPanel.CurrentPageIndex == 4)
        {
            teleportTarget.SetActive(false);
            textPanel.NextPage();
            sidePanel.enabled = true;
            SpawnParticles();
        }
    }

    public void FinishSnappingTask()
    {
        if(textPanel.CurrentPageIndex == 5)
        {
            sawHologramRenderer.enabled=false;
            textPanel.NextPage();
            sidePanel.NextPage();
            SpawnParticles();
        }       
    }

    public void FinishOpenDrawerTask()
    {
        if (textPanel.CurrentPageIndex == 6)
        {           
            sawOutline.enabled=false;
            textPanel.NextPage();
            SpawnParticles();
        }
    }

    public void FinishHammerTask()
    {
        if (textPanel.CurrentPageIndex == 7)
        {
            textPanel.NextPage();
            SpawnParticles();
            hammerOutline.enabled = false;
            teleportTarget2.SetActive(false);
        }
        else if (textPanel.CurrentPageIndex < 7)
        {
            hammer.transform.position = hammerStartPos;
        }
    }

    private void SpawnParticles()
    {
        Instantiate(particlePrefab, particleSpawnPoint.transform);
    }
}
