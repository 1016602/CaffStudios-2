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

    void Start()
    {
        
    }


    void Update()
    {
        if (checkList.GetComponent<_TutorCheckList>().alerted == true)
        {
            player.GetComponent<FirstPersonController>().m_WalkSpeed = 5;
            player.GetComponent<FirstPersonController>().m_RunSpeed = 8;
            player.GetComponent<FirstPersonController>().m_JumpSpeed = 5;
            popUpUI.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<FirstPersonController>().m_WalkSpeed =0;
            player.GetComponent<FirstPersonController>().m_RunSpeed = 0;
            player.GetComponent<FirstPersonController>().m_JumpSpeed = 0;


            popUpUI.SetActive(true);
        }
    }


}
