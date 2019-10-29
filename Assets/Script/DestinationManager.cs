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

    public GameObject endPointPrefab;
    private GameObject endPointObj;


    private bool displayPointOfInterests;
    [SerializeField] private GameObject[] PointOfInterests;

    [SerializeField] private GameObject[] spawnPoints;

    void Start()
    {
        rootG = line.GetComponent<meshLine>();
        rootController = Controller.GetComponent<RootController>();

        foreach (GameObject interestPoint in PointOfInterests)
        {
            interestPoint.SetActive(false);
        }
    }


    private void Update()
    {
        if (displayPointOfInterests == true)
        {
            FindNearestPOI();
        }
        if (endPointObj != null)
        {
            endPointObj.transform.rotation = Quaternion.Euler(0, endPointObj.transform.rotation.eulerAngles.y, 0);
            endPointObj.transform.LookAt(DebugUIManager.instance.FirstPersonCamera.transform.position);
            endPointObj.transform.Rotate(0, 180, 0);
          //  endPointObj.transform.LookAt(rootG.target);

        }
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

        for(int i=1;i<desk.Length;i++)
        {
            if (("Button" + i).Equals(objectName))
            {
                i = i - 1;
                rootG.target = desk[i].transform;
                desk[i].SetActive(true);

                rootController.InstantiateFlag = true;
                if (endPointObj == null)
                {
                    endPointObj = Instantiate(endPointPrefab, desk[i].transform.position + new Vector3(0, 0.2f, 0), desk[i].transform.rotation);
                }
                else
                {
                    endPointObj.transform.position = desk[i].transform.position + new Vector3(0, 0.2f, 0);
                    endPointObj.transform.rotation = desk[i].transform.rotation;
                }
                i = i + 1;
            }

            else if ("Button9".Equals(objectName))
            {
                TogglePointOfInterets();

            }
        }      
    }

    //private void Button2Click()
    //{
    //    GameObject[] deskTag = GameObject.FindGameObjectsWithTag("Star");

    //    for(int i=0;i<deskTag.Length;i++)
    //    {
    //        Destroy(deskTag[i]);
    //    }

    //}

    private void Reset()
    {
        GameObject[] deskTag = GameObject.FindGameObjectsWithTag("Footprint");

        rootG.arrowPoint.transform.position = rootG.StartingPoint.transform.position;

        foreach (GameObject door in desk)
        {
            door.SetActive(false);

        }

        for (int i = 0; i < deskTag.Length; i++)
        {
            Destroy(deskTag[i]);
        }
    }

    public void TogglePointOfInterets()
    {
        displayPointOfInterests = !displayPointOfInterests;
        foreach (GameObject interestPoint in PointOfInterests)
        {
            interestPoint.SetActive(displayPointOfInterests);
          
        }
    }

    private void FindNearestPOI()
    {
        float nearstObjDist = float.MaxValue;
        GameObject nearestObject = null;
        float ObjDist;

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
                interestPoint.SetActive(true);
               rootG.target = interestPoint.transform;
            }
            else
            {
                interestPoint.SetActive(false);
            }
        }

        //if (nearestObject != null)
        //{
        //    DebugUIManager.instance.UpdatingDebugLog(nearestObject.name);
        //}
        //else
        //{
        //    DebugUIManager.instance.UpdatingDebugLog("No OBJ");
        //}
    }

    public GameObject[] GetSpawnPoints()
    {
        return spawnPoints;
    }
}
