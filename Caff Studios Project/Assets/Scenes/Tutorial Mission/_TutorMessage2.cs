using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using MissionCheckList;

public class _TutorMessage2 : MonoBehaviour
{
    public GameObject player;
    public GameObject Enemy;
    public GameObject NPC;
    public GameObject checkList;

    public GameObject t2Message;
    public GameObject popUpUI;
    public GameObject popUpUI2;

    void Update()
    {
        if (checkList.GetComponent<_TutorCheckList>().shootWarning == true)
        {
            player.GetComponent<FirstPersonController>().m_WalkSpeed = 5;
            player.GetComponent<FirstPersonController>().m_RunSpeed = 8;
            player.GetComponent<FirstPersonController>().m_JumpSpeed = 5;
            popUpUI.SetActive(false);
            popUpUI2.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            t2Message.SetActive(false);
            player.GetComponent<FirstPersonController>().m_WalkSpeed = 0;
            player.GetComponent<FirstPersonController>().m_RunSpeed = 0;
            player.GetComponent<FirstPersonController>().m_JumpSpeed = 0;
            popUpUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            popUpUI2.SetActive(false);
        }
    }
}
