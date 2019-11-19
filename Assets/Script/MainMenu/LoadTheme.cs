using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTheme : MonoBehaviour
{
    ThemeManager theTheme;
    public void Start()
    {
        if (theTheme != null)
            theTheme = FindObjectOfType<ThemeManager>();
    }
    public void LoadT()
    {
        if (PlayerPrefs.GetInt("ThemeInt") == 0)
        {

            theTheme.DarkMode.SetActive(false);
            theTheme.LightMode.SetActive(true);
        }

        if (PlayerPrefs.GetInt("ThemeInt") == 1)
        {
            theTheme.DarkMode.SetActive(true);
            theTheme.LightMode.SetActive(false);
        }
    }
}

