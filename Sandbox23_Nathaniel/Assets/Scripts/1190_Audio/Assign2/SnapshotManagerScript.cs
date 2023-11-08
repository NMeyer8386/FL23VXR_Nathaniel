using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SnapshotManagerScript : MonoBehaviour
{
    [SerializeField] AudioMixerSnapshot[] audioMixers;  //Contains all the snapshots we want to use

    public void SnapshotChange(int snapIndex)
    {
        audioMixers[snapIndex].TransitionTo(0.5f);      //Transitions to the given snapshot
    }
}