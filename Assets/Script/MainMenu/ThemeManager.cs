using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeManager : MonoBehaviour
{
   // private static ThemeManager _instance;
    private int theInt;
    public GameObject DarkMode;
    public GameObject LightMode;

    // Start is called before the first frame update
    void Start()
    {

        PlayerPrefs.GetInt("ThemeInt");
        if (PlayerPrefs.GetInt("ThemeInt") == 0)
        {
            DarkMode.SetActive(true);
            LightMode.SetActive(false);
        }

        if (PlayerPrefs.GetInt("ThemeInt") == 1)
        {
            DarkMode.SetActive(false);
            LightMode.SetActive(true);

        }
    }

    public void SaveThemeMode(int number)
    {
        PlayerPrefs.SetInt("ThemeInt", number);
        Debug.Log(number);
    }

}
