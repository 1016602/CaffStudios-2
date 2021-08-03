using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class _TrainingOfficer : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    bool playerCheck;

    public string activateBool;
    public TMP_Text inGameMessage;

    //player canvas UI
    public GameObject playerUI;
    public bool T1, T2, T3;

    [TextArea]
    public string message;

    private Transform playerPoint;

    Animator anim;

    void Start()
    {
        playerPoint = GameObject.FindWithTag("PlayerPoint").transform;
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        playerCheck = Physics.CheckSphere(transform.position, 3.5f, whatIsPlayer);

        if (playerCheck)
        {
            TalkToPlayer();
            if (T1) { playerUI.GetComponent<_EquipTutorUI>().training1 = true; }
            if (T2) { playerUI.GetComponent<_EquipTutorUI>().training2 = true; }
            if (T3) { playerUI.GetComponent<_EquipTutorUI>().training3 = true; }

        }

        if (!playerCheck)
        {
           
        }

    }

    void TalkToPlayer()
    {
        inGameMessage.text = message;
        playerPoint.position = new Vector3(playerPoint.position.x, transform.position.y, playerPoint.position.z);
        transform.LookAt(playerPoint);

        //anim taking

    }



    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 3.5f);

    }
}
