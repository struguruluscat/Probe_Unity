using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private List<Vector3> legoPositions;
    private List<Quaternion> legoRotations;
    private List<string> legoTypes;

    BuildManager buildManager;


    private void Start()
    {
        buildManager = FindObjectOfType<BuildManager>().GetComponent<BuildManager>();
    }


    private void Awake()
    {
        SaveSystem.Init();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Load();
        }
    }


    public void Save()
    {
        SaveObject saveObject = new SaveObject();


        saveObject.elementPosition_list = legoPositions;
        saveObject.elementRotation_list = legoRotations;
        saveObject.elementType_list = legoTypes;

        string json = JsonUtility.ToJson(saveObject);

        SaveSystem.Save(json);

        Debug.Log("Saved!");
    }


    public void Load()
    {
        //Get data from save file text;
        string saveString = SaveSystem.Load();

        if (saveString != null)
        {
            Debug.Log("Loaded: " + saveString);
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            List<Vector3> posData = saveObject.elementPosition_list;
            List<Quaternion> rotData = saveObject.elementRotation_list;
            List<string> typeData = saveObject.elementType_list;

            buildManager.BuildFromSaveFile(posData,rotData, typeData);
        }
        else
        {
            Debug.Log("No save");
        }
    }


    public void UpdateLegoPositions(List<Vector3> positions) 
    {
        legoPositions = positions;
    }


    public void UpdateLegoRotations(List<Quaternion> rotations)
    {
        legoRotations = rotations;
    }


    public void UpdateLegoTypes(List<string> types) 
    {
        legoTypes = types;
    }


    private class SaveObject
    {
        public List<Vector3> elementPosition_list;
        public List<Quaternion> elementRotation_list;
        public List<string> elementType_list;
    }
}