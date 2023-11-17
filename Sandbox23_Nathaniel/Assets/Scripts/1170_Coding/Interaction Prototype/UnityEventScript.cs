using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventScript : MonoBehaviour
{
    public UnityEvent ChangeThing;                  //Declare the event
    public GameObject cube;                         //Declare the object to manipulate
    private Material objColour;                     //Declare the material to change
    private Vector3 originalPos = new Vector3();    //Declare original position of the cube

    private void Start()
    {
        originalPos = cube.transform.position;      //Set the original position once play mode is entered
    }

    // Update is called once per frame
    void Update()
    {
        //If the thing moves too far
        if (cube.transform.position.x >= (originalPos.x + .5f)
         || cube.transform.position.y >= (originalPos.y + .5f) 
         || cube.transform.position.z >= (originalPos.z + .5f))
        {
            //Change it
            ChangeThing.Invoke();
        }
    }

    //Changes colour to blue
    public void ChangeColour()
    {
            objColour = cube.GetComponent<Renderer>().material; //Get the material so we can change it
            objColour.color = Color.blue;                       //Change the material
    }
}
