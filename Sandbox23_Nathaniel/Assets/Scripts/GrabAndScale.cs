using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndScale : MonoBehaviour
{
    //Public Variables

    //Index 0 is left, index 1 is right
    public GameObject[] grabArray;

    public float minScale = 0.25f;
    public float maxScale = 1f;

    public bool scaleEnabled = false;

    //Private Variables

    [SerializeField]
    private GetGrabberPosition grabPosScript;

    [SerializeField]
    private GameObject grabberPosManager;

    [SerializeField]
    private Vector3 leftGrabPos;

    [SerializeField]
    private Vector3 rightGrabPos;

    private float initialDistance;
    private float currentDistance;
    private float scaleFactor;

    private bool grabbed { get; set; }

    //Get position of both grabbers
    //lerp the distance between them
    //multiply the scale by the delta

    // Start is called before the first frame update
    void Start()
    {
        //getting the grab interactables from the XR rig
        grabPosScript = grabberPosManager.GetComponent<GetGrabberPosition>();
        grabArray = grabPosScript.GetGrabbers();

    }

    //This toggles the GrabScale coroutine (stopping the coroutine is done when the trigger is let go and when the object is let go)
    public void StartStopGrabScale()
    {
        if (grabbed)                        //If the object is being grabbed...
        {       
            scaleEnabled = true;            //...Allow scaling,
            StartCoroutine(GrabScale());    //And start the grab and scale coroutine.
        } else                              //If the object isn't being grabbed...
        {
            scaleEnabled = false;           //...Disallow scaling.
        }
    }

    IEnumerator GrabScale()
    {
        while (scaleEnabled)
        {
            leftGrabPos = grabArray[0].transform.position;  //Set the left grabber position
            rightGrabPos = grabArray[1].transform.position; //Set the right grabber position

            currentDistance = Vector3.Distance(leftGrabPos, rightGrabPos);  //grab the current distance between the grabbers
            if (initialDistance != currentDistance)                         //If the distances aren't the same...
            {
                scaleFactor = Mathf.Lerp(initialDistance, currentDistance, 1);  //...lerp the distance between the controllers,
                scaleFactor = Mathf.Clamp(scaleFactor, minScale, maxScale);     //set a min/max value for the scale,

                transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);  //and apply the value to the objects scale

                yield return new WaitForSeconds(0.01f); //if this is not here unity will crash :)
            }
        }
    }

    //Used to grab the distance between the controllers once the trigger is pressed
    public void GetInitDistance()
    {
        initialDistance = Vector3.Distance(leftGrabPos, rightGrabPos);
    }

    /* I'd like to use something other than functions for this, but I can't find another way
     * to change a custom boolean using unity events so this will have to do */
    public void GrabTrue()
    {
        grabbed = true;
    }

    public void GrabFalse()
    {
        grabbed = false;
    }
}
