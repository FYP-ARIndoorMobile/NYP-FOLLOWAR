using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomVibrate : MonoBehaviour
{
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
