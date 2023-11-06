using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerScript : MonoBehaviour
{
    [SerializeField] GameObject audioClipManager;
    [SerializeField] int audioClipIndex;
    AudioSource audioSource;
    AudioClipManagerScript manager;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        manager = audioClipManager.GetComponent<AudioClipManagerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlaySound(audioClipIndex);
    }

    [ContextMenu("testSound")]
    public void PlaySound(int index)
    {
        audioSource.PlayOneShot(manager.audioClips[index]);
    }
}
