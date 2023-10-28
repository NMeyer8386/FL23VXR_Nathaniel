using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointScript : MonoBehaviour
{
    public HingeJoint hinge;

    private void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useMotor = false;
    }

    public void MoveLever()
    {
        hinge.useMotor = true;
    }

    public void StopLever()
    {
        hinge.useMotor= false;
    }
}
