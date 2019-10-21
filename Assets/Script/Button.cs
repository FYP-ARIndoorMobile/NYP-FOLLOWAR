using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : BaseButtonController
{

    private meshLine rootG;
    [SerializeField] private GameObject line;

    private RootController rootController;
    [SerializeField] private GameObject Controller;

    public Transform[] desk;

    public GameObject endPointPrefab;
    private GameObject endPointObj;


    private bool displayPointOfInterests;
    [SerializeField] private GameObject[] PointOfInterests;



    void Start()
    {
        rootG = line.GetComponent<meshLine>();
        rootController = Controller.GetComponent<RootController>();
    
   
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
        if ("Button1".Equals(objectName))
        {
            rootG.target = desk[0];
            if (endPointObj == null)
            {
                endPointObj = Instantiate(endPointPrefab, desk[0].transform.position + new Vector3(0, 0.2f, 0), desk[0].transform.rotation);
            }
            else
            {
                endPointObj.transform.position = desk[0].transform.position + new Vector3(0, 0.2f, 0);
                endPointObj.transform.rotation = desk[0].transform.rotation;
            }
        }
        else if ("Button2".Equals(objectName))
        {
            rootG.target = desk[1];
            if (endPointObj == null)
            {
                endPointObj = Instantiate(endPointPrefab, desk[1].transform.position + new Vector3(0, 0.2f, 0), desk[0].transform.rotation);
            }
            else
            {
                endPointObj.transform.position = desk[1].transform.position + new Vector3(0, 0.2f, 0);
                endPointObj.transform.rotation = desk[1].transform.rotation;
            }
        }
        else if ("Button3".Equals(objectName))
        {
            rootG.target = desk[2];
            if (endPointObj == null)
            {
                endPointObj = Instantiate(endPointPrefab, desk[2].transform.position + new Vector3(0, 0.2f, 0), desk[0].transform.rotation);
            }
            else
            {
                endPointObj.transform.position = desk[2].transform.position + new Vector3(0, 0.2f, 0);
                endPointObj.transform.rotation = desk[2].transform.rotation;
            }
        }
        else if ("Button4".Equals(objectName))
        {
            rootG.target = desk[3];
            if (endPointObj == null)
            {
                endPointObj = Instantiate(endPointPrefab, desk[3].transform.position + new Vector3(0, 0.2f, 0), desk[0].transform.rotation);
            }
            else
            {
                endPointObj.transform.position = desk[3].transform.position + new Vector3(0, 0.2f, 0);
                endPointObj.transform.rotation = desk[3].transform.rotation;
            }
        }
        else if ("Button5".Equals(objectName))
        {
            rootG.target = desk[4];
            if (endPointObj == null)
            {
                endPointObj = Instantiate(endPointPrefab, desk[4].transform.position + new Vector3(0, 0.2f, 0), desk[0].transform.rotation);
            }
            else
            {
                endPointObj.transform.position = desk[4].transform.position + new Vector3(0, 0.2f, 0);
                endPointObj.transform.rotation = desk[4].transform.rotation;
            }
        }
        else if ("Button6".Equals(objectName))
        {
            rootG.target = desk[5];
            if (endPointObj == null)
            {
                endPointObj = Instantiate(endPointPrefab, desk[5].transform.position + new Vector3(0, 0.2f, 0), desk[0].transform.rotation);
            }
            else
            {
                endPointObj.transform.position = desk[5].transform.position + new Vector3(0, 0.2f, 0);
                endPointObj.transform.rotation = desk[5].transform.rotation;
            }
        }
        else if ("Button7".Equals(objectName))
        {
            rootG.target = desk[6];
            if (endPointObj == null)
            {
                endPointObj = Instantiate(endPointPrefab, desk[6].transform.position + new Vector3(0, 0.2f, 0), desk[0].transform.rotation);
            }
            else
            {
                endPointObj.transform.position = desk[6].transform.position + new Vector3(0, 0.2f, 0);
                endPointObj.transform.rotation = desk[6].transform.rotation;
            }
        }
        else if ("Button8".Equals(objectName))
        {
            rootG.target = desk[7];
            if (endPointObj == null)
            {
                endPointObj = Instantiate(endPointPrefab, desk[7].transform.position + new Vector3(0, 0.2f, 0), desk[0].transform.rotation);
            }
            else
            {
                endPointObj.transform.position = desk[7].transform.position + new Vector3(0, 0.2f, 0);
                endPointObj.transform.rotation = desk[7].transform.rotation;
            }
        }
        else if ("Button9".Equals(objectName))
        {
            TogglePointOfInterets();
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
        GameObject[] deskTag = GameObject.FindGameObjectsWithTag("Star");

        rootG.arrowPoint.transform.position = rootG.StartingPoint.transform.position;


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
}
