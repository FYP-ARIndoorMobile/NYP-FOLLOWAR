using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public GameObject TargetObj;      // 目標

    NavMeshAgent m_navMeshAgent; /// NavMeshAgent

    // Start is called before the first frame update
    void Start()
    {
        m_navMeshAgent = GetComponent<NavMeshAgent>()
;    }

    // Update is called once per frame
    void Update()
    {
        // pathStatus ( 現在の経路のステータス（完了、未完了、無効）)
        if (m_navMeshAgent.pathStatus !=NavMeshPathStatus.PathInvalid)
        {
            // NavMeshAgentに目的地をセット(結構重い)
            m_navMeshAgent.SetDestination(TargetObj.transform.position);
        }
    }
}
