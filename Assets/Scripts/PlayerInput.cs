using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector] public bool leftMouseButton_isHeldDown;
    [HideInInspector] public bool rightMouseButton_isHeldDown;

    [HideInInspector] public bool w_wasPressed;
    [HideInInspector] public bool w_isHeldDown;
    [HideInInspector] public bool a_isHeldDown;
    [HideInInspector] public bool s_isHeldDown;
    [HideInInspector] public bool d_isHeldDown;
    [HideInInspector] public bool q_isHeldDown;
    [HideInInspector] public bool e_isHeldDown;
    [HideInInspector] public bool leftAlt_isHeldDown;
    [HideInInspector] public bool leftShift_isHeldDown;
    [HideInInspector] public bool c_isHeldDown;
    [HideInInspector] public bool v_isHeldDown;


    void Update()
    {
        CheckIfKeysHeldDown();

    }


    private void CheckIfKeysHeldDown() 
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            leftMouseButton_isHeldDown = true;
        }
        else
        {
            leftMouseButton_isHeldDown = false;
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            rightMouseButton_isHeldDown = true;
        }
        else
        {
            rightMouseButton_isHeldDown = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            w_isHeldDown = true;
        }
        else
        {
            w_isHeldDown = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            a_isHeldDown = true;
        }
        else
        {
            a_isHeldDown = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            s_isHeldDown = true;
        }
        else
        {
            s_isHeldDown = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            d_isHeldDown = true;
        }
        else
        {
            d_isHeldDown = false;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            q_isHeldDown = true;
        }
        else
        {
            q_isHeldDown = false;
        }

        if (Input.GetKey(KeyCode.E))
        {
            e_isHeldDown = true;
        }
        else
        {
            e_isHeldDown = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            leftShift_isHeldDown = true;
        }
        else
        {
            leftShift_isHeldDown = false;
        }

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            leftAlt_isHeldDown = true;
        }
        else
        {
            leftAlt_isHeldDown = false;
        }

        if (Input.GetKey(KeyCode.C))
        {
            c_isHeldDown = true;
        }
        else
        {
            c_isHeldDown = false;
        }

        if (Input.GetKey(KeyCode.C))
        {
            c_isHeldDown = true;
        }
        else
        {
            c_isHeldDown = false;
        }

        if (Input.GetKey(KeyCode.V))
        {
            v_isHeldDown = true;
        }
        else
        {
            v_isHeldDown = false;
        }
    }
}