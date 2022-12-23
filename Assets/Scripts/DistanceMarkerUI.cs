using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayUI : MonoBehaviour
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
        Vector3 pos = cam.WorldToScreenPoint(lookAt.position + offset);

        if (transform.position != pos)
            transform.position = pos;
    }
}