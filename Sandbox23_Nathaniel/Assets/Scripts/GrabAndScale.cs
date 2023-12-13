using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndScale : MonoBehaviour
{
    //Public Variables
    [Header("Minimum and Maximum Scale")]
    [Range(0.001f, 0.9f)]
    public float minScaleRatio = 0.25f;
    [Range(0.001f, 5f)]
    public float maxScaleRatio = 1f;
    [Space]
    [Header("Scale Threshold and Multiplier")]
    [Range(0.001f, 0.5f)]
    public float scaleThreshold = 0.05f;
    [Range(0.01f, 5f)]
    public float scaleMultiplier = 0.25f;


    //Private Variables
    [Space]
    [SerializeField]
    private GameObject grabScaleManager;

    //Index 0 is left, index 1 is right
    private GameObject[] grabArray;
    private GetGrabberPosition grabPosScript;

    private Vector3 leftGrabPos;
    private Vector3 rightGrabPos;

    private float initialDistance;
    private float currentDistance;

    private Vector3 newScale;
    Vector3 startScale;
    public Vector3 maxScale;
    public Vector3 minScale;

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

        startScale = gameObject.transform.localScale;
        maxScale = gameObject.transform.localScale * maxScaleRatio;
        minScale = gameObject.transform.localScale * minScaleRatio;
    }

    //This starts the GrabScale coroutine (stopping the coroutine is done when the object is released)
    public void StartGrabScale(GameObject thingToScale)
    {
        StartCoroutine(GrabScale(thingToScale));
    }

    //Scales the object based on how far apart the controllers are
    IEnumerator GrabScale(GameObject obj)
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
                var scaleRatio = currentDistance / initialDistance;
                if (scaleRatio > 1f) //If thing go big
                {
                    var amountOver1 = (scaleRatio - 1f);
                    var multipliedAmountOver1 = amountOver1 * scaleMultiplier;

                    var multAmntOverNoThresh = multipliedAmountOver1 - scaleThreshold;
                    Debug.Log(multAmntOverNoThresh + "beeg");
                    if (multAmntOverNoThresh > 0f) //If controllers are getting farther apart
                    {
                        var targetScaleRatio = 1f + multAmntOverNoThresh;
                        var targetScale = targetScaleRatio * startScale;

                        bool overMax = targetScale.x > maxScale.x || targetScale.y > maxScale.y || targetScale.z > maxScale.z;
                        newScale = overMax ? maxScale : targetScale;

                        //newScale = Mathf.Lerp(minScale, maxScale, 1 / (initialDistance/currentDistance) * 0.25f);  //...lerp the distance between the controllers,
                        obj.transform.localScale = newScale;  //and apply the value to the objects scale
                    }
                }
                else if (scaleRatio < 1f) //if thing go small
                {
                    var invertedScaleRatio = 1f / scaleRatio;
                    var amountOver1 = invertedScaleRatio - 1f;
                    var multipliedAmountOver1 = amountOver1 * scaleMultiplier;

                    var multAmntOverNoThresh = multipliedAmountOver1 - scaleThreshold;
                    Debug.Log(multAmntOverNoThresh + "SMOL");
                    if (multAmntOverNoThresh > 0f)
                    {
                        var invertedTargetScaleRatio = 1f + multAmntOverNoThresh;
                        var targetScale = 1f / invertedTargetScaleRatio * startScale;

                        bool underMin = targetScale.x > maxScale.x || targetScale.y > maxScale.y || targetScale.z > maxScale.z;
                        newScale = underMin ? minScale : targetScale;

                        Debug.Log(newScale + " " + underMin);
                        obj.transform.localScale = newScale;
                    }
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
