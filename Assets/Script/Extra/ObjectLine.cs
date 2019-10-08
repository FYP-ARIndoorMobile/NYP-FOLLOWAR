using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLine : MonoBehaviour
{
    LineRenderer line;

    [SerializeField] public GameObject stateObj;

    [SerializeField] GameObject[] middleObj;

    [SerializeField] public GameObject endObj;




    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        //コンポーネントを取得する
        this.line = GetComponent<LineRenderer>();

        //線の幅を決める
        this.line.startWidth = 0.1f;
        this.line.endWidth = 0.1f;
        //頂点の数を決める
        this.line.positionCount = 4;

        //Updateに書いたのは作者が動的に変化させたかったため
        //0や1は頂点の順番(多分)
        line.SetPosition(0, stateObj.transform.position);
        line.SetPosition(1, middleObj[0].transform.position);
        line.SetPosition(2, middleObj[1].transform.position);
        line.SetPosition(3, endObj.transform.position);

    }
}
