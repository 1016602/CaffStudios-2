using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using MissionCheckList;

public class _TutorMessage : MonoBehaviour
{
    public GameObject player;
    public GameObject Enemy;
    public GameObject NPC;
    public GameObject checkList;

    public GameObject popUpUI;

    public Animator anim;

    void Start()
    {
        anim = anim.GetComponent<Animator>();
    }


    void Update()
    {
        if (checkList.GetComponent<_TutorCheckList>().alerted == true)
        {
            player.GetComponent<FirstPersonController>().m_WalkSpeed = 5;
            player.GetComponent<FirstPersonController>().m_RunSpeed = 8;
            player.GetComponent<FirstPersonController>().m_JumpSpeed = 5;

            StartCoroutine(HideMessage());
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<FirstPersonController>().m_WalkSpeed = 0;
            player.GetComponent<FirstPersonController>().m_RunSpeed = 0;
            player.GetComponent<FirstPersonController>().m_JumpSpeed = 0;


            popUpUI.SetActive(true);
            anim.SetBool("up", true);
        }
    }

    IEnumerator HideMessage()
    {
        anim.SetBool("down", true);
        yield return new WaitForSeconds(1.5f);

        Destroy(gameObject);
    }

}
