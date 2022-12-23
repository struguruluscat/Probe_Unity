using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceMarkerUI : MonoBehaviour
{
    public Transform lookAt;
    public Vector3 offset;

    private Camera cam;


    private void Start()
    {
        cam = Camera.main;
    }


    private void Update()
    {
        if (lookAt != null)
        {
            Vector3 pos = cam.WorldToScreenPoint(lookAt.position + offset);
            if (transform.position != pos)
                transform.position = pos;
        }
    }
}