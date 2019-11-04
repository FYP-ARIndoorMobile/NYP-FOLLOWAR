using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
    public GameObject footPrintPrefab;
    //float time = 0;

    //private meshLine meshLine;
    //private GameObject TargetPos;

    Rigidbody rigid;
    public bool InstantiateFlag;

    GameObject currFootPrint;
    public float DistFromLastMarker = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        // ガイドオブジェクトを固定する
        this.transform.position = this.transform.localPosition;

      //  meshLine = TargetPos.GetComponent<meshLine>();

        InstantiateFlag = false;
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        transform.LookAt(DebugUIManager.instance.FirstPersonCamera.transform.position);
        transform.Rotate(0, 180, 0);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        //    this.transform.LookAt(meshLine.target);

        // オブジェクトが止まっているならフラグをfalseにする
        if (rigid.IsSleeping()==true) { InstantiateFlag = false; }

        // フラグがtrueなら生成できる
        if (InstantiateFlag == true)
        {
            if (currFootPrint == null)
                currFootPrint = Instantiate(footPrintPrefab, transform.position, transform.rotation);
            else if (Vector3.Distance(currFootPrint.transform.position, transform.position) > DistFromLastMarker)
                currFootPrint = Instantiate(footPrintPrefab, transform.position, transform.rotation);
        }
    }
}
