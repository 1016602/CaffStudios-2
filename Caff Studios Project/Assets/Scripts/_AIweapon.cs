using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _AIweapon : MonoBehaviour
{
    
    public int attackDamage = 10;
    public AudioSource hitsound;

    public void Start()
    {
        hitsound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            //audio.Play();
            other.GetComponent<k_PlayerState>().DecreaseHealth(attackDamage);
        }

        if (other.gameObject.tag == "Target")
        {
            hitsound.Play();
            
        }
    }
}
