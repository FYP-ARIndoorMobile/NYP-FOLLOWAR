using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore;

public class Augenttedmage : MonoBehaviour
{
    private List<AugmentedImage> augmentedImageList = new List<AugmentedImage>();
    [SerializeField] private GameObject ObjPrefab;   
    public GameObject arObj = null;
    [SerializeField] private bool isPlaneHorizontal;
    private Vector3 PosOffset, RotOffset;

    private Anchor anchor;
    private Vector3 lastAnchorPos;
    private Quaternion lastAnchorRot;
    public bool lockArObj;

    public float bufferDist;
    public float bufferAngle;

    private GameObject[] spawnPoints;
    private float spawnPointRotation;

    [SerializeField] private Button roomInput;
    public IndoorUIManager IndoorUI;

    void Update()
    {

        DebugUIManager.instance.UpdateStatus(Session.Status, false);
        if (Session.Status != SessionStatus.Tracking)
        {
            //  Return because I can't track
            return; //トラッキングできてないのでreturn
        }
        //ARCoreがトラッキングしているものを取得する。
        // Get what ARCore is tracking.
        Session.GetTrackables<AugmentedImage>(augmentedImageList, TrackableQueryFilter.Updated);

        foreach (AugmentedImage image in augmentedImageList)
        {
            if (image.TrackingState == TrackingState.Tracking)
            {
                DebugUIManager.instance.UpdateStatus(Session.Status, true);
                if (arObj == null)
                {
                    //トラッキング中かつarObjがNullなのでオブジェクトを生成する
                    anchor = image.CreateAnchor(image.CenterPose);
                    lastAnchorPos = anchor.transform.position;
                    lastAnchorRot = anchor.transform.rotation;

                    //arObj = Instantiate(ObjPrefab, anchor.transform);

                    spawnPointRotation = SpawnAt(image.Name, anchor);

                    roomInput.interactable = true;
                    IndoorUI.SetDestinationManager(arObj.GetComponentInChildren<DestinationManager>());
                    IndoorUI.Calibrated.SetActive(true);
                    lockArObj = true;

                    //if (image.Name == "15")
                    //{
                    //    DebugUIManager.instance.DebugLog("15 detected");
                    //    PosOffset = new Vector3(7.4f, 0, 0);
                    //    RotOffset = new Vector3(0, 0, 180);
                    //}
                    //else if (image.Name == "Cafe")
                    //{
                    //    DebugUIManager.instance.DebugLog("Cafe detected");
                    //    PosOffset = new Vector3(-7, 0, -3);
                    //    RotOffset = new Vector3(0, 0, 90);
                    //}
                    //DebugUIManager.instance.DebugLog("Offset: " + PosOffset.ToString() + RotOffset.ToString());
                }
                else
                {

                    //トラッキング中かつarObjが既に存在するので位置・回転の更新を行う。
                    //Apply appopriate offset
                    arObj.transform.position = image.CenterPose.position + (Vector3.up * -3);
                    //arObj.transform.position += arObj.transform.TransformPoint(PosOffset);
                    arObj.transform.rotation = image.CenterPose.rotation;
                    if (isPlaneHorizontal == false)
                        arObj.transform.Rotate(90, 0, 0);
                    

                    if (lockArObj == true)
                    {
                        anchor.transform.position = lastAnchorPos;
                        anchor.transform.rotation = lastAnchorRot;
                    }

                    //AnchorUpdateBuffer();
                    AlineWithGround(arObj);

                    //Print Rotation
                    //UIManager.UpdatingDebugLog("R: " + arObj.transform.rotation.eulerAngles.ToString());

                    //DisplayAnchorChange();

                    arObj.transform.Rotate(Vector3.up * spawnPointRotation);
                    //DebugUIManager.instance.UpdatingDebugLog(arObj.transform.rotation.eulerAngles.ToString());
                }
            }
        }
    }

    private void AlineWithGround(GameObject obj)
    {
        obj.transform.rotation = Quaternion.Euler(0, obj.transform.rotation.eulerAngles.y, 0);
    }

    private void AnchorUpdateBuffer()
    {
        //Only update anchor position after it updates beyond a certain distance
        if (Vector3.Distance(anchor.transform.position, lastAnchorPos) > bufferDist)
        {
            DebugUIManager.instance.DebugLog("Anchor moved (>" + bufferDist + "): " + Vector3.Distance(anchor.transform.position, lastAnchorPos).ToString());
            lastAnchorPos = anchor.transform.position;
        }
        else
        {
            anchor.transform.position = lastAnchorPos;
        }
        //Only update anchor rotation after it updates beyond a certain angle
        if (Quaternion.Angle(anchor.transform.rotation, lastAnchorRot) > bufferAngle)
        {
            DebugUIManager.instance.DebugLog("Anchor rotated (>" + bufferAngle + "): " + Quaternion.Angle(anchor.transform.rotation, lastAnchorRot).ToString());
            lastAnchorRot = anchor.transform.rotation;
        }
        else
        {
            anchor.transform.rotation = lastAnchorRot;
        }
    }

    private void DisplayAnchorChange()
    {
        if (anchor.transform.position != lastAnchorPos)
        {
            DebugUIManager.instance.DebugLog("Anchor moved: " + (Vector3.Distance(anchor.transform.position, lastAnchorPos)).ToString());
            lastAnchorPos = anchor.transform.position;
        }
        if (anchor.transform.rotation != lastAnchorRot)
        {
            DebugUIManager.instance.DebugLog("Anchor rotated: " + (Quaternion.Angle(anchor.transform.rotation, lastAnchorRot)).ToString());
            lastAnchorRot = anchor.transform.rotation;
        }
    }

    public GameObject GetArObj()
    {
        return arObj;
    }

    private float SpawnAt(string spawnPointName, Anchor anchor)
    {
        DebugUIManager.instance.DebugLog("Detected " + spawnPointName);

        GameObject hallwayPrefab = Instantiate(new GameObject(), anchor.transform);
        GameObject hallwayPrefabChild = Instantiate(ObjPrefab, hallwayPrefab.transform);

        DestinationManager hallwayPrefabChildCombined = hallwayPrefabChild.GetComponentInChildren<DestinationManager>();
        spawnPoints = hallwayPrefabChildCombined.GetSpawnPoints();
        hallwayPrefabChildCombined.IndoorUI = IndoorUI;

        foreach (GameObject spawnPoint in spawnPoints)
        {
            if (spawnPoint.name == spawnPointName)
            {
                hallwayPrefabChildCombined.transform.position = -spawnPoint.transform.position;
                //hallwayPrefab.transform.rotation = spawnPoint.transform.rotation;

                DebugUIManager.instance.DebugLog("Spawning at" + (-spawnPoint.transform.position).ToString());
                DebugUIManager.instance.DebugLog("with rotation: " + spawnPoint.transform.rotation.eulerAngles.y);
                arObj = hallwayPrefab;
                return spawnPoint.transform.rotation.eulerAngles.y;
            }
        }

        DebugUIManager.instance.DebugLog("Spawn Error");
        return 0;
    }
}
