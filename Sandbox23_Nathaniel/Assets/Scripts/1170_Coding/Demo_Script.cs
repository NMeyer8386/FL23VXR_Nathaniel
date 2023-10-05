using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class Demo_Script : MonoBehaviour
{
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
    public void ChangeValue()
    {
        Quaternion demoQuaternion = new Quaternion(sliderX.value, sliderY.value, sliderZ.value, 1);

        labelX.text = Math.Round(sliderX.value, 2).ToString();
        labelY.text = Math.Round(sliderY.value, 2).ToString();
        labelZ.text = Math.Round(sliderZ.value, 2).ToString();

        thing.transform.rotation = demoQuaternion;
    }
}
