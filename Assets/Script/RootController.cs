using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
    public GameObject footPrintPrefab;
    float time = 0;

    Rigidbody rigid;
    public bool InstantiateFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();

    }

    void Update()
    {
        // オブジェクトが止まっているならフラグをfalseにする
        if (rigid.IsSleeping()) { InstantiateFlag = false; }


        this.time += Time.deltaTime;
        // フラグがtrueなら生成できる
        if (this.time > 0.35f && InstantiateFlag == true)
        {
            this.time = 0;
            Instantiate(footPrintPrefab, transform.position, transform.rotation);
        }
    }
}
