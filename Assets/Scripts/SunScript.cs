using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{
    [SerializeField] private Transform sunCam_tr;


    private void Update()
    {
        transform.LookAt(sunCam_tr);
    }
}