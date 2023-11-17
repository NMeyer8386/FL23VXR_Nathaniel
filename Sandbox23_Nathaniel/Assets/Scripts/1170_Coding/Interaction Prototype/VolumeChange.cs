using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChange : MonoBehaviour
{
    [SerializeField]
    Transform dial;

    [SerializeField]
    AudioSource sound;

    float minRotate = 0f;
    float maxRotate = 180f;
    float volume;

    

    public void ChangeVolume()
    {
        volume = (dial.localEulerAngles.y - minRotate) / (maxRotate - minRotate);
        sound.volume = volume;
        Debug.Log(volume);
    }
}
