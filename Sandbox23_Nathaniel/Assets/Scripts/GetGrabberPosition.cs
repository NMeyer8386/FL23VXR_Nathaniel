using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGrabberPosition : MonoBehaviour
{
    //An array that houses the grab interactables on the XR Rig
    public GameObject[] grabArray;

    [HideInInspector]
    public bool leftGrab;
    [HideInInspector]
    public bool rightGrab;

    //Returns the grab interactables so we can access them elsewhere
    public GameObject[] GetGrabbers()
    {
        return grabArray;
    }

    //If the thing thats grabbing the object matches one of the grabbers in the array, set its corresponding bool to true
    public void Grabbed(GameObject grabber)
    {
        if (grabber == grabArray[0])
        {
            leftGrab = true;
        }
        if (grabber == grabArray[1])
        {
            rightGrab = true;
        }
    }

    //If the thing thats grabbing the object matches one of the grabbers in the array, set its corresponding bool to false
    public void Released(GameObject grabber)
    {
        if (grabber == grabArray[0])
        {
            leftGrab = false;
        }
        if (grabber == grabArray[1])
        {
            rightGrab = false;
        }
    }
}
