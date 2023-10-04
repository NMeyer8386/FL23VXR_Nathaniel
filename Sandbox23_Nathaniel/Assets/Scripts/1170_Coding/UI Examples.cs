using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeProperty : MonoBehaviour
{

    public GameObject thingToChange;
    public Slider volSlide;

    private Material objColour;
    private AudioSource objVolume;
    protected Vector3 tall = new Vector3(1, 2, 1);
    protected Vector3 wide = new Vector3(2, 1, 1);

    public void ChangeColour()
    {
        objColour = thingToChange.GetComponent<Renderer>().material;
        objColour.color = Color.blue;
    }

    public void ChangeSizeTall()
    {
        thingToChange.transform.localScale = tall;
    }    
    
    public void ChangeSizeWide()
    {
        thingToChange.transform.localScale = wide;
    }

    public void ChangeVolume(Slider volSlide)
    {
        objVolume = thingToChange.GetComponent<AudioSource>();
        objVolume.volume = volSlide.value;
    }

}
