using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    PlayerInput playerInput;


    void Start()
    {
        playerInput = GetComponent<PlayerInput>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
