using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RootController : MonoBehaviour
{
    public GameObject footPrintPrefab;
    //float time = 0;

    //private meshLine meshLine;
    //private GameObject TargetPos;

    Rigidbody rigid;
    public bool InstantiateFlag;

    GameObject previousRoot, newRoot;
    public float DistFromLastRoot = 1.0f;

    private Animator animationPanda;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        // ガイドオブジェクトを固定する
        this.transform.position = this.transform.localPosition;

        InstantiateFlag = false;

        animationPanda = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    void Update()
    {
        // オブジェクトが止まっているならフラグをfalseにする
        if (rigid.IsSleeping() == true)
        {
            InstantiateFlag = false;
        }

        // フラグがtrueなら生成できる
        if (InstantiateFlag == true)
        {
            //Place dotted path behind guide object
            if (previousRoot == null)
            {
                newRoot = Instantiate(footPrintPrefab, transform.position, transform.rotation);
                previousRoot = newRoot;
            }
            else if (Vector3.Distance(previousRoot.transform.position, transform.position) > DistFromLastRoot)
            {
                newRoot = Instantiate(footPrintPrefab, transform.position, transform.rotation);
                newRoot.transform.Rotate(0, 180, 0);
                previousRoot.transform.LookAt(newRoot.transform.position);
                previousRoot = newRoot;
            }
        }
    }

    private void LateUpdate()
    {
        if (agent.velocity.sqrMagnitude > 1.8f)
        {
            animationPanda.SetTrigger("SetWalking");
            transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
            transform.Rotate(0, 180, 0);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
        else
        {
            animationPanda.SetTrigger("SetIdle");
            transform.LookAt(DebugUIManager.instance.FirstPersonCamera.transform.position);
            transform.Rotate(0, 180, 0);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
    }
}
