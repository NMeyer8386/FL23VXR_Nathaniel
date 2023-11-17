using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeTracker : MonoBehaviour
{
    private float timeSinceStart;
    public TMP_Text label;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Tracks time since you hit play
        timeSinceStart = Time.realtimeSinceStartup;
        label.text = "Time Since Start: " + (Mathf.Round((timeSinceStart * 100f))/100f).ToString();
    }
}
