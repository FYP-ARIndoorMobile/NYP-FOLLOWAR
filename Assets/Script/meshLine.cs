using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class meshLine : MonoBehaviour
{
    public Transform target;        // 目的地

    [SerializeField] NavMeshAgent agent;     // 追いかける物

    [SerializeField] LineRenderer line;      // ターゲットまでの道のり

    NavMeshPath path;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        // 目的地を設定   Set the destination
        agent.SetDestination(target.position);

        // 経路取得       Get route
        path = new NavMeshPath();

        // 経路計算       Route calculation
        agent.CalculatePath(target.position, path);

        // 線を描画       LineRender
        line.positionCount = path.corners.Length;
        line.SetPositions(path.corners);
    }
}
