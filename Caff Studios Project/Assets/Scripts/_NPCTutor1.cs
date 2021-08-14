using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _NPCTutor1 : MonoBehaviour
{
    public bool trigger, helped, stun;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trigger = false;
        }
    }

    void Update()
    {
        if (trigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("Help", true);
                helped = true;
            }
        }

        if (stun)
        {
            anim.SetBool("Stun", true);
            anim.SetBool("Help", false);
        }
    }
}
