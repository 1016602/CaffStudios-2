using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TutorHandcuff : MonoBehaviour
{
    public bool readyToUse;
    public float rate = 15f;
    private float nextTimeToUse = 0f;

    public Camera fpsCam;
    public float range = 2f;
    //public AudioSource taserShot;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            readyToUse = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            readyToUse = false;

        }
    }


    void Update()
    {
        if (readyToUse == true && Input.GetButtonDown("Fire1") && Time.time >= nextTimeToUse)
        {
            anim.SetTrigger("Use");
            nextTimeToUse = Time.time + rate;
            Handcuff();
        }
    }

    void Handcuff()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<_TrainingModel1>().chAction = true;
                
            }
        }
    }

}
