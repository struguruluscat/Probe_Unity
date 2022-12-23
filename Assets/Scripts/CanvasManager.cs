using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Text distance_text;

    GameController gameController;


    private void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>().GetComponent<GameController>();
    }


    public void UpdateDistanceText(float distanceValue) 
    {
        distance_text.text = distanceValue.ToString("F0") + " m";
    }

    public void ResetButton() 
    {
        gameController.ResetScene();
    }
}