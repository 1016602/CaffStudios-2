using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissionCheckList;

public class _ShootWarning : MonoBehaviour
{
    public Camera fpsCam;
    public AudioSource shootWarningVoice;
    public GameObject checkList;

    public bool shouted = false;

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
                shouted = true;
                shootWarningVoice.Play();
                checkList.GetComponent<_TutorCheckList>().shootWarning = true;
                hit.collider.gameObject.GetComponent<_TutorialMissionAI>().shootWarned = true;
            }

        }
    }
}
