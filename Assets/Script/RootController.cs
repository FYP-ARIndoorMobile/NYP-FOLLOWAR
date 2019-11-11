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

    public Animator animationPanda;

    private float ElaspedTime;
    private Vector3 PrevPos;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        // ガイドオブジェクトを固定する
        this.transform.position = this.transform.localPosition;

        //  meshLine = TargetPos.GetComponent<meshLine>();

        InstantiateFlag = false;
        ElaspedTime = 0;

        animationPanda = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    void Update()
    {
        ElaspedTime += Time.deltaTime;
        if (ElaspedTime > 1.0f)
        {
            //DebugUIManager.instance.DebugLog("START");
            ElaspedTime = 0;
            if (PrevPos == null)
            {
                PrevPos = gameObject.transform.position;
            }
            else
            {
                float distMoved = Vector3.Distance(PrevPos, gameObject.transform.position);
                //DebugUIManager.instance.DebugLog("Dist: " + distMoved.ToString());
                if (distMoved < 1)
                {
                    //DebugUIManager.instance.DebugLog("Set Idle");
                    animationPanda.SetTrigger("SetIdle");
                }
                else
                {
                    //DebugUIManager.instance.DebugLog("Set Walking");
                    animationPanda.SetTrigger("SetWalking");
                }
            }
            //DebugUIManager.instance.DebugLog("Prev: " + PrevPos.ToString());
            //DebugUIManager.instance.DebugLog("Curr: " + gameObject.transform.position.ToString());
            PrevPos = gameObject.transform.position;
        }

        /*
            if (PrevPos != null)
            {
                float distMoved = Vector3.Distance(PrevPos, gameObject.transform.position);
                DebugUIManager.instance.DebugLog(distMoved.ToString());
                if (distMoved < 0.5f)
                {
                    DebugUIManager.instance.DebugLog("Set Idle");
                    animationPanda.SetTrigger("SetIdle");
                }
            }
        */

        //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        //transform.LookAt(DebugUIManager.instance.FirstPersonCamera.transform.position);
        //transform.Rotate(0, 180, 0);
        //transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        //    this.transform.LookAt(meshLine.target);

        // オブジェクトが止まっているならフラグをfalseにする
        if (rigid.IsSleeping() == true)
        {
            InstantiateFlag = false;
        }

        // フラグがtrueなら生成できる
        if (InstantiateFlag == true)
        {
            //if (previousRootPrint == null)
            //    previousRootPrint = Instantiate(footPrintPrefab, transform.position, transform.rotation);
            //else if (Vector3.Distance(previousRootPrint.transform.position, transform.position) > DistFromLastRoot)
            //    previousRootPrint = Instantiate(footPrintPrefab, transform.position, transform.rotation);

            if (previousRoot == null)
            {
                newRoot = Instantiate(footPrintPrefab, transform.position, transform.rotation);
                previousRoot = newRoot;
            }
            else if (Vector3.Distance(previousRoot.transform.position, transform.position) > DistFromLastRoot)
            {
                newRoot = Instantiate(footPrintPrefab, transform.position, transform.rotation);
                previousRoot.transform.LookAt(newRoot.transform.position);
                previousRoot = newRoot;
            }
        }
    }

    private void LateUpdate()
    {
        DebugUIManager.instance.UpdatingDebugLog((agent.velocity.normalized).ToString());
        if (agent.velocity.sqrMagnitude > Mathf.Epsilon)
        {
            transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
            transform.Rotate(0, 180, 0);
        }       
    }
}
