using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurrenderStateController : MonoBehaviour
{
    /*Script that controls Surrender States (duh)
     * When the player "shouts" at an enemy, the enemy will go through a series of states, including an initial hands up surrender, dropping their gun (probably using physics)
     * and laying down to be arrested.
     * In future, Random number generation for factors like flash / concussive devices (not exactly police standard issue - but we want to encourage LL), 
     * target may also randomly ignore commands or false surrender Zero-Hour Style*/

    //also - this should be put on a humanoid target w/ animator

    //State Legend: 0 - Normal, 1 - Hands Up, 2 - Drop weapon, 3 - Lay Down

    public int state;
    Animator charAnim;
    float timer;
    public Material stg1;
    public Material stg2;
    public Material stg3;

    void Start()
    {
        state = 0;
    }

    void Command()
    {
        print("command received:");
        StopCoroutine("Decay");
        if (state == 0)
        {
            state = 1;
            print("Hands Up");
            GetComponent<Renderer>().material = stg1;
            StartCoroutine("Decay");
            //animator state hands up
        }
        else if (state == 1)
        {
            state = 2;
            print("Drop Weapon");
            GetComponent<Renderer>().material = stg2;
            StartCoroutine("Decay");
            //animator state throw weapon
        }
        else if (state == 2)
        {
            state = 3;
            print("Get Down");
            GetComponent<Renderer>().material = stg3;
            StartCoroutine("Decay");
            //guess.
        }
        else if (state == 3)
        {
            print("already surrendered");
            //no anim change
        }

    }

    
    void Update()
    {
        // Will implement a timer here, if an enemy is left unattended for too long they will begin to revert to normal state - hazardous
    }

    IEnumerator Decay()
    {
        var wait = new WaitForSeconds(Random.Range(5f, 15f));
        yield return wait;
        state = state - 1;
        print("state decay");
        if (state != 0)
        {
            StartCoroutine("Decay");
        }
    }
}
