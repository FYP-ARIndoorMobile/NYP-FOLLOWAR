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

    void Start()
    {
        rootG = line.GetComponent<meshLine>();
        rootController = Controller.GetComponent<RootController>();
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
        if ("Button1".Equals(objectName)) { rootG.target = desk[0]; rootController.InstantiateFlag = true; }
        if ("Button2".Equals(objectName)) { rootG.target = desk[1]; rootController.InstantiateFlag = true; }
        if ("Button3".Equals(objectName)) { rootG.target = desk[2]; rootController.InstantiateFlag = true; }
        if ("Button4".Equals(objectName)) { rootG.target = desk[3]; rootController.InstantiateFlag = true; }
        if ("Button5".Equals(objectName)) { rootG.target = desk[4]; rootController.InstantiateFlag = true; }
        if ("Button6".Equals(objectName)) { rootG.target = desk[5]; rootController.InstantiateFlag = true; }
        if ("Button7".Equals(objectName)) { rootG.target = desk[6]; rootController.InstantiateFlag = true; }
        if ("Button8".Equals(objectName)) { rootG.target = desk[7]; rootController.InstantiateFlag = true; }
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

        for (int i = 0; i < deskTag.Length; i++)
        {
            Destroy(deskTag[i]);
        }
    }
}
