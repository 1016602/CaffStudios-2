using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MissionCheckList;

public class _TutorAI : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent agent;

    public float sightRange;
    public bool attack, escape;

    public Transform walkPoint;
    public Transform walkPoint2;
    public Transform player;
    public GameObject checkList;

    private void Awake()
    {

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    
    void Update()
    {
        if (checkList.GetComponent<_TutorCheckList>().alerted == true)
        {
            running();
        }

        Vector3 distanceToDoor = transform.position - walkPoint.transform.position;
        if (distanceToDoor.magnitude < 0.2f) AttackIdle();

        Vector3 distanceToPlayer = transform.position - player.transform.position;
        if (distanceToPlayer.magnitude < 3f) Attack();

        if (escape) { Escape(); }

        if (distanceToPlayer.magnitude < 3f) Attack();
    }

    public void running()
    {
        agent.SetDestination(walkPoint.transform.position);
        transform.GetComponent<Renderer>().material.color = Color.yellow;

    }

    public void AttackIdle()
    {
        transform.GetComponent<Renderer>().material.color = Color.green;
    }

    public void Attack()
    {
        transform.GetComponent<Renderer>().material.color = Color.red;
    }

    public void Escape()
    {
        agent.SetDestination(walkPoint2.transform.position);
        transform.GetComponent<Renderer>().material.color = Color.white;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

}
