using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shout : MonoBehaviour
{
    public Camera fpsCam;
    public GameObject fpc;

    RaycastHit hit;
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            print("attempted shout");

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
            {
                print("Shout Heard");
                hit.transform.gameObject.SendMessage("Command", SendMessageOptions.DontRequireReceiver);
                fpc.GetComponent<k_PlayerState>().taserWarning = true;
            }
        }
    }
}
