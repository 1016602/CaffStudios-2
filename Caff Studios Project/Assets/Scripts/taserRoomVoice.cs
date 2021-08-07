using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taserRoomVoice : MonoBehaviour
{
    public GameObject model;
    public GameObject playerTaser;
    public GameObject cuffAudio;
    public GameObject shoutAudio;
    public GameObject stunAudio;

    // Update is called once per frame
    void Update()
    {
        if (model.GetComponent<k_EnemyStatsUI>().arrested == true)
        {
            cuffAudio.SetActive(true);
            model.GetComponent<k_EnemyStatsUI>().arrested = false;

        }

        if (model.GetComponent<k_EnemyStatsUI>().stunn == true)
        {
            stunAudio.SetActive(true);
            model.GetComponent<k_EnemyStatsUI>().stunn = false;

        }

        if (playerTaser.GetComponent<_ShootWarning>().shouted == true)
        {
            shoutAudio.SetActive(true);
            playerTaser.GetComponent<_ShootWarning>().shouted = false;
        }

    }
}
