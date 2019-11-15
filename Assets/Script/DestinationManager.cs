using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationManager : BaseButtonController
{

    private meshLine rootG;
    [SerializeField] private GameObject line;

    private RootController rootController;
    [SerializeField] private GameObject Controller;

   
    public GameObject[] desk;

    //public GameObject endPointPrefab;
    //private GameObject endPointObj;

    private bool displayPointOfInterests;

    [SerializeField] private GameObject[] PointOfInterests;

    [SerializeField] private GameObject[] spawnPoints;

    public IndoorUIManager IndoorUI;

    void Start()
    {
        rootG = line.GetComponent<meshLine>();
        rootController = Controller.GetComponent<RootController>();

        foreach (GameObject interestPoint in PointOfInterests)
        {
            interestPoint.SetActive(false);
        }
        //DestinationSelect("622");
       // FindNearestPOI();
        //TogglePointOfInterets();
    }


    private void Update()
    {
        if (displayPointOfInterests == true)
        {
            //FindNearestPOI();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Reset();
            Reset2();
            DestinationSelect("622");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Reset();
            Reset2();
            TogglePointOfInterets();
            FindNearestPOIfromGuideObj();
        }

        //if (endPointObj != null)
        //{
        //    endPointObj.transform.rotation = Quaternion.Euler(0, endPointObj.transform.rotation.eulerAngles.y, 0);
        //    endPointObj.transform.LookAt(DebugUIManager.instance.FirstPersonCamera.transform.position);
        //    endPointObj.transform.Rotate(0, 180, 0);
        //    //endPointObj.transform.LookAt(rootG.target);
        //}

    }
    protected override void OnClick(string objectName)
    {
        // 渡されたオブジェクト名で処理を分岐

        //if("Button1".Equals(objectName)){ this.Button1Click(); }
        //if("Button2".Equals(objectName)){ this.Button2Click(); }
        //else{ throw new System.Exception("Not implemented!!"); }

        ButtonClick(objectName);
    }

    private void ButtonClick(string objectName)
    { 
        Reset();

        for (int i=1;i<desk.Length;i++)
        {
            if (("Button" + i).Equals(objectName))
            {
                displayPointOfInterests = false;

                i = i - 1;
                rootG.target = desk[i].transform;
                //desk[i].SetActive(true);

                rootController.InstantiateFlag = true;
                //if (endPointObj == null)
                //{
                //    //endPointObj = Instantiate(endPointPrefab, desk[i].transform.position, desk[i].transform.rotation);
                //}
                //else
                //{
                //    endPointObj.transform.position = desk[i].transform.position;
                //    endPointObj.transform.rotation = desk[i].transform.rotation;
                //}
                i = i + 1;
            }

            else if ("Button9".Equals(objectName))
            {
                TogglePointOfInterets();
       
            }
        }      
    }

    public void DestinationSelect(string objectName)
    {
        Reset();
        foreach (GameObject destination in desk)
        {
            if (destination.name == objectName)
            {
                displayPointOfInterests = false;
                rootG.target = destination.transform;
                //destination.SetActive(true);

                rootController.InstantiateFlag = true;

                //if (endPointObj == null)
                //{
                //    //endPointObj = Instantiate(endPointPrefab, destination.transform.position, destination.transform.rotation);
                //}
                //else
                //{
                //    endPointObj.transform.position = destination.transform.position;
                //    endPointObj.transform.rotation = destination.transform.rotation;
                //}
                return;
            }
        }
        IndoorUI.Invalid.SetActive(true);
    }

    //private void Button2Click()
    //{
    //    GameObject[] deskTag = GameObject.FindGameObjectsWithTag("Star");

    //    for(int i=0;i<deskTag.Length;i++)
    //    {
    //        Destroy(deskTag[i]);
    //    }

    //}

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

    public void TogglePointOfInterets()
    {
        displayPointOfInterests = !displayPointOfInterests;
        foreach (GameObject interestPoint in PointOfInterests)
        {
            interestPoint.SetActive(displayPointOfInterests);
            rootG.target = interestPoint.transform;
        }
    }

    private void FindNearestPOI()
    {
        float nearstObjDist = float.MaxValue;
        GameObject nearestObject = null;
        float ObjDist;

        rootController.InstantiateFlag = true;
        foreach (GameObject interestPoint in PointOfInterests)
        {
            ObjDist = Vector3.Distance(DebugUIManager.instance.FirstPersonCamera.transform.position, interestPoint.transform.position);
            if (ObjDist < nearstObjDist)
            {
                nearstObjDist = ObjDist;
                nearestObject = interestPoint;
            }
        }

        foreach (GameObject interestPoint in PointOfInterests)
        {
            if (interestPoint == nearestObject)
            {
               //interestPoint.SetActive(true);
               rootG.target = interestPoint.transform;
            }
            else
            {
                interestPoint.SetActive(false);
            }
        }
    }

    private void FindNearestPOIfromGuideObj()
    {
        float nearstObjDist = float.MaxValue;
        GameObject nearestObject = null;
        float ObjDist;

        rootController.InstantiateFlag = true;
        foreach (GameObject interestPoint in PointOfInterests)
        {
            ObjDist = Vector3.Distance(Controller.transform.position, interestPoint.transform.position);
            if (ObjDist < nearstObjDist)
            {
                nearstObjDist = ObjDist;
                nearestObject = interestPoint;
            }
        }

        Debug.Log(nearestObject.name);

        foreach (GameObject interestPoint in PointOfInterests)
        {
            if (interestPoint == nearestObject)
            {
                //interestPoint.SetActive(true);
                rootG.target = interestPoint.transform;
            }
            else
            {
                interestPoint.SetActive(false);
            }
        }
    }

    public GameObject[] GetSpawnPoints()
    {
        return spawnPoints;
    }
}
