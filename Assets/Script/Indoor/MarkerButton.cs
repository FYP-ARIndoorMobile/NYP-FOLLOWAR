using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerButton : BaseButtonController
{
    public GameObject floor;
    public GameObject rootSelectButton;

    Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        rootSelectButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void OnClick(string objectName)
    {
        MButtonClick(objectName);
    }


    private void MButtonClick(string objectName)
    {
        if ("MarkerButton1".Equals(objectName)) { floor.transform.Rotate(0, 0, 0); }
        if ("MarkerButton2".Equals(objectName)) { floor.transform.Rotate(0, -180, 0); floor.transform.Translate(11, 0, 0); }
        if ("MarkerButton3".Equals(objectName)) { floor.transform.Translate(-12, 0, 0); }
        if ("MarkerButton4".Equals(objectName)) { floor.transform.Rotate(0, -180, 0); }
        rootSelectButton.SetActive(true);
        gameObject.SetActive(false);

    }
}
