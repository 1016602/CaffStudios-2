using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunRoomVoiceTrigger : MonoBehaviour
{
    public GameObject playerGun;

    public GameObject gunShoutAudio;
    public GameObject gunFinishedAudio;
    public GameObject introAudio;

    void Update()
    {
        if (playerGun.GetComponent<_ShootWarning>().shouted == true)
        {
            gunShoutAudio.SetActive(true);
            Destroy(introAudio);
            //playerGun.GetComponent<_ShootWarning>().shouted = false;
        }

        if (playerGun.GetComponent<Gun>().training == true)
        {
            gunFinishedAudio.SetActive(true);
            Destroy(introAudio);
            Destroy(gunShoutAudio);
            //playerGun.GetComponent<Gun>().training = false;
        }
    }
}

