using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButton : MonoBehaviour
{
    public GameObject[] rootButton;

    int ChangeCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rootButton[0].SetActive(true);
        rootButton[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void OnClick()
    {
            ChangeCount += 1;

            if (ChangeCount == 1)
            {
                rootButton[0].SetActive(false);
                rootButton[1].SetActive(true);
            }
            else if (ChangeCount >= 2)
            {
                rootButton[0].SetActive(true);
                rootButton[1].SetActive(false);
                ChangeCount = 0;
            }
    }


}
