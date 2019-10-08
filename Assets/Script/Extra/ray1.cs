using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray1 : MonoBehaviour
{
    public GameObject lineObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickAct()
    {
        Instantiate(lineObj, gameObject.transform);

    }
}
