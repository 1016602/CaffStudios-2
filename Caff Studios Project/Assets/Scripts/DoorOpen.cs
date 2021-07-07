using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    bool arriveDoor, doorLock, doorUnlock;
    Animator anim;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FPS + gun")
        {
            Debug.Log("enter");
            arriveDoor = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            arriveDoor = false;
            anim.SetTrigger("closing");
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (arriveDoor)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger("open door");
            }
        }

    }
}
