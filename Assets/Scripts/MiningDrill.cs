using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningDrill : MonoBehaviour
{
    [SerializeField] private float drillSpeed;
    [SerializeField] private ParticleSystem drillingPebbles_PS;

    private bool targetIsAsteroid;


    private void Start()
    {
        targetIsAsteroid = false;
    }


    void Update()
    {
        float rate = drillSpeed * 10f * Time.deltaTime;
        transform.Rotate(Vector3.forward * rate);

        if (targetIsAsteroid)
            drillingPebbles_PS.Play();
        else
            drillingPebbles_PS.Stop();
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Asteroid")
            targetIsAsteroid = true;
    }

    private void OnTriggerExit(Collider other)
    {
        targetIsAsteroid = false;
    }


    private void OnDisable()
    {
        drillingPebbles_PS.Stop();
    }
}