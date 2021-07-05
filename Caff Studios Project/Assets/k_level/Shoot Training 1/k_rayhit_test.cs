using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class k_rayhit_test : MonoBehaviour
{
    public Camera fpsCam;
    public TMP_Text position;
    public TMP_Text description;



    void Start()
    {
        
    }

    // Update is called once per frame
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
                position.text = "Body";
                description.text = "Injure target";
            }

            if (hit.collider.gameObject.name == "Head")
            {
                position.text = "Headshot";
                description.text = "Object die, panic level and stress level rise++";
            }

            if (hit.collider.gameObject.name == "Arm_weapon")
            {
                position.text = "Arm (with weapon)";
                description.text = "Injure target and the target drop the weapon";
            }
        }
    }
}
