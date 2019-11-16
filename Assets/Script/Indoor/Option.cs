using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public Canvas theOptionCanvas;
    // Start is called before the first frame update
    void Start()
    {
        if (theOptionCanvas != null)
            theOptionCanvas = GameObject.Find("Option Canvas").GetComponentInChildren<Canvas>();
            //theOptionCanvas = gameObject
    }

    public void DisablePrefab()
    {
        theOptionCanvas.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
