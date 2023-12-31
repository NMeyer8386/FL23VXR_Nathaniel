using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using TMPro;
using VInspector;
using UnityEngine.Events;

public class SafetyGameManagerScript : MonoBehaviour
{
    [HideInInspector]
    public Grabber currentGrabber;

    [Tab("GameObjects")]
    [SerializeField] GameObject clipBoardMenu;
    [SerializeField] GameObject constructionSite;

    [Tab("Labels")]
    //See tooltip for index correlation
    [Tooltip("Index 0: Rails, Index 1: Hole Cover, Index 2: Rope and Anchor")]
    [SerializeField] TMP_Text[] menuLabels;
    [EndTab]
    
    public UnityEvent winEvent;
    public UnityEvent checklistUpdate;

    private int railsPlaced = 0;
    private bool ropeAnchorPlaced = false;
    private bool holeCoverPlaced = false;

    private void Start()
    {
        UpdateMenu();
        checklistUpdate.Invoke();
    }

    public void SetCurrentGrabber(Grabber grabber)
    {
        currentGrabber = grabber;
    }

    public void GameOverCheck(string objTag)
    {
        switch (objTag)
        {
            case "Rail":
                railsPlaced++;
                break;

            case "RopeAnchor":
                ropeAnchorPlaced = true;
                break;

            case "HoleCover":
                holeCoverPlaced = true;
                break;

            default:
                Debug.Log("Tag not recognized");
                break;
        }
        checklistUpdate.Invoke();
        UpdateMenu();
        if (railsPlaced == 6
            && ropeAnchorPlaced
            && holeCoverPlaced)
        {
            winEvent.Invoke();
        }
    }

    void UpdateMenu()
    {
        menuLabels[0].text = railsPlaced + "/6";
        
        if (holeCoverPlaced)
        {
            menuLabels[1].text = "1/1";
        } else
        {
            menuLabels[1].text = "0/1";
        }
        
        if (ropeAnchorPlaced)
        {
            menuLabels[2].text = "1/1";
        } else
        {
            menuLabels[2].text = "0/1";
        }

    }
}
