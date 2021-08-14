using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MissionCheckList;
using TMPro;
using UnityEngine.UI;


public class _TutorialMissionAI : MonoBehaviour
{

    public bool warned, shootWarned, stunned, arrested, escaped, chAction;

    private bool idle, escape, attack, backDoor;

    public Transform wayPoint1;
    public Transform wayPoint2;

    public float sightRange;
    public Transform player;
    private Transform playerPoint;
    public GameObject playerObject;

    public GameObject weaponCollider;
    public Animator anim;
    public UnityEngine.AI.NavMeshAgent agent;

    //UI
    public GameObject handcuffBarUI;
    public Image handcuffBar;
    public float currentHcLevel;
    public float maxHcLevel;
    public TMP_Text stunTimer;
    float stunTime = 8f;
    float chTime = 0f;
    float startingTime = 2f;

    void Start()
    {
        playerPoint = GameObject.FindWithTag("PlayerPoint").transform;
        anim = anim.GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        anim.SetBool("Attacking", true);

        currentHcLevel = 0f;
        chTime = startingTime;
    }

    void Update()
    {
        
        if (warned)
        {
            Vector3 distanceToBackDoor = transform.position - wayPoint1.transform.position;
            agent.SetDestination(wayPoint1.transform.position);
            anim.SetBool("Running", true);
            anim.SetBool("Attacking", false);

            if (distanceToBackDoor.magnitude < 0.5f)
            {
                warned = false;
                backDoor = true;
                AttackIdle();
            }
        }

        Vector3 distanceToPlayer = transform.position - player.transform.position;
        if (!arrested && !escape && backDoor && distanceToPlayer.magnitude < 3f) { Attack(); }
        if (!arrested && !escape && backDoor && distanceToPlayer.magnitude > 3f) { AttackIdle(); }

        Vector3 distanceToExit = transform.position - wayPoint2.transform.position;
        if (distanceToExit.magnitude < 0.2f) { AttackIdle(); escaped = true;}

        if (escape) { RunToExit(); }

        if (stunned)
        {
            Stun();
        }

        if (chAction)
        {

            Handcuffs();
        }

        if (playerObject.GetComponent<k_PlayerState>().currentHealth <= 70) { escape = true; }

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

    public void AttackCollider()
    {
        weaponCollider.GetComponent<BoxCollider>().enabled = true;
    }

    public void AttackedCollider()
    {
        weaponCollider.GetComponent<BoxCollider>().enabled = false;
    }

    public void RunToExit()
    {
        gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        anim.SetBool("Running", true);
        anim.SetBool("Attacking", false);
        agent.SetDestination(wayPoint2.transform.position);
    }


    public void Handcuffs()
    {

        gameObject.GetComponent<NavMeshAgent>().isStopped = true;

        anim.SetBool("Running", false);
        anim.SetBool("Attacking", false);
        anim.SetBool("Handcuffing", true);
        handcuffBar.fillAmount = currentHcLevel / maxHcLevel;

        handcuffBarUI.SetActive(true);

        if (chTime > 0)
        {
            chTime -= 1 * Time.deltaTime;
            print(chTime);
        }
        if (chTime <= 0f)
        {
            chTime = 0f;
            Handcuff_Fail();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            currentHcLevel += 1f;
        }

        if (currentHcLevel == maxHcLevel)
        {
            Handcuff_Success();
        }

        if (arrested)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            anim.SetBool("Stun", false);
            anim.SetBool("Handcuffing", false);
            anim.SetBool("Attacking", false);
            anim.SetBool("Arrest", true);
        }

    }

    void Handcuff_Fail()
    {
        anim.SetBool("Handcuffing", false);
        handcuffBarUI.SetActive(false);
        chAction = false;
        currentHcLevel = 0f;
        chTime = startingTime;
    }

    void Handcuff_Success()
    {

        handcuffBarUI.SetActive(false);
        chAction = false;
        arrested = true;
    }


    void Stun()
    {
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;

        anim.SetBool("Running", false);
        anim.SetBool("Attacking", false);
        anim.SetBool("Stun", true);
        stunTime -= 1 * Time.deltaTime;
        stunTimer.text = stunTime.ToString("0");
        if (stunTime <= 0)
        {
            anim.SetBool("Stun", false);
            stunTimer.text = ("");
            stunned = false;
            stunTime = 8f;
        }

        if (chAction)
        {
            Handcuff_Success();
        }
    }
}
