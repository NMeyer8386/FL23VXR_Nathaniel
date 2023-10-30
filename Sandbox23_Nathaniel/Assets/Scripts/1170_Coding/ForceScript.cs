using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceScript : MonoBehaviour
{
    //Public Declarations
    public GameObject theCube;
    public Rigidbody theBody;

    //Private Declarations
    private GameObject thePrivateThing;
    //Meatball menu in inspector > switch normal to debug allows you to see private variables

    private void Start()
    {
        theCube = GetComponent<GameObject>();
        theBody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        TouchCube();
    }

    //LETS YOU CALL A FUNCTION FROM THE INSPECTOR WHAAAAAT
    [ContextMenu("AddForce")]
    public void TouchCube()
    {
        theBody.AddForce(new Vector3(transform.position.x, transform.position.y + 100f, transform.position.z));
        Debug.Log("touched");
    }
}
