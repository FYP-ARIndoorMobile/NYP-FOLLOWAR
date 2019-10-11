using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCtrl : MonoBehaviour
{
    public GameObject obj;

    // 回転用
    Vector2 rPos;         // タッチ座標
    Quaternion rRot;      // タッチ時の回転
    float wid, hei, diag;  // スクリーンサイズ
    float rx, ry;          // 代入用

    // ピンチイン　ピンアウト
    float vMin = 0.5f, vMax = 3.0f;     // 倍率制限
    float sDist = 0.0f, nDist = 0.0f;    // 距離変数
    Vector3 initScale;                  // 最初の大きさ
    float v = 1.0f;                     // 現在倍率

    // Start is called before the first frame update
    void Start()
    {
        wid = Screen.width;
        hei = Screen.height;
        diag = Mathf.Sqrt(Mathf.Pow(wid, 2) + Mathf.Pow(hei, 2));
        initScale = obj.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            // 回転
            Touch t1 = Input.GetTouch(0);
            if(t1.phase==TouchPhase.Began)
            {
                rPos = t1.position;
                rRot = obj.transform.rotation;
            }
            else if(t1.phase==TouchPhase.Moved|| t1.phase==TouchPhase.Stationary)
            {
                rx = (t1.position.x - rPos.x) / wid;    // 横移動量(-1<rx<1)
                ry = (t1.position.y - rPos.y) / hei;    // 横移動量(-1<ry<1)
                obj.transform.rotation = rRot;
                obj.transform.Rotate(new Vector3(90 * ry, -90 * rx, 0), Space.World);
            }
        }
        else if(Input.touchCount>=2)
        {
            // ピンチイン・アウト
            Touch t1 = Input.GetTouch(0);       // 1つ目のタップ
            Touch t2 = Input.GetTouch(1);       // 2つ目のタップ
            if (t2.phase==TouchPhase.Began)
            {
                sDist = Vector2.Distance(t1.position, t2.position);
            }
            // 指が触れているが動いていない or 動いているとき
            else if((t1.phase==TouchPhase.Moved||t1.phase==TouchPhase.Stationary)&&
                    (t2.phase==TouchPhase.Moved||t2.phase==TouchPhase.Stationary))
            {
                nDist = Vector2.Distance(t1.position, t2.position);
                v = v + (nDist - sDist) / diag;
                sDist = nDist;
                if (v > vMax) v = vMax;
                if (v > vMin) v = vMin;
                obj.transform.localScale = initScale * v;
            }
        }
    }
}
