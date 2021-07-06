using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class k_Handcuffs : MonoBehaviour
{
    


    void Start()
    {
        //GameObject enemyAI = GameObject.FindGameObjectWithTag("Enemy");
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("OK");
                other.gameObject.GetComponent<k_EnemyState>().chAction = true;
            }
        }     
    }




    void Update()
    {

    }
}
