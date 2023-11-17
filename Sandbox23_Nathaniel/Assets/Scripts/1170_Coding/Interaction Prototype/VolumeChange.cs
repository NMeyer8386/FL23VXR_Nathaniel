using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChange : MonoBehaviour
{
    //Declare the dial transform so we can access rotation
    [SerializeField]
    Transform dial;

    //Declare the sound we'll be changing the volume of
    [SerializeField]
    AudioSource sound;

    //Declare rotational min and max for the dial as well as volume
    float minRotate = 0f;
    float maxRotate = 180f;
    float volume;

    
    //Changes the volume when the dial's value is changed
    public void ChangeVolume()
    {
        /* divides the current rotation - the minimum angle by the 
         * rotational range of the dial which gives us a value between 0 and 1 */
        volume = (dial.localEulerAngles.y - minRotate) / (maxRotate - minRotate);
        sound.volume = volume;  //sets the volume to the rotational value
    }
}
