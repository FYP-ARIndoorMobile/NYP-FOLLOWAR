using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToggle : MonoBehaviour
{
    [SerializeField]
    GameObject thePanel;
    [SerializeField]
    GameObject theoptionbuttonPanel;
    [SerializeField]
    GameObject theImg1;
    [SerializeField]
    GameObject theImg2;



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
            theImg1.SetActive(false);
            theImg2.SetActive(false);

            theoptionbuttonPanel.SetActive(false);
        }
        else
        {
            thePanel.SetActive(false);
            theImg1.SetActive(false);
            theImg2.SetActive(false);
            theoptionbuttonPanel.SetActive(false);

        }
    }
}
