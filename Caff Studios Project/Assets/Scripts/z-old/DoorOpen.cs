using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public string openAnim1;
    public string openAnim2;

    public GameObject Door;
    public Animator anim;

    public bool doorClosed, arriveDoor, doorLock, doorUnlock;
 


    void Start()
    {
        anim = Door.GetComponent<Animator>();
        doorClosed = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FPS + gun")
        {
            Debug.Log("A");
            arriveDoor = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            arriveDoor = false;
            StartCoroutine(DoorClosing());
        }
    }

    void Update()
    {
        if (arriveDoor && doorClosed)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger(openAnim1);
                doorClosed = false;
            }
        }
    }

    IEnumerator DoorClosing()
    {
        yield return new WaitForSeconds(2);
        anim.SetTrigger(openAnim2);
        doorClosed = true;
    }

}
