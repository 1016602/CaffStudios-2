using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MissionCheckList;

public class _TutorMessagePop : MonoBehaviour
{
    public GameObject popUpUI;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            popUpUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            popUpUI.SetActive(false);
        }
    }
}
