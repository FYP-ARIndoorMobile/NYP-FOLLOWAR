using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugButtonInput : MonoBehaviour
{
    public DebugUIManager UIManager;

    public void buttonToggleStatus()
    {
        UIManager.ToggleStatus();
    }

    public void buttonToggleCaminfo()
    {
        UIManager.ToggleCamPos();
    }

    public void buttonToggleFPS()
    {
        UIManager.ToggleFPS();
    }

    public void buttonToggleDebug()
    {
        UIManager.ToggleDebug();
    }

    public void buttonLock()
    {
        UIManager.LockButon();
    }
}
