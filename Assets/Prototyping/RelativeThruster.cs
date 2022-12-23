using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeThruster : MonoBehaviour
{
    [SerializeField] private GameObject fmm;
    [SerializeField] private float force;

    private Rigidbody thruster_rb;
    PlayerInput playerInput;


    private void Start()
    {
        Instantiate(fmm, transform.position, transform.rotation);
        playerInput = transform.root.GetComponent<PlayerInput>();
        thruster_rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        if (playerInput.leftShift_isHeldDown) 
        {
            float step = force * Time.deltaTime;

            Instantiate(fmm, transform.position, transform.rotation);
            thruster_rb.AddForceAtPosition(transform.forward * step, transform.position, ForceMode.Acceleration);
        }    
    }
}