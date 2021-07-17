using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class k_PlayerState : MonoBehaviour
{
    public TMP_Text inGameMessage;

    public bool warning, taserWarning, shootingWarning;


    void Start()
    {

    }



    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Room1")
        {
            Debug.Log("room1");
            inGameMessage.text = "Room 1";
        }
    }
}
