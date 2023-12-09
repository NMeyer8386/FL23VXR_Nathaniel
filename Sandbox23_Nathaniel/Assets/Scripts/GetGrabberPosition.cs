using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGrabberPosition : MonoBehaviour
{
    //An array that houses the grab interactables on the XR Rig
    public GameObject[] grabArray;

    //Returns the grab interactables so we can access them elsewhere
    public GameObject[] GetGrabbers()
    {
    return grabArray;
    }
}
