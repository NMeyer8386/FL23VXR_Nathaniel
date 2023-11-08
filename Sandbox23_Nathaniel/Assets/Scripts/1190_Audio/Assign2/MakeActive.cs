using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeActive : MonoBehaviour
{
    [SerializeField] GameObject[] things;

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject thing in things)
        {
            thing.SetActive(true);
        }
    }
}