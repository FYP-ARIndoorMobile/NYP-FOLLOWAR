using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSound : MonoBehaviour
{
    public AudioSource soundFx;
    // Start is called before the first frame update


    void Start()
    {
       soundFx = GetComponent<AudioSource>();
        soundFx.volume = PlayerPrefs.GetFloat("SoundVol");
    }

    public void PP()
    {

        if (PlayerPrefs.GetFloat("SoundVol") == 1)
        {
            if (!soundFx.isPlaying)
            {
                soundFx.Play();
            }



            //Debug.Log("Play");
        }
           // Debug.Log("Dont Play");
    }


}
