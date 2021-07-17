using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissionCheckList;

public class _Alert : MonoBehaviour
{
    public Camera fpsCam;
    public AudioSource alertVoice;
    public GameObject checkList;

    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            Alert();
        }
    }

    void Alert()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 20))
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                alertVoice.Play();
                checkList.GetComponent<_TutorCheckList>().alerted = true;
            }
            
        }
    }
}
