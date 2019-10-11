using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
                    arObj = Instantiate(ObjPrefab, anchor.transform);

                    if (image.Name == "Earth")
                    {
                        DebugUIManager.instance.DebugLog("Earth detected");
                        RotOffset = new Vector3(0, 0, 180);
                    }
                    else if (image.Name == "Cafe")
                    {
                        DebugUIManager.instance.DebugLog("Cafe detected");
                        PosOffset = new Vector3(0, 0, -14);
                        RotOffset = new Vector3(0, 0, 0);
                    }
                    DebugUIManager.instance.DebugLog("Offset: " + PosOffset.ToString() + RotOffset.ToString());
                }
                else
                {

                    //トラッキング中かつarObjが既に存在するので位置・回転の更新を行う。
                    //Apply appopriate offset
                    arObj.transform.position = image.CenterPose.position;
                    arObj.transform.position += arObj.transform.TransformPoint(PosOffset);
                    arObj.transform.rotation = image.CenterPose.rotation;
                    arObj.transform.Rotate(RotOffset);
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
}
