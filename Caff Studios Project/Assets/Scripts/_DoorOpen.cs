using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _DoorOpen : MonoBehaviour
{
    public Transform doorFront;
    public Transform doorBack;
    public LayerMask whatIsPlayer;
    public bool playerCheck1, playerCheck2, doorLocked, voiceDoor;

    public GameObject lockIcon;

    public AudioSource audioSource;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        if (!doorLocked) { lockIcon.SetActive(false); }

        if (doorLocked && playerCheck1) { lockIcon.SetActive(true); }
        if (doorLocked && playerCheck2) { lockIcon.SetActive(true); }

        if (voiceDoor = true)
        {
            
                if (audioSource.isPlaying)
                {
                    doorLocked = true;
                }
                else
                {
                    doorLocked = false;
                }
            
        }


        playerCheck1 = Physics.CheckSphere(doorFront.position, 1, whatIsPlayer);
        playerCheck2 = Physics.CheckSphere(doorBack.position, 1, whatIsPlayer);

        if (playerCheck1 && !doorLocked)
        {
            if (Input.GetKey(KeyCode.E))
            {
                anim.SetBool("OpenB", true);
                anim.SetBool("CloseB", false);
                anim.SetBool("OpenA", false);
                anim.SetBool("CloseA", false);

            }
        }

        if (!playerCheck1)
        {
            StartCoroutine(DoorClosing());
        }

        if (playerCheck2 && !doorLocked)
        {
            if (Input.GetKey(KeyCode.E))
            {
                anim.SetBool("OpenB", false);
                anim.SetBool("CloseB", false);
                anim.SetBool("OpenA", true);
                anim.SetBool("CloseA", false);
            }
        }

        if (!playerCheck2)
        {
            StartCoroutine(DoorClosing2());
        }

    }

    IEnumerator DoorClosing()
    {
        yield return new WaitForSeconds(2);
        anim.SetBool("CloseB", true);
        anim.SetBool("OpenB", false);
    }

    IEnumerator DoorClosing2()
    {
        yield return new WaitForSeconds(2);
        anim.SetBool("CloseA", true);
        anim.SetBool("OpenA", false);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(doorFront.position, 1);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(doorBack.position, 1);

    }
}
