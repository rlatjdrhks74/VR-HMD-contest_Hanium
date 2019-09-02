using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(NavMeshAgent))]
public class MoveAgent : MonoBehaviour
{
    public List<Transform> wayPoints;       //돌아다니는 지점 저장
    public int nextIdx;     //다음 순찰지점 배열 index
    public readonly int hashWalkSpeed = Animator.StringToHash("WalkSpeed");
    private Animator animator;
    private NavMeshAgent agent;     //navmeshagent컴포넌트 저장
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat(hashWalkSpeed, Random.Range(1.0f, 1.2f));
        agent = GetComponent<NavMeshAgent>();       //navmeshagent컴포넌트 추출 후 변수에 저장

        var group = GameObject.Find("WayPointGroup");
        if(group != null)
        {
            group.GetComponentsInChildren<Transform>(wayPoints);        //waypointgroup하위에 이슨 모든 transform 컴포넌트 추출 후 list 타입의 waypoint배열에 추가함
            wayPoints.RemoveAt(0);
            nextIdx = Random.Range(0, wayPoints.Count);     //이동할 위치 불규칙적으로
        }

        MoveWayPoint();
    }
    void MoveWayPoint()     //다음목적지까지 이동명령
    {
        if (agent.isPathStale) return;      //최단거리 경로 계산이 끝나지 않았으면 다음을 수행하지않는다
        agent.destination = wayPoints[nextIdx].position;        //다음 목적지를 waypoints배열에서 추출한 위치로 다음 목적지 지정
        agent.isStopped = false;                //내비게이션 기능을 활성화해서 이동 시작
    }
    // Update is called once per frame
    void Update()
    {  
        //navmesh가 이동하고잇고 목적지에 도착했는지 여부 계산
        if(agent.velocity.sqrMagnitude >= 0.2f * 0.2f && agent.remainingDistance <= 0.5f)
        {
            //nextIdx = ++nextIdx % wayPoints.Count;      //다음목적지 배열 첨자
            nextIdx = Random.Range(0, wayPoints.Count);
            MoveWayPoint();         //이동명령
        }
    }
}
