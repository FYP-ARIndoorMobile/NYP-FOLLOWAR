using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider theSoundSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (theSoundSlider)
            theSoundSlider.value = PlayerPrefs.GetFloat("SoundVol");
    }

    public void SoundToggle(float volume)
    {
        PlayerPrefs.SetFloat("SoundVol", theSoundSlider.value);
        volume = theSoundSlider.value;
        Debug.Log(volume);
    }
}
