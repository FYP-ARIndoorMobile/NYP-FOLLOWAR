using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsableButton : MonoBehaviour
{
    [SerializeField]
    public GameObject thePhoto;
    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        thePhoto.SetActive(false);
    }
    public void PhotoActive()
    {
        isActive = !isActive;
        if (isActive)
        {
            thePhoto.SetActive(isActive);
        }
        else
        {
            thePhoto.SetActive(false);
        }
    }
}
