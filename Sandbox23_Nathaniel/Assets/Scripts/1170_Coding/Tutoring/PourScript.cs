using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourScript : MonoBehaviour
{
    //Declare transform of beerScale
    [SerializeField]
    private Transform beerScale;

    //Declare transform of the bottle
    [SerializeField]
    private Transform bottle;

    //Declare the bottleneck gameobject
    [SerializeField]
    private GameObject bottleNeck;

    //Declare pour rate
    public Vector3 pourRate = new Vector3(0, 0.01f, 0);

    //Declare max pour
    public float maxPour = 0.85f;


    private void OnTriggerStay(Collider other)
    {
        if (bottleNeck.CompareTag("bottleNeck") && beerScale.transform.localScale.y < maxPour )
        {
            //Same as beerscale.transform.localScale = beerScale.transform.localScale + pourRate;
            beerScale.transform.localScale += pourRate;
        }
    }
}
