using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunRoomVoiceTrigger : MonoBehaviour
{
    public GameObject playerGun;

    public GameObject gunShoutAudio;
    public GameObject gunFinishedAudio;

    // Update is called once per frame
    void Update()
    {
        if (playerGun.GetComponent<_ShootWarning>().shouted == true)
        {
            gunShoutAudio.SetActive(true);
            playerGun.GetComponent<_ShootWarning>().shouted = false;
        }

        if (playerGun.GetComponent<Gun>().training == true)
        {
            gunFinishedAudio.SetActive(true);
            playerGun.GetComponent<Gun>().training = false;
        }
    }
}

