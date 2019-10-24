using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
    public GameObject footPrintPrefab;
    float time = 0;

    Rigidbody rigid;
    public bool InstantiateFlag;

  //  public GameObject guideObjPos;
  //  public GameObject DestinationPos;

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        this.transform.position = this.transform.localPosition;
        InstantiateFlag = false;
    }

    void Update()
    {
        // オブジェクトが止まっているならフラグをfalseにする
        if (rigid.IsSleeping()) { InstantiateFlag = false; }
     //   if (guideObjPos.transform.position.z == DestinationPos.transform.position.z) {  InstantiateFlag = false; }
        this.time += Time.deltaTime;
        // フラグがtrueなら生成できる
        if (this.time > 0.35f && InstantiateFlag == true)
        {
            this.time = 0;
            Instantiate(footPrintPrefab, transform.position, transform.rotation);
        }

        
    }
}
