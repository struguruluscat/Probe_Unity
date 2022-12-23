using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoCanvas : MonoBehaviour
{
    GameHandler gameHandler;
    BuildManager buildManager;


    private void Start()
    {
        gameHandler = FindObjectOfType<GameHandler>().GetComponent<GameHandler>();    
        buildManager = FindObjectOfType<BuildManager>().GetComponent<BuildManager>();
    }


    public void BuildCubeButton() 
    { 
        buildManager.LegoSelector("Cube");
    }


    public void BuildCockpitButton()
    {
        buildManager.LegoSelector("Cockpit");
    }


    public void BuildThrusterButton()
    {
        buildManager.LegoSelector("Thruster");
    }

    public void BuildDrill3x5eButton()
    {
        buildManager.LegoSelector("Drill3x5");
    }


    public void OnClickSaveButton() 
    {
        gameHandler.Save();
    }


    public void OnClickLoadButton() 
    {
        gameHandler.Load();
    }
}