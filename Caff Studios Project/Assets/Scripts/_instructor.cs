using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class _instructor : MonoBehaviour
{

    public GameObject Audio;
    public GameObject triggerArea;
    public Transform lookPosition;
    public LayerMask whatIsPlayer;
    bool playerCheck;

    public TMP_Text inGameMessage;

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
        playerCheck = Physics.CheckSphere(triggerArea.transform.position, 2f, whatIsPlayer);

        if (playerCheck)
        {
            TalkToPlayer();
        }

        if (!playerCheck)
        {
            transform.LookAt(lookPosition);
            anim.SetBool("Talking", false);

        }
    }

    void TalkToPlayer()
    {

        Audio.SetActive(true);
        inGameMessage.text = message;
        playerPoint.position = new Vector3(playerPoint.position.x, transform.position.y, playerPoint.position.z);
        transform.LookAt(playerPoint);

        anim.SetBool("Talking", true);

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(triggerArea.transform.position, 2f);

    }
}
