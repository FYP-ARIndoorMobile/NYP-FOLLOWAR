using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNotification : MonoBehaviour
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
        theoptionbuttonPanel.SetActive(false);

    }
    public void ImageActive()
    {
        isActive = !isActive;
        //counter++;
        //isON = true;
        if (isActive)
        {

            thePanel.SetActive(true);
            theoptionbuttonPanel.SetActive(true);
            theImg1.SetActive(false);
            theImg2.SetActive(false);
     



        }
        else
        {


            theoptionbuttonPanel.SetActive(false);
            thePanel.SetActive(false);
            theImg1.SetActive(false);
    
            theImg2.SetActive(false);

        }

    }
}
