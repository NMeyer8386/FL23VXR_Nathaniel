using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class OpenDoors : MonoBehaviour
{
    // Doors to be opened 
    [SerializeField] GameObject Door1, Door2;
    // Are the doors open?
    private bool doorsOpened = false;

    public float openDuration = 3.0f; // Seconds to open the doors
    public float rotationSpeed = 90.0f; // How far the doors can open in degrees

    // When the trigger is hit
    private void OnTriggerEnter(Collider other)
    {
        // if the doors are opened
        if (!doorsOpened && other.tag == "Player")
        {
            // Start my coroutine
            StartCoroutine(OpenTheDoors());
        }
    }

    // My Coroutine
    IEnumerator OpenTheDoors()
    {
        doorsOpened = true; // Flag the doors at open instantly so that they dont try openeing a second time

        // How long its been
        float timer = 0.0f;

        // Create Quaternions for the initial rotations and the ending rotation for Door1 and Door2
        Quaternion initialRotation1 = new Quaternion();
        Quaternion targetRotation1 = new Quaternion();
        Quaternion initialRotation2 = new Quaternion();
        Quaternion targetRotation2 = new Quaternion();
        if (Door1 != null)// Only if the door exists
        {
            initialRotation1 = Door1.transform.rotation;
            targetRotation1 = Door1.transform.rotation * Quaternion.Euler(0, rotationSpeed, 0);
        }
        if (Door2 != null)// Only if the door exists
        {
            initialRotation2 = Door2.transform.rotation;
            targetRotation2 = Door2.transform.rotation * Quaternion.Euler(0, -rotationSpeed, 0);
        }

        while (timer < openDuration) // Stops as soon as the door is opened all the way
        {
            timer += Time.deltaTime; // Increases the timer by the amount of time between frames
            // Only if the door exists
            if (Door1 != null)
            {
                Door1.transform.rotation = Quaternion.Slerp(initialRotation1, targetRotation1, timer / openDuration); // Moves the rotation to the point it should be based on time 
            }
            // Only if the door exists
            if (Door2 != null)
            {
                Door2.transform.rotation = Quaternion.Slerp(initialRotation2, targetRotation2, timer / openDuration); // Moves the rotation to the point it should be based on time 
            }
            yield return null; // Wait for the next frame
        }
    }
}

