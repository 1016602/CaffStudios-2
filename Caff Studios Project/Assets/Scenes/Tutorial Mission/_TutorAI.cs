using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MissionCheckList;

public class _TutorAI : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent agent;

    public float sightRange;
    public bool attack, escape, handcuffing, stun, arrested, die, stage2;

    public Transform walkPoint;
    public Transform walkPoint2;
    public Transform player;
    private Transform playerPoint;

    public GameObject checkList;
    public GameObject playerObject;

    public Animator anim;
    private Animator anim1;

    private void Awake()
    {
        playerPoint = GameObject.FindWithTag("PlayerPoint").transform;
        anim1 = anim.GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
    }

    
    void Update()
    {
        AttackTarget();

        if (checkList.GetComponent<_TutorCheckList>().alerted == true)
        {
            running();
        }
        
        Vector3 distanceToDoor = transform.position - walkPoint.transform.position;
        if (distanceToDoor.magnitude < 0.2f) { AttackIdle(); stage2 = true; }

        Vector3 distanceToPlayer = transform.position - player.transform.position;
        if (distanceToPlayer.magnitude < 3f) { Attack(); }

        if (stage2)
        {
            if (distanceToPlayer.magnitude > 3f) AttackIdle();
        }
        
        if (playerObject.GetComponent<k_PlayerState>().currentHealth <= 70) { RunToExit(); }

        Vector3 distanceToExit = transform.position - walkPoint2.transform.position;
        if (distanceToExit.magnitude < 0.2f) { AttackIdle(); escape = true; }

    }

    public void AttackTarget()
    {
        anim.SetBool("Attacking", true);
        anim.SetBool("Running", false);
    }


    public void running()
    {
        agent.SetDestination(walkPoint.transform.position);
        anim.SetBool("Running", true);
        anim.SetBool("Attacking", false);
    }

    public void AttackIdle()
    {
        anim.SetBool("Running", false);
        anim.SetBool("Attacking", false);
        playerPoint.position = new Vector3(playerPoint.position.x, transform.position.y, playerPoint.position.z);
        transform.LookAt(playerPoint);
    }

    public void Attack()
    {
        anim.SetBool("Attacking", true);
        anim.SetBool("Running", false);
        playerPoint.position = new Vector3(playerPoint.position.x, transform.position.y, playerPoint.position.z);
        transform.LookAt(playerPoint);
    }

    public void RunToExit()
    {
        anim.SetBool("Running", true);
        anim.SetBool("Attacking", false);
        agent.SetDestination(walkPoint2.transform.position);
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

}
