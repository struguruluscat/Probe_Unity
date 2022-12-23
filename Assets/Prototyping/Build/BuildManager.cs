using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GameObject legoToPlace;
    [SerializeField] private Transform lego_holder;
    [SerializeField] private Transform ship_tr;

    private int list_index;

    private GameObject white_lego;

    [SerializeField] private GameObject core_lego;
    [SerializeField] private GameObject cube_lego;
    [SerializeField] private GameObject thruster_lego;
    [SerializeField] private GameObject cockpit_lego;
    [SerializeField] private GameObject drill_3x5_lego;


    [SerializeField] private GameObject core_play_lego;
    [SerializeField] private GameObject cube_play_lego;
    [SerializeField] private GameObject thruster_play_lego;
    [SerializeField] private GameObject cockpit_play_lego;
    [SerializeField] private GameObject drill_3x5_play_lego;

    [HideInInspector] public List<Vector3> legoPositions_list;
    [HideInInspector] public List<Quaternion> legoRotations_list;
    [HideInInspector] public List<string> legoTypes_list;

    UberCameraController camController;
    GameHandler gameHandler;


    private void Start()
    {
        camController = Camera.main.GetComponent<UberCameraController>();
        gameHandler = GetComponent<GameHandler>();
        if (legoToPlace == null)
            legoToPlace = cube_lego;
    }


    private void Update()
    {
        OnClickDetection();
        OnRightClick();
        ChangeCameraTarget();
    }


    private void Constructor(Transform parent, Vector3 placePosition, Vector3 eulerAngles)
    {
        GameObject go = Instantiate(legoToPlace, placePosition, Quaternion.identity) as GameObject;
        go.transform.eulerAngles = eulerAngles;
        go.transform.parent = parent;
    }


    public void LegoSelector(string type) 
    {
        if (type == "Cube")
            legoToPlace = cube_lego;

        if (type == "Cockpit")
            legoToPlace = cockpit_lego;

        if (type == "Thruster")
            legoToPlace = thruster_lego;

        if (type == "Drill3x5")
            legoToPlace = drill_3x5_lego;
    }


    public void BuildFromSaveFile(List<Vector3> positionsFromFile,List<Quaternion> rotationFromFile, List<string> typesFromFile)
    {
        List<Vector3> posData = positionsFromFile;
        List<Quaternion> rotData = rotationFromFile;
        List<string> typeData = typesFromFile;

        int element_count = posData.Count;

        foreach (Transform tr in ship_tr)
        {
            Destroy(tr.gameObject);
        }

        for (int i = 0; i < element_count; i++)
        {
            Vector3 pos = posData[list_index];
            Quaternion rot = rotData[list_index];
            string type = typeData[list_index];

            if (type == "Core")
                white_lego = core_play_lego;
            if (type == "Cube")
                white_lego = cube_play_lego;
            if (type == "Thruster")
                white_lego = thruster_play_lego;
            if (type == "Cockpit")
                white_lego = cockpit_play_lego;
            if (type == "Drill3x5")
                white_lego = drill_3x5_play_lego;

            GameObject myLego = Instantiate(white_lego, pos, rot) as GameObject;
            myLego.transform.position = pos;
            myLego.transform.name = type;
            myLego.transform.parent = ship_tr;

            list_index++;
        }

        list_index = 0;
    }


    private void BuildFromLists()
    {
        foreach (Transform tr in ship_tr)
        {
            Destroy(tr.gameObject);
        }

        for (int i = 0; i < lego_holder.childCount; i++)
        {
            Vector3 pos = legoPositions_list[list_index];

            string type = legoTypes_list[list_index];

            if (type == "Core")
                white_lego = cube_lego;
            if (type == "Cube")
                white_lego = cube_lego;
            if (type == "Thruster")
                white_lego = thruster_lego;
            if (type == "Cockpit")
                white_lego = cockpit_lego;
            if (type == "Drill3x5")
                white_lego = drill_3x5_lego;

            GameObject myLego = Instantiate(white_lego, pos, Quaternion.identity) as GameObject;
            myLego.transform.position = pos;
            myLego.transform.name = type;
            myLego.transform.parent = ship_tr;

            list_index++;
        }

        list_index = 0;
    }


    private void ListUpdater()
    {
        legoPositions_list = new List<Vector3>();
        legoRotations_list = new List<Quaternion>();
        legoTypes_list = new List<string>();
        

        foreach (Transform tr in lego_holder)
        {
            LegoScript legoScript = tr.GetComponent<LegoScript>();
            string legoType = legoScript.elementType;
            legoPositions_list.Add(tr.position);
            legoRotations_list.Add(tr.rotation);
            legoTypes_list.Add(legoType);
           
            gameHandler.UpdateLegoPositions(legoPositions_list);
            gameHandler.UpdateLegoRotations(legoRotations_list);
            gameHandler.UpdateLegoTypes(legoTypes_list);
        }
    }


    private void OnClickDetection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                Transform hitRoot = hitInfo.transform.parent.parent;
                Vector3 placePos = new Vector3();
                Vector3 eulerAngles = new Vector3();

                if (hitInfo.transform.name == "Collider_Front")
                {
                    if (legoToPlace == thruster_lego)
                        return;
                    else
                        placePos = new Vector3(hitRoot.position.x, hitRoot.position.y, hitRoot.position.z + 1f);
                }
                if (hitInfo.transform.name == "Collider_Back")
                {
                    if (legoToPlace == thruster_lego)
                        return;
                    else
                        placePos = new Vector3(hitRoot.position.x, hitRoot.position.y, hitRoot.position.z - 1f);
                }
                if (hitInfo.transform.name == "Collider_Left")
                {
                    if (legoToPlace == thruster_lego)
                    {
                        placePos = hitRoot.position;
                        eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
                    }
                    else
                        placePos = new Vector3(hitRoot.position.x - 1.0f, hitRoot.position.y, hitRoot.position.z);
                }
                if (hitInfo.transform.name == "Collider_Right")
                {
                    if (legoToPlace == thruster_lego)
                    {
                        placePos = hitRoot.position;
                        eulerAngles = new Vector3(0.0f, 0.0f, 270.0f);
                    }
                    else
                        placePos = new Vector3(hitRoot.position.x + 1.0f, hitRoot.position.y, hitRoot.position.z);
                }
                if (hitInfo.transform.name == "Collider_Up")
                {
                    if(legoToPlace == thruster_lego) 
                    {
                        placePos = hitRoot.position;
                        eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                    }
                    else
                        placePos = new Vector3(hitRoot.position.x, hitRoot.position.y + 1.0f, hitRoot.position.z);
                }
                if (hitInfo.transform.name == "Collider_Down")
                {
                    if (legoToPlace == thruster_lego)
                    {
                        placePos = hitRoot.position;
                        eulerAngles = new Vector3(0.0f, 0.0f, 180.0f);
                    }
                    else
                        placePos = new Vector3(hitRoot.position.x, hitRoot.position.y - 1.0f, hitRoot.position.z);
                }

                Constructor(hitRoot.parent, placePos, eulerAngles);
                ListUpdater();
            }
        }
    }


    private void OnRightClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                if (hitInfo.transform.parent.parent.name == "Core")
                    return;
                else
                {
                    GameObject go = hitInfo.transform.parent.parent.gameObject;
                    Destroy(go);
                }
            }
        }
    }


    private void ChangeCameraTarget() 
    {
        if (Input.GetMouseButtonDown(2))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                Transform camTarget = hitInfo.transform.parent.parent;
                camController.target = camTarget.gameObject;
            }
        }
    }
}