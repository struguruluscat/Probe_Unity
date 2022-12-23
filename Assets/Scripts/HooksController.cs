using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HooksController : MonoBehaviour
{
    private Transform target;
    HingeJoint hingeJoint;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Asteroid")
        ConnectToTarget(other.attachedRigidbody);
    }


    void ConnectToTarget(Rigidbody rb) 
    {
        hingeJoint = gameObject.AddComponent<HingeJoint>();
        hingeJoint.axis = new Vector3(0.0f, 90.0f, 0.0f);
        hingeJoint.useLimits = true;
        JointLimits limits = hingeJoint.limits;
        limits.min = -20f;
        limits.max = 20f;
        limits.bounciness = 0;
        limits.bounceMinVelocity = 0;
        hingeJoint.limits = limits;
        hingeJoint.connectedBody = rb;
    }
}