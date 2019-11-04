using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vibration : MonoBehaviour
{
    public static Vibration _instance;
    public Toggle toggle;
   // public Toggle toggle_Dark;

    public static Vibration Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Vibration>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void VibrateToggle()
    {
        if (toggle.isOn == true)
        {
           // toggle_Dark.isOn = true;
            Vibrate();
            print("Vibration is On");
        }
        else
        {
           // toggle_Dark.isOn = false;
            toggle.isOn = false;
            print("Vibration is Off");
        }
        //print("Vibration is Off");
    }
    private void Vibrate()
    {
        print("Vibrate Start");
        StartCoroutine("VibrateDuration", 1.0f);
    }
    IEnumerator VibrateDuration(float waitTime)
    {
        Handheld.Vibrate();
        yield return new WaitForSeconds(waitTime);
        print("Vibrate Stop");
    }



}
