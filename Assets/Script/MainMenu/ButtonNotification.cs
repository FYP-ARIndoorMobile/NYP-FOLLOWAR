using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNotification : MonoBehaviour
{

    [SerializeField]
    GameObject thePanel;
    [SerializeField]
    GameObject theImg1;
    [SerializeField]
    GameObject theImg2;

    [SerializeField]
    GameObject closed_image;
    [SerializeField]
    GameObject opened_image;

    bool isActive;
    //private int counter = 0;

    void Start()
    {
        thePanel.SetActive(false);

        opened_image.SetActive(false);
        closed_image.SetActive(true);
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

            opened_image.SetActive(true);
            closed_image.SetActive(false);

        }
        else
        {
            opened_image.SetActive(false);
            closed_image.SetActive(true);

            thePanel.SetActive(false);
            theImg1.SetActive(false);
            theImg2.SetActive(false);

        }

    }
}
