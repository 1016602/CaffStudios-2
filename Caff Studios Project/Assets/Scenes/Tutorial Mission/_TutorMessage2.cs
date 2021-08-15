using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using MissionCheckList;
using TMPro;

public class _TutorMessage2 : MonoBehaviour
{
    public GameObject player;
    public GameObject Enemy;
    public GameObject NPC;
    public GameObject checkList;

    public GameObject popUpUI;
    public TMP_Text messageUI;

    public Animator anim;

    [TextArea]
    public string message1;

    [TextArea]
    public string message2;

    void Start()
    {
        anim = anim.GetComponent<Animator>();
    }

    void Update()
    {
        if (checkList.GetComponent<_TutorCheckList>().shootWarning == true)
        {
            player.GetComponent<FirstPersonController>().m_WalkSpeed = 5;
            player.GetComponent<FirstPersonController>().m_RunSpeed = 8;
            player.GetComponent<FirstPersonController>().m_JumpSpeed = 5;

            messageUI.text = message2;
            //popUpUI.SetActive(false);
            //popUpUI2.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //t2Message.SetActive(false);
            player.GetComponent<FirstPersonController>().m_WalkSpeed = 0;
            player.GetComponent<FirstPersonController>().m_RunSpeed = 0;
            player.GetComponent<FirstPersonController>().m_JumpSpeed = 0;

            popUpUI.SetActive(true);
            anim.SetBool("up", true);
            messageUI.text = message1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(HideMessage());
        }
    }

    IEnumerator HideMessage()
    {
        anim.SetBool("down", true);
        yield return new WaitForSeconds(1.5f);

        Destroy(gameObject);
    }
}
