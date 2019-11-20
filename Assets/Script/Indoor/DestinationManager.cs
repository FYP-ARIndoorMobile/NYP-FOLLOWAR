using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationManager : BaseButtonController
{

    private meshLine rootG;
    [SerializeField] private GameObject line;

    private RootController rootController;
    [SerializeField] private GameObject Controller;

    public GameObject endPointPrefab;
    private GameObject endPointObj;
   
    public GameObject[] desk;
    
    [SerializeField] private GameObject[] PointOfInterests;

    [SerializeField] private GameObject[] spawnPoints;

    public IndoorUIManager IndoorUI;
    private bool reachedMsgPlayed;
    void Start()
    {
        rootG = line.GetComponent<meshLine>();
        rootController = Controller.GetComponent<RootController>();

        foreach (GameObject interestPoint in PointOfInterests)
        {
            interestPoint.SetActive(false);
        }

        Controller.transform.position += new Vector3(3,0,3);
    }


    private void Update()
    {
        if (endPointObj != null)
        {
            endPointObj.transform.LookAt(DebugUIManager.instance.FirstPersonCamera.transform.position);
            endPointObj.transform.Rotate(0, 180, 0);
            endPointObj.transform.rotation = Quaternion.Euler(0, endPointObj.transform.rotation.eulerAngles.y, 0);
            //endPointObj.transform.LookAt(rootG.target);
            
            if (Vector3.Distance(DebugUIManager.instance.FirstPersonCamera.transform.position, endPointObj.transform.position) < 3 && reachedMsgPlayed == false)
            {
                IndoorUI.Reached.SetActive(true);
                reachedMsgPlayed = true;
            }
        }

    }
    protected override void OnClick(string objectName)
    {
        ButtonClick(objectName);
    }

    private void ButtonClick(string objectName)
    { 
        Reset();

        for (int i=1;i<desk.Length;i++)
        {
            if (("Button" + i).Equals(objectName))
            {
                i = i - 1;
                rootG.target = desk[i].transform;
                //desk[i].SetActive(true);

                rootController.InstantiateFlag = true;
                if (endPointObj == null)
                {
                    endPointObj = Instantiate(endPointPrefab, desk[i].transform.position, desk[i].transform.rotation);
                }
                else
                {
                    endPointObj.transform.position = desk[i].transform.position;
                    endPointObj.transform.rotation = desk[i].transform.rotation;
                }
                i = i + 1;
            }
        }      
    }

    public void DestinationSelect(string objectName)
    {
        Reset();
        reachedMsgPlayed = false;
        foreach (GameObject destination in desk)
        {
            if (destination.name == objectName)
            {
                rootG.target = destination.transform;
                //destination.SetActive(true);

                rootController.InstantiateFlag = true;

                if (endPointObj == null)
                {
                    endPointObj = Instantiate(endPointPrefab, destination.transform.position, destination.transform.rotation);
                }
                else
                {
                    endPointObj.transform.position = destination.transform.position;
                    endPointObj.transform.rotation = destination.transform.rotation;
                }
                return;
            }
        }
        IndoorUI.Invalid.SetActive(true);
    }

    public void Reset()
    {
        GameObject[] deskTag = GameObject.FindGameObjectsWithTag("Arrow Prefab");
        
        rootG.arrowPoint.transform.position = rootG.StartingPoint.transform.position;
        // 目的地以外のドアを消す
        foreach (GameObject door in desk)
        {
            door.SetActive(false);

        }

        // ベンチを消す
        foreach (GameObject interestPoint in PointOfInterests)
        {
            interestPoint.SetActive(false);
        }

        for (int i = 0; i < deskTag.Length; i++)
        {
            Destroy(deskTag[i]);
        }
    }

    public void Reset2()
    {
        rootController.InstantiateFlag = true;
    }

    public void FindNearestPOI()
    {
        float nearstObjDist = float.MaxValue;
        GameObject nearestObject = null;
        float ObjDist;

        rootController.InstantiateFlag = true;
        reachedMsgPlayed = false;

        //Find nearest interestPoint
        foreach (GameObject interestPoint in PointOfInterests)
        {
            ObjDist = Vector3.Distance(DebugUIManager.instance.FirstPersonCamera.transform.position, interestPoint.transform.position);
            if (ObjDist < nearstObjDist)
            {
                nearstObjDist = ObjDist;
                nearestObject = interestPoint;
            }
        }

        rootG.target = nearestObject.transform;

        if (endPointObj == null)
        {
            endPointObj = Instantiate(endPointPrefab, nearestObject.transform.position, nearestObject.transform.rotation);
        }
        else
        {
            endPointObj.transform.position = nearestObject.transform.position;
            endPointObj.transform.rotation = nearestObject.transform.rotation;
        }
    }

    public GameObject[] GetSpawnPoints()
    {
        return spawnPoints;
    }
}
