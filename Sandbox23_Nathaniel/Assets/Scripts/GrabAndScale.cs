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

    public bool scaleEnabled = false;
    private bool grabbed { get; set; }

    //Get position of both grabbers
    //slerp the distance between them
    //multiply the scale by the delta

    // Start is called before the first frame update
    void Start()
    {
        grabPosScript = grabberPosManager.GetComponent<GetGrabberPosition>();
        grabArray = grabPosScript.GetGrabbers();

    }

    public void StartStopGrabScale()
    {
        if (grabbed)
        {
            scaleEnabled = true;
            StartCoroutine(GrabScale());
        } else
        {
            scaleEnabled = false;
        }
    }

    IEnumerator GrabScale()
    {
        while (scaleEnabled)
        {
            leftGrabPos = grabArray[0].transform.position;
            rightGrabPos = grabArray[1].transform.position;

            currentDistance = Vector3.Distance(leftGrabPos, rightGrabPos);
            if (initialDistance != currentDistance)
            {
                scaleFactor = Mathf.Lerp(initialDistance, currentDistance, 1);
                //Definies a min/max for the scale factor 
                scaleFactor = Mathf.Clamp(scaleFactor, minScale, maxScale);

                transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

                yield return new WaitForSeconds(0.01f);
            }
        }
    }

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
