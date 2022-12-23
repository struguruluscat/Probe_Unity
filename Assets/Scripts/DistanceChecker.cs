using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    [HideInInspector] public Transform target;

    [SerializeField] private float distance;
    
    CanvasManager canvasManager;
    DistanceMarkerUI distanceMarker;

    private void Start()
    {
        canvasManager = FindObjectOfType<Canvas>().GetComponent<CanvasManager>();
        distanceMarker = canvasManager.transform.GetComponentInChildren<DistanceMarkerUI>();
    }


    private void FixedUpdate()
    {
        if (target != null) 
        {
            RaycastTarget();
        }
    }


    private void RaycastTarget() 
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, (target.position - transform.position), out hit, Mathf.Infinity, layerMask))
        {
            distanceMarker.lookAt = hit.transform;
            Vector3 hitPoint = hit.point;
            distance = Vector3.Distance(transform.position, hitPoint);
            canvasManager.UpdateDistanceText(distance);
        }
    }
}