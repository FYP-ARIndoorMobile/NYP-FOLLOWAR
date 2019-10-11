using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GoogleARCore;

public class DebugUIManager : MonoBehaviour
{
    public static DebugUIManager instance = null;

    public TextMeshProUGUI CamPos, trackingStatus, debug, FPS;
    public Camera FirstPersonCamera;
    public GameObject PointCloud, PlaneVis;
    public Augenttedmage augmentedImage;
    public UnityEngine.UI.Button buttonLock;
    public bool boolStatus, boolCamPos, boolDebug, boolFPS, boolPointCloud, boolPlaneVis, boolLock;
    private SessionStatus CurrStatus;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        ////Test
    }

    void Start()
    {
        trackingStatus.color = (boolStatus) ? Color.white : Color.grey;
        CamPos.color = (boolCamPos) ? Color.white : Color.grey;
        debug.color = (boolDebug) ? Color.white : Color.grey;
        FPS.color = (boolFPS) ? Color.white : Color.grey;
        PointCloud.SetActive(boolPointCloud);
        PlaneVis.SetActive(boolPlaneVis);
        buttonLock.enabled = false;   
    }
    
    void Update()
    {
        if (boolCamPos == true)
            UpdateCamInfo();
        if (boolFPS == true)
            UpdateFps();
        if (augmentedImage.arObj != null)
        {
            if (buttonLock.enabled == false)
                buttonLock.enabled = true;
        }
    }

    public void UpdateStatus(SessionStatus newStatus, bool Tracked)
    {
        if (boolStatus == false)
            return;

        if (newStatus != CurrStatus)
        {
            CurrStatus = newStatus;
            switch (CurrStatus)
            {
                case SessionStatus.None:
                    trackingStatus.text = "None";
                    break;
                case SessionStatus.Initializing:
                    trackingStatus.text = "Initializing";
                    break;
                case SessionStatus.Tracking:
                    trackingStatus.text = "Tracking";
                    break;
                case SessionStatus.LostTracking:
                    trackingStatus.text = "LostTracking";
                    break;
                case SessionStatus.NotTracking:
                    trackingStatus.text = "NotTracking";
                    break;
                case SessionStatus.FatalError:
                    trackingStatus.text = "FatalError";
                    break;
                case SessionStatus.ErrorApkNotAvailable:
                    trackingStatus.text = "ErrorApkNotAvailable";
                    break;
                case SessionStatus.ErrorPermissionNotGranted:
                    trackingStatus.text = "ErrorPermissionNotGranted";
                    break;
                case SessionStatus.ErrorSessionConfigurationNotSupported:
                    trackingStatus.text = "ErrorSessionConfigurationNotSupported";
                    break;
            }
        }

        if (Tracked == true)
            trackingStatus.text = "Tracked";
    }

    public void UpdateCamInfo()
    {
        CamPos.text = "Camera Info:"
                    + "\nPos: " + FirstPersonCamera.transform.position.ToString()
                    + "\nRot: " + FirstPersonCamera.transform.rotation.eulerAngles.ToString();
    }

    public void UpdateFps()
    {
        FPS.text = "FPS: " + (1.0f / Time.deltaTime);
    }

    public void DebugLog(string text)
    {
        if (boolDebug == false)
            return;
        debug.text +=  "\n" + text;
    }

    public void UpdatingDebugLog(string text)
    {
        if (boolDebug == false)
            return;
        debug.text = "Debug Log: \n" + text;
    }

    public void ToggleStatus()
    {
        boolStatus = !boolStatus;
        trackingStatus.color = (boolStatus) ? Color.white : Color.grey;
    }

    public void ToggleCamPos()
    {
        boolCamPos = !boolCamPos;
        CamPos.color = (boolCamPos) ? Color.white : Color.grey;
    }

    public void ToggleDebug()
    {
        boolDebug = !boolDebug;
        debug.color = (boolDebug) ? Color.white : Color.grey;
    }

    public void ToggleFPS()
    {
        boolFPS = !boolFPS;
        FPS.color = (boolFPS) ? Color.white : Color.grey;
    }

    public void LockButon()
    {
        if (augmentedImage.arObj != null)
        {
            boolLock = !boolLock;
            augmentedImage.lockArObj = boolLock;

            string lockStatus = (boolLock) ? "Locked" : "UnLocked";
            DebugLog(lockStatus);
        }
    }
}
