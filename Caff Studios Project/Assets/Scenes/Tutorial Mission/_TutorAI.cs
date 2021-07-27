using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MissionCheckList;

public class _TutorAI : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent agent;

    public float sightRange;
    public bool attack, escape, handcuffing, stun, arrested, die, stage2, RunExit;

    public Transform walkPoint;
    public Transform walkPoint2;
    public Transform player;
    private Transform playerPoint;

    public GameObject checkList;
    public GameObject playerObject;

    public GameObject weaponCollider;
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

        if (checkList.GetComponent<_TutorCheckList>().alerted == true && stage2 == false)
        {
            running();
        }
        
        //When AI arrive the back door
        Vector3 distanceToDoor = transform.position - walkPoint.transform.position;
        if (distanceToDoor.magnitude < 0.2f) { AttackIdle(); stage2 = true; }

        //when player close to the AI
        Vector3 distanceToPlayer = transform.position - player.transform.position;
        if (distanceToPlayer.magnitude < 3f) { Attack(); }

        if (stage2 && RunExit == false)
        {
            if (distanceToPlayer.magnitude > 3f) AttackIdle();
        }
        
        if (playerObject.GetComponent<k_PlayerState>().currentHealth <= 70) { RunExit = true; RunToExit(); }

        Vector3 distanceToExit = transform.position - walkPoint2.transform.position;
        if (distanceToExit.magnitude < 0.2f) { AttackIdle(); escape = true; checkList.GetComponent<_TutorCheckList>().aiEscape = true; }

        if(arrested == true) { checkList.GetComponent<_TutorCheckList>().arrested = true; }
        if(stun == true) { checkList.GetComponent<_TutorCheckList>().shootTaser = true; }

    }

    public void AttackTarget()
    {
        anim.SetBool("Attacking", true);
        anim.SetBool("Running", false);
    }

    public void AttackCollider()
    {
        weaponCollider.GetComponent<BoxCollider>().enabled = true;
    }

    public void AttackedCollider()
    {
        weaponCollider.GetComponent<BoxCollider>().enabled = false;
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
