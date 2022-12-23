using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    private float rotateSpeed;
    Rigidbody this_rb;

    private void Start()
    {
        transform.rotation = Random.rotation;
        this_rb = GetComponent<Rigidbody>();
        float torque = Random.Range(0.0f, 0.02f);
        this_rb.AddTorque(transform.up * torque, ForceMode.VelocityChange);
        /*
        rotateSpeed = Random.Range(0, 10);
        transform.rotation = new Quaternion(Random.Range(0,360), Random.Range(0, 360), Random.Range(0, 360), 0);
        */

    }
}

/*
    [SerializeField] private float nextAction;
    [SerializeField] private float actionRate;


    void DoStuffOverTime() 
    {
        if (Time.time > nextAction)
        {
            nextAction = Time.time + actionRate;
        }
    }
    */