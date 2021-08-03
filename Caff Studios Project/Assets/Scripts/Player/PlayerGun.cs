using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    

    static public int mag;
    public int magSize;
    public GameObject pistol;
    static Animator anim;
    RaycastHit hit;
    void Start()
    {
        mag = magSize;
        anim = pistol.GetComponent<Animator>();
    }

    
    void Update()
    {

        //Section: Managing wether the gun can be fired or needs to be reloaded
        if (Input.GetButtonDown("Fire1"))
        {
            if(mag != 0)
            {
                //Fire(); // Triggering now handled by gun.cs
            }
            else
            {
                print("Click!");
            }

        }
        if (Input.GetKeyDown("r"))
        {
            if (mag != magSize)
            {
                {
                    anim.SetTrigger("Reloading");
                    anim.SetTrigger("Reloading");
                    print("Reloading:");
                    for (int i=mag; i<5; ++i)
                    {
                        print("chk");
                    }
                    mag = magSize;
                }
            }
            else
            {
                print("full");
            }
        }


    }
    //--------------------------------------------------------------
    public static void Fire()
    {
        print("Bang!");
        mag = mag - 1;
        if (mag == 0)
        {
            //play slide lockback
            anim.SetTrigger("FireLast");
        }
        else
        {
            anim.SetTrigger("Fire");
            anim.SetTrigger("Fire");// shoots - have to do twice to unflag the trigger, else animation seems to repeat - strange
        }
        
        
       /* Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            //hit.transform.gameObject.GetComponent<Renderer>().material = Material1; - testing artefact, turns walls green otherwise
            //In future, placing a bullet hole decal at the raycast hit
            print("hit something");
        }*/
    }




}
