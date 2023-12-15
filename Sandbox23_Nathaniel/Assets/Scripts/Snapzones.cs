using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.Events;

public class Snapzones : MonoBehaviour
{
    //Declare Manager gameobject and manager script
    [SerializeField] GameObject SafetyGameManagerObj;
    SafetyGameManagerScript manager;

    //Declaring rope/anchor materials because its the only thing that has multiple textures
    //Plus it'd be inefficient to get the material from the object you're placing with another for loop
    //plus this is easier :)
    [SerializeField] Material ropeMaterial;
    [SerializeField] Material anchorCarabinerMaterial;

    bool objPlaced = false;
    float releaseAmount = 0.5f;


    //Set the manager script instance on start
    private void Start()
    {
        manager = SafetyGameManagerObj.GetComponent<SafetyGameManagerScript>();
    }

    //Pass the colliding gameobject and grabber to the script when there's a collision
    private void OnTriggerStay(Collider other)
    {

        //if the object hasn't already been placed, and the collider isn't either of the grabbers...
        if (!objPlaced && !(other.gameObject.CompareTag("RightGrab") || other.gameObject.CompareTag("LeftGrab")))
        {
            SnapZoneCheck(other.gameObject, manager.currentGrabber);    //...Run the SnapZoneCheck function
        }

    }

    //get grip input, if it's released, put thing in place if correct
    //make sure the grip corresponds to the hand holding the object
    public void SnapZoneCheck(GameObject obj, Grabber grabber)
    {
        var rightReleased = grabber.gameObject.CompareTag("RightGrab") && InputBridge.Instance.RightGrip < releaseAmount;
        var leftReleased = grabber.gameObject.CompareTag("LeftGrab") && InputBridge.Instance.LeftGrip < releaseAmount;

        //If it's the right hand, the grip isn't being held, and objects need to be placed...
        if ((rightReleased || leftReleased)     //Compare the tag of the grabber and check if the grip has been released,
            && gameObject.CompareTag(obj.tag))  //And make sure the object is the one you want to place,
        {
            //Do the thing
            PutInSnapZone(obj);
        }
    }

    void PutInSnapZone(GameObject obj)
    {
        /* 
         * For objects with multiple components that each have their own textures,
         * we'll iterate through each material using a for loop and change them accordingly
         */
        if (obj.CompareTag("RopeAnchor"))
        {
            var childRenderers = gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer childRenderer in childRenderers)
            {
                switch (childRenderer.gameObject.tag)
                {
                    case "Rope":
                        childRenderer.material = ropeMaterial;
                        break;

                    case "AnchorCarabiner":
                        childRenderer.material = anchorCarabinerMaterial;
                        break;

                    default:
                        Debug.Log("She's biffed mate");
                        break;
                }
            }
            Destroy(obj);
            manager.GameOverCheck(obj.tag);
            objPlaced = !objPlaced;
        } 
        /*
         * For objects with just one material, we access the renderer and change it
         */
        else if (obj.CompareTag("Rail") || obj.CompareTag("HoleCover"))
        {
            var triggerMaterial = gameObject.GetComponent<Renderer>();
            triggerMaterial.material = obj.gameObject.GetComponent<Renderer>().material;
            Destroy(obj);
            manager.GameOverCheck(obj.tag);
            objPlaced = !objPlaced;
        }

        if (objPlaced)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
