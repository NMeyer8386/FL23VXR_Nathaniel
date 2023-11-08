using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRepeat : MonoBehaviour
{
    [SerializeField] GameObject audioClipManager;   //Declare audio clip manager so this script can reference the stored sounds
    [SerializeField] GameObject sourceToMove;       //Declare the audio source we want to move
    [SerializeField] int audioClipIndex;            //Declare the index of the audio clip array to determine the clip used
    AudioSource audioSource;                        //Declare audio source so we can play the sound
    AudioClipManagerScript manager;                 //Declare the management script itself so we can access the sound array
    bool routineRun = false;
    Vector3 soundStart = new Vector3(3.8f, 6, -13);
    Vector3 distance = new Vector3(0, 0, -10);

    private void Start()
    {
        audioSource = sourceToMove.GetComponent<AudioSource>();             //Get audio source of the object
        manager = audioClipManager.GetComponent<AudioClipManagerScript>();  //Get manager script to access sound array
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!routineRun)
        {
            StartCoroutine(MoveRepeat());       //Repeats a sound and moves the object to emulate footsteps
        }
    }

    IEnumerator MoveRepeat()
    {   
        for (int i = 1; i <= 5; i++)
        {
            sourceToMove.transform.position = Vector3.Lerp(soundStart, soundStart + distance, 0.2f * i);
            audioSource.PlayOneShot(manager.audioClips[3]); //Plays the sound
            yield return new WaitForSeconds(1.5f);          //Waits 1.5 seconds before it continues the loop
        }
        routineRun = true;
        yield return null;
    }
}