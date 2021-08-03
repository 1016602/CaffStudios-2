using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class k_rayhit_test : MonoBehaviour
{
    public Camera fpsCam;
    //public TMP_Text position;
    public TMP_Text description;



    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit,  50f))
        {
            Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * 10000f, Color.green, 2f);
            Debug.Log(hit.transform.name);

            if (hit.collider.gameObject.name == "Body")
            {
                description.text = "Body: Injure target.";
            }

            if (hit.collider.gameObject.name == "Head")
            {
                description.text = "Headshot: Object die, panic level and stress level rise++.";
            }

            if (hit.collider.gameObject.name == "Arm_weapon")
            {
                description.text = "Arm (with weapon): Injure target and the target drop the weapon.";
            }

            if (hit.collider.gameObject.name == "Leg")
            {
                description.text = "Leg: Injure target and target cannot move.";
            }

            if (hit.collider.gameObject.name == "Innocence")
            {
                description.text = "You kill an citizen!";
            }

        }
    }
}
