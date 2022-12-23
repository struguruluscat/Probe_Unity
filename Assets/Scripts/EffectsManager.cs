using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    [SerializeField] private GameObject deathExplosion;


    private void Start()
    {
        deathExplosion.transform.position = Vector3.zero;
    }


    public void PlayDeathExplosion(Vector3 pos) 
    {
        deathExplosion.transform.position = pos;
        deathExplosion.SetActive(true);
    }
}