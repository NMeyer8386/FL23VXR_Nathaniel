using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndScale : MonoBehaviour
{
    //Public Variables

    public float minScale = 0.25f;
    public float maxScale = 1f;

    //Private Variables

    //Index 0 is left, index 1 is right
    private GameObject[] grabArray;

    private GetGrabberPosition grabPosScript;

    [SerializeField]
    private GameObject grabScaleManager;

    private Vector3 leftGrabPos;
    private Vector3 rightGrabPos;

    private float initialDistance;
    private float currentDistance;
    private float scaleFactor;

    //Booleans for both of the grabbers
    private bool leftGrabber { get; set; }
    private bool rightGrabber { get; set; }

    //Makes sure the while loop in the coroutine is always running
    private bool grabbed = true;

    //Get position of both grabbers
    //lerp the distance between them
    //multiply the scale by the delta

    // Start is called before the first frame update
    void Start()
    {
        //getting the grab interactables from the XR rig
        grabPosScript = grabScaleManager.GetComponent<GetGrabberPosition>();
        grabArray = grabPosScript.GetGrabbers();

    }

    //This starts the GrabScale coroutine (stopping the coroutine is done when the object is released)
    public void StartGrabScale()
    {
        StartCoroutine(GrabScale());
    }

    //Scales the object based on how far apart the controllers are
    IEnumerator GrabScale()
    {
        //Runs as long as the object is being held
        while (grabbed)
        {
            //Make sure both hands are grabbing the object
            leftGrabber = grabPosScript.leftGrab;
            rightGrabber = grabPosScript.rightGrab;

            if (leftGrabber && rightGrabber)                    //If both hands are grabbing the object...
            {
                leftGrabPos = grabArray[0].transform.position;  //...Set the left grabber position,
                rightGrabPos = grabArray[1].transform.position; //Set the right grabber position,

                currentDistance = Vector3.Distance(leftGrabPos, rightGrabPos);  //And grab the current distance between the grabbers
                if (initialDistance != currentDistance)                         //If the distances aren't the same (unlikely to be equal but just in case)...
                {
                    scaleFactor = Mathf.Lerp(initialDistance, currentDistance, 1);  //...lerp the distance between the controllers,
                    scaleFactor = Mathf.Clamp(scaleFactor, minScale, maxScale);     //set a min/max value for the scale,

                    transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);  //and apply the value to the objects scale
                }
            }
            yield return null; //if this is not here unity will crash :)
        }
    }

    //Used to grab the distance between the controllers once the trigger is pressed
    public void GetInitDistance()
    {
        initialDistance = Vector3.Distance(leftGrabPos, rightGrabPos);
    }
}
