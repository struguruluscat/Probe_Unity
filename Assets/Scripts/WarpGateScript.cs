using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpGateScript : MonoBehaviour
{
    [SerializeField] private Transform outerRing;
    [SerializeField] private Transform innerRing;

    [SerializeField] private float outerRingRotateSpeed;
    [SerializeField] private float innerRingRotateSpeed;


    private void Update()
    {
        float outRingSpeed = outerRingRotateSpeed * Time.deltaTime;
        float inRingSpeed = innerRingRotateSpeed * -1.0f * Time.deltaTime;

        outerRing.Rotate(Vector3.up, outRingSpeed);
        innerRing.Rotate(Vector3.up, inRingSpeed);
    }
}