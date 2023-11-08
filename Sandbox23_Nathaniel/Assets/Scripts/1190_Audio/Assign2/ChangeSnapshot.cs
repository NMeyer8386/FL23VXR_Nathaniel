using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSnapshot : MonoBehaviour
{
    [SerializeField] SnapshotManagerScript snapshotManager; //The snapshot manager script we're accessing
    [SerializeField] int snapshotIndex;                     //The index of the snapshot we're changing too

    private void OnTriggerEnter(Collider other)
    {
        snapshotManager.SnapshotChange(snapshotIndex);      //Change the index based off the passed index
    }
}