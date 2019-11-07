using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmenitiesToggles : MonoBehaviour
{

    [SerializeField]
    GameObject ScrollListType;
    [SerializeField]
    GameObject img_closed;
    [SerializeField]
    GameObject img_open;

    [SerializeField]
    GameObject[] otherObjs;

    [SerializeField]
    GameObject[] otherScrollview;

    [SerializeField]
    GameObject[] otherButtons;

    private int noOfGameObjects = 10;
    private int noOfPanels = 6;


    [SerializeField]
    bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        ScrollListType.SetActive(false);
        img_open.SetActive(false);
        img_closed.SetActive(true);
    }
    public void ChangeToggle()
    {
        isActive = !isActive;
        img_open.SetActive(false);
        img_closed.SetActive(true);
        if (isActive)
        {
            img_open.SetActive(true);
            img_closed.SetActive(false);
            ScrollListType.SetActive(isActive);
            for (int i = 0; i < noOfGameObjects; i++)
            {
                otherObjs[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < noOfPanels; i++)
            {
                otherScrollview[i].SetActive(false);
                otherButtons[i].SetActive(true);
                img_open.SetActive(false);
            }
        }
    }
}
