using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugButtonInput : MonoBehaviour
{
    public void buttonToggleStatus()
    {
        DebugUIManager.instance.ToggleStatus();
    }

    public void buttonToggleCaminfo()
    {
        DebugUIManager.instance.ToggleCamPos();
    }

    public void buttonToggleFPS()
    {
        DebugUIManager.instance.ToggleFPS();
    }

    public void buttonToggleDebug()
    {
        DebugUIManager.instance.ToggleDebug();
    }

    public void buttonLock()
    {
        DebugUIManager.instance.LockButon();
    }

    public void buttonLogPos()
    {
        DebugUIManager.instance.LogPosition();
    }
}
