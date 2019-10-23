using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndoorUIComponent : MonoBehaviour
{
    private IndoorUIManager indoorUIManager;

    // Start is called before the first frame update
    void Start()
    {
        indoorUIManager = GetComponentInParent<IndoorUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        indoorUIManager.OnClick(this.gameObject);
    }
}
