using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuoption : MonoBehaviour
{
    public Canvas theoptionCanvas;
    public GameObject optionLightDark;


    // Start is called before the first frame update
    void Start()
    {
        if (theoptionCanvas == null)
            theoptionCanvas = GameObject.Find("Option Canvas").GetComponentInChildren<Canvas>();

        if (optionLightDark == null)
            optionLightDark = GameObject.FindGameObjectWithTag("Option");
    }
    public void OptionCanvasOn()
    {
        theoptionCanvas.gameObject.SetActive(true);
    }
    public void OptionCavasOff()
    {
        theoptionCanvas.gameObject.SetActive(false);
    }

    public void OptionLightDarkOn()
    {
        optionLightDark.gameObject.SetActive(true);
    }

    public void OptionLightDarkOff()
    {
        optionLightDark.gameObject.SetActive(false);
    }

}
