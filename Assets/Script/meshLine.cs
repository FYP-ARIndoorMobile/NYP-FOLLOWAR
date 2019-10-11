using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class meshLine : MonoBehaviour
{
    public Transform target;        // 目的地

    public GameObject StartingPoint;    // statePoint
    public GameObject arrowPoint;           // arrowObj

    [SerializeField] NavMeshAgent[] agent;     // 追いかける物

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
        agent[0].SetDestination(target.position);
        agent[1].SetDestination(target.position);

        // 経路取得       Get route
        path = new NavMeshPath();

        // 経路計算       Route calculation
        agent[1].CalculatePath(target.position, path);

        // 線を描画       LineRender
        line.positionCount = path.corners.Length;
        line.SetPositions(path.corners);
    }
}
