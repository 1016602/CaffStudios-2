using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlots : MonoBehaviour
{
    public GameObject equiptmentSlot1;
    public GameObject equiptmentSlot2;
    public GameObject equiptmentSlot3;
    public GameObject equiptmentSlot4;
    public GameObject gun;
    public GameObject taser;
    public GameObject handcuff;
    public GameObject hand;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            equiptmentSlot1.SetActive(true);
            gun.SetActive(true);
            equiptmentSlot2.SetActive(false);
            equiptmentSlot3.SetActive(false);
            equiptmentSlot4.SetActive(false);
            taser.SetActive(false);
            handcuff.SetActive(false);
            hand.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            equiptmentSlot1.SetActive(false);
            gun.SetActive(false);
            equiptmentSlot2.SetActive(true);
            equiptmentSlot3.SetActive(false);
            equiptmentSlot4.SetActive(false);
            taser.SetActive(true);
            handcuff.SetActive(false);
            hand.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            equiptmentSlot1.SetActive(false);
            gun.SetActive(false);
            equiptmentSlot2.SetActive(false);
            equiptmentSlot3.SetActive(true);
            equiptmentSlot4.SetActive(false);
            taser.SetActive(false);
            handcuff.SetActive(true);
            hand.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            equiptmentSlot1.SetActive(false);
            gun.SetActive(false);
            equiptmentSlot2.SetActive(false);
            equiptmentSlot3.SetActive(false);
            taser.SetActive(false);
            handcuff.SetActive(false);
            equiptmentSlot4.SetActive(true);
            hand.SetActive(true);
        }
    }
}
