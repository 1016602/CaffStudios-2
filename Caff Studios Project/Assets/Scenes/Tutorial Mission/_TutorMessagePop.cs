using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MissionCheckList;

public class _TutorMessagePop : MonoBehaviour
{
    public GameObject popUpUI;
    public Animator anim;

    void Start()
    {
        anim = anim.GetComponent<Animator>();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            popUpUI.SetActive(true);

            anim.SetBool("up", true);
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

        popUpUI.SetActive(false);
    }
}
