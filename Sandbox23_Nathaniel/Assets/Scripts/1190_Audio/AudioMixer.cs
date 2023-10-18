using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*  
 *  Script for Exercise 4.3: Audio Mixer
 *  Two buttons transition between day and night using
 *  the audio mixer
 */
public class AudioMixer : MonoBehaviour
{
    [Header("Audio Stuff")]
    public AudioSource audio1;
    public AudioSource audio2;
    public AudioClip myClip;

    [Header("Snapshots")]
    public AudioMixerSnapshot day;
    public AudioMixerSnapshot night;

    //Transitions to the day snapshot
    public void TransitionDay()
    {
        day.TransitionTo(2);
    }

    //Transitions to the night snapshot
    public void TransitionNight()
    {
        night.TransitionTo(2);
    }

    //Plays the audioclip thats passed through
    public void PlayOnce(AudioSource audioSource)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(myClip);
        }
    }
}
