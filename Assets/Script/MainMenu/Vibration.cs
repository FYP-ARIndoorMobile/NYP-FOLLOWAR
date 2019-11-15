using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vibration : MonoBehaviour
{
    public static Vibration _instance;
    // public Slider slider_Vibration;
    // public Toggle toggle_Dark;

    //public static Vibration Instance
    //{
    //    get
    //    {
    //        if (_instance == null)
    //        {
    //            _instance = GameObject.FindObjectOfType<Vibration>();
    //            _instance = this;
    //        }
    //        else (_instance != null)
    //        return _instance;
    //    }
    //}
    //private void Awake()
    //{

    //        //Check if instance already exists
    //        if (_instance == null)
    //        {
    //            //if not, set instance to this
    //            _instance = this;
    //        }
    //        //If instance already exists and it's not this:
    //        else if (_instance != this)
    //        {
    //            Destroy(gameObject);
    //        }

    //        DontDestroyOnLoad(gameObject);


    //}
    //void Start()
    //{
    //    if (slider_Vibration == null)
    //    slider_Vibration = GameObject.FindGameObjectWithTag("SliderVibrate").GetComponent<Slider>();
    //}

    //public void VibrateToggle()
    //{
    //    if (slider_Vibration.value == 1)
    //    {

    //        Vibrate();
    //    }

    //}
    public void Vibrate()
    {
        StartCoroutine("VibrateDuration", 1.0f);
    }
    IEnumerator VibrateDuration(float waitTime)
    {
        Handheld.Vibrate();
        yield return new WaitForSeconds(waitTime);
       // print("Vibrate Stop");
    }



}
