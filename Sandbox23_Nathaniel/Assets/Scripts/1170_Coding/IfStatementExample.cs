using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfStatementExample : MonoBehaviour
{
    //Boolean to check if the sound is playing. False by default because nothing is playing
    private bool isPlaying = false;
    //The sound itself
    public AudioSource theSound;

    //A function that plays a sound if nothing is playing, and stops it if it is playing
    public void PlayPause()
    {
        //if isPlaying is false (! before means opposite of), play the sound
        if (!isPlaying)
        {
            //Start the sound
            theSound.Play();
            //Set isPlaying to true because the sound is now playing
            isPlaying = true;
        }
        //if isPlaying is true, stop playing the sound
        else
        {
            //Stop the sound
            theSound.Stop();
            //Set isPlaying to false because we stopped the sound
            isPlaying = false;
        }
    }
}
