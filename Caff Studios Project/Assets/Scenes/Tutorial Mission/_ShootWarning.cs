using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissionCheckList;

public class _ShootWarning : MonoBehaviour
{
    public Camera fpsCam;
    public AudioSource shootWarningVoice;
    public GameObject checkList;

    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            ShootWarning();
        }
    }

    void ShootWarning()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 20))
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                shootWarningVoice.Play();
                checkList.GetComponent<_TutorCheckList>().shootWarning = true;
            }

        }
    }
}
