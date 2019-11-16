using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrationManager: MonoBehaviour
{
    public Slider volSlider;

    void Start()
    {
        if (volSlider)
        volSlider.value = PlayerPrefs.GetFloat("VibVolume");
    }
    void Update()
    {
 
    }
    public void VibrateToggle(float volume)
    {
        PlayerPrefs.SetFloat ("VibVolume", volSlider.value);
        volume = volSlider.value;
        Debug.Log(volume);
    }

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
