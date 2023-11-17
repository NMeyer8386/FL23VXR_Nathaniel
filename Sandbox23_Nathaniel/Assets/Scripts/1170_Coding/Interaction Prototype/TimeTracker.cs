using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeTracker : MonoBehaviour
{
    private float timeSinceStart;   //Declare the float for time
    public TMP_Text label;          //Declare the label to change

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Tracks time since you hit play
        timeSinceStart = Time.realtimeSinceStartup; //Get and set the time since play has been pressed
        label.text = "Time Since Start: " + (Mathf.Round((timeSinceStart * 100f))/100f).ToString(); //Put it on a label and round to 2 decimal points
    }
}
