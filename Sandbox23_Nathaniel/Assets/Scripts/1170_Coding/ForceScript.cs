using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceScript : MonoBehaviour
{
    public GameObject theCube;
    public Rigidbody theBody;

    private void Start()
    {
        theCube = GetComponent<GameObject>();
        theBody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        TouchCube();
    }

    public void TouchCube()
    {
        theBody.AddForce(new Vector3(transform.position.x, transform.position.y + 100f, transform.position.z));
        Debug.Log("touched");
    }
}
