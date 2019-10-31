using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToggle : MonoBehaviour
{
    [SerializeField]
    GameObject thePanel;
    [SerializeField]
    GameObject theBtn1;
    [SerializeField]
    GameObject theBtn2;

    bool isActive;
    //private int counter = 0;

    void Start()
    {
        thePanel.SetActive(false);
    }
    public void ImageActive()
    {
        isActive = !isActive;
        //counter++;
        //isON = true;
        if (isActive)
        {
           
            thePanel.SetActive(true);
            theBtn1.SetActive(false);
            theBtn2.SetActive(false);
        }
        else
        {

            thePanel.SetActive(false);
            theBtn1.SetActive(false);
            theBtn2.SetActive(false);
          
        }
    }
}
