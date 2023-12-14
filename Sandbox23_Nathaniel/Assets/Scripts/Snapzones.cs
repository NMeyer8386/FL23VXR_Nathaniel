using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class Snapzones : MonoBehaviour
{
    //Declare Manager gameobject and manager script
    [SerializeField] GameObject SafetyGameManagerObj;
    SafetyGameManagerScript manager;

    bool objPlaced = false;


    //Set the manager script instance on start
    private void Start()
    {
        manager = SafetyGameManagerObj.GetComponent<SafetyGameManagerScript>();
    }

    //Pass the colliding gameobject and grabber to the script when there's a collision
    private void OnTriggerStay(Collider other)
    {
        if (!objPlaced)
        {
            SnapZoneCheck(other.gameObject, manager.currentGrabber);
        }

    }

    //get grip input, if it's released, put thing in place if correct
    //make sure the grip corresponds to the hand holding the object
    public void SnapZoneCheck(GameObject obj, Grabber grabber)
    {
        Debug.Log(grabber.gameObject.tag);
        //If it's the right hand, the grip isn't being held, and objects need to be placed...
        if (grabber.gameObject.CompareTag("RightGrab")  //Compare the tag of the grabber,
            && InputBridge.Instance.RightGrip == 0      //Check if the grip is being pressed,
            && gameObject.CompareTag(obj.tag))          //And make sure the object is the one you want to place,
        {
            Debug.Log("GG EZ");
            Destroy(obj);
            objPlaced = !objPlaced; //Then place it!
        }

        //If it's the left hand, the grip isn't being held, and objects need to be placed...
        if (grabber.gameObject.CompareTag("LeftGrab")
            && InputBridge.Instance.LeftGrip == 0
            && gameObject.CompareTag(obj.tag))
        {
            Debug.Log("GG EZ");
            Destroy(obj);
            objPlaced = !objPlaced;
        }
    }
}
