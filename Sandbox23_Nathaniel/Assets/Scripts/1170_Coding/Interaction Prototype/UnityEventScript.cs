using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventScript : MonoBehaviour
{

    public UnityEvent ChangeThing;
    public GameObject cube;
    private Material objColour;
    private Vector3 originalPos = new Vector3();

    private void Start()
    {
        originalPos = cube.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //If the thing moves
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
            objColour = cube.GetComponent<Renderer>().material;
            objColour.color = Color.blue;
    }
}
