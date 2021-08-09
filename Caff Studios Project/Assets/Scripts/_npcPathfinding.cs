using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _npcPathfinding : MonoBehaviour
{

    public Animator animator;
    //public AudioSource audioSource;
    public UnityEngine.AI.NavMeshAgent agent;
    public LayerMask whatIsGround;

    public string animBool;


    public Transform[] wayPoint;

    private void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Walking", true);
        agent.SetDestination(wayPoint[0].transform.position);

        Vector3 distanation = transform.position - wayPoint[0].transform.position;
        if (distanation.magnitude < 1f) { DoSomething(); }
    }

    void DoSomething()
    {
        animator.SetBool(animBool, true);
        animator.SetBool("Walking", false);
    }
}
