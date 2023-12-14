using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class SafetyGameManagerScript : MonoBehaviour
{
    public Grabber currentGrabber;
    [SerializeField] GameObject constructionSite;

    public void SetCurrentGrabber(Grabber grabber)
    {
        currentGrabber = grabber;
    }
}
