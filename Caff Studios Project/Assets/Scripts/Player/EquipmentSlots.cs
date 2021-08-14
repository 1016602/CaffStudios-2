using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlots : MonoBehaviour
{
    public GameObject equiptmentSlot1;
    public GameObject hand;

    public GameObject equiptmentSlot2;
    public GameObject handcuff;

    public GameObject equiptmentSlot3;
    public GameObject taser;

    public GameObject equiptmentSlot4;
    public GameObject gun;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            equiptmentSlot1.SetActive(true);
            hand.SetActive(true);

            equiptmentSlot2.SetActive(false);
            handcuff.SetActive(false);

            equiptmentSlot3.SetActive(false);
            taser.SetActive(false);

            equiptmentSlot4.SetActive(false);
            gun.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            equiptmentSlot1.SetActive(false);
            hand.SetActive(false);

            equiptmentSlot2.SetActive(true);
            handcuff.SetActive(true);

            equiptmentSlot3.SetActive(false);
            taser.SetActive(false);

            equiptmentSlot4.SetActive(false);
            gun.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            equiptmentSlot1.SetActive(false);
            hand.SetActive(false);

            equiptmentSlot2.SetActive(false);
            handcuff.SetActive(false);

            equiptmentSlot3.SetActive(true);
            taser.SetActive(true);

            equiptmentSlot4.SetActive(false);
            gun.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            equiptmentSlot1.SetActive(false);
            hand.SetActive(false);

            equiptmentSlot2.SetActive(false);
            handcuff.SetActive(false);

            equiptmentSlot3.SetActive(false);
            taser.SetActive(false);

            equiptmentSlot4.SetActive(true);
            gun.SetActive(true);
        }
    }
}
