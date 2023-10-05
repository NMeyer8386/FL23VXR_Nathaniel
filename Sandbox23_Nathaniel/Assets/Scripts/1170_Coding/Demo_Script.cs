using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class Demo_Script : MonoBehaviour
{
    //Variable Declarations
    [Header("Thing")]
    public GameObject thing;

    [Header("Sliders")]
    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;

    [Header("Labels")]
    public TMP_Text labelX;
    public TMP_Text labelY;
    public TMP_Text labelZ;

    //Function that's called every time the slider value changes
    public void ChangeValue()
    {
        //Create new Quaternion based on slider values
        Quaternion demoQuaternion = new Quaternion(sliderX.value, sliderY.value, sliderZ.value, 1);

        //Change the labels to the slider value (rounded to 2 decimal points)
        labelX.text = Math.Round(sliderX.value, 2).ToString();
        labelY.text = Math.Round(sliderY.value, 2).ToString();
        labelZ.text = Math.Round(sliderZ.value, 2).ToString();

        //Change the rotation to the Quaternion value
        thing.transform.rotation = demoQuaternion;
    }
}
