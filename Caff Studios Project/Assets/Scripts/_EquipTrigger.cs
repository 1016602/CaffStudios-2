using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class _EquipTrigger : MonoBehaviour
{
    //player canvas UI
    public GameObject playerUI;
    public bool Handcuffs, Taser, Gun;

    public TMP_Text inGameMessage;
    public string message;
    public string message2;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Handcuffs)
            {
                playerUI.GetComponent<_EquipTutorUI>().training1 = true;
                inGameMessage.text = message;
            }

            if (Taser)
            {
                playerUI.GetComponent<_EquipTutorUI>().training2 = true;
                inGameMessage.text = message;
            }

            if (Gun)
            {
                playerUI.GetComponent<_EquipTutorUI>().training3 = true;
                inGameMessage.text = message;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Taser)
            {
                playerUI.GetComponent<_EquipTutorUI>().training2 = false;
                inGameMessage.text = message;
            }

            if (Gun)
            {
                playerUI.GetComponent<_EquipTutorUI>().training3 = false;
                inGameMessage.text = message;
            }
        }
    }

}
