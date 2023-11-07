using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerScript : MonoBehaviour
{
    [SerializeField] GameObject audioClipManager;   //Declare audio clip manager so this script can reference the stored sounds
    [SerializeField] int audioClipIndex;            //Declare the index of the audio clip array to determine the clip used
    AudioSource audioSource;                        //Declare audio source so we can play the sound
    AudioClipManagerScript manager;                 //Declare the management script itself so we can access the sound array
    bool played = false;                            //Used to make sure a sound only plays once

    private void Start()
    {
        audioSource = gameObject.GetComponentInChildren<AudioSource>();     //Get audio source of the child object
        manager = audioClipManager.GetComponent<AudioClipManagerScript>();  //Get manager script to access sound array
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!played)                    //If the sound hasn't been played
        {
            PlaySound(audioClipIndex);  //Play it
        }
    }

    public void PlaySound(int index)
    {
        
        audioSource.PlayOneShot(manager.audioClips[index]); //Play the sound using the manager script's audio clip array
    }
}
