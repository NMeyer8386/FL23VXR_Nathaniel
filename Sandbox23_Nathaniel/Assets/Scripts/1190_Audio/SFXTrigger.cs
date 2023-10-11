using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXTrigger : MonoBehaviour
{
    public AudioSource playSound;
    private GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        cube = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if(cube.tag == "red")
        {
            playSound.Stop();
        }
        else if (cube.tag == "green")
        {
            playSound.Play();
        }

    }

}
