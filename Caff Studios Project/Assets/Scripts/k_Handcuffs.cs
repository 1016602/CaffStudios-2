using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class k_Handcuffs : MonoBehaviour
{
    private GameObject enemyAI;
    public bool readyToUse;
    public float rate = 15f;
    private float nextTimeToUse = 0f;


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
        enemyAI = GameObject.FindGameObjectWithTag("Enemy");
        if (readyToUse ==true && Input.GetButtonDown("Fire1") && Time.time >= nextTimeToUse)
        {
            nextTimeToUse = Time.time + rate;
            enemyAI.gameObject.GetComponent<k_EnemyStatsUI>().chAction = true;
        }
    }
}
