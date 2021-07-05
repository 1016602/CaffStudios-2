using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    

    int mag;
    public Material Material1;
    public GameObject pistol;
    Animator anim;
    RaycastHit hit;
    void Start()
    {
        mag = 5;
        anim = pistol.GetComponent<Animator>();
    }

    
    void Update()
    {

        //Section: Managing wether the gun can be fired or needs to be reloaded
        if (Input.GetButtonDown("Fire1"))
        {
            if(mag != 0)
            {
                Shoot();
            }
            else
            {
                print("Click!");
            }

        }
        if (Input.GetKeyDown("r"))
        {
            if (mag != 5)
            {
                {
                    anim.SetTrigger("Reloading");
                    anim.SetTrigger("Reloading");
                    print("Reloading:");
                    for (int i=mag; i<5; ++i)
                    {
                        print("chk");
                    }
                    mag = 5;
                }
            }
            else
            {
                print("full");
            }
        }

        //shouting commands
        if (Input.GetKeyDown("f"))
        {
            print("attempted shout");
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                print("Shout Heard");
                hit.transform.gameObject.SendMessage("Command", SendMessageOptions.DontRequireReceiver);
           }
        }
    }
    //--------------------------------------------------------------
    void Shoot()
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
        
        
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            //hit.transform.gameObject.GetComponent<Renderer>().material = Material1; - testing artefact, turns walls green otherwise
            //In future, placing a bullet hole decal at the raycast hit
            print("hit something");
        }
    }




}
