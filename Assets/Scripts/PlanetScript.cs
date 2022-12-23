using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    [SerializeField] private Transform spinningElements;

    [SerializeField] private float planetRotateSpeed;


    void Update()
    {
        float planetSpeed = planetRotateSpeed * Time.deltaTime;
        spinningElements.Rotate(Vector3.up, planetSpeed);
    }
}