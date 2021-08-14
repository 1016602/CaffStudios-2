using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TutorLevel;


public class taserRoomVoice : MonoBehaviour
{
    public GameObject model;
    public GameObject playerTaser;
    public GameObject cuffAudio;
    public GameObject shoutAudio;
    public GameObject stunAudio;
    public GameObject introAudio;

    // Update is called once per frame
    void Update()
    {
        if (model.GetComponent<_TrainingModel1>().arrested == true)
        {
            cuffAudio.SetActive(true);
            //model.GetComponent<_TrainingModel1>().arrested = false;
            Destroy(introAudio);
            Destroy(shoutAudio);
            Destroy(stunAudio);
        }

        if (model.GetComponent<_TrainingModel1>().stuning == true)
        {
            stunAudio.SetActive(true);
            //model.GetComponent<_TrainingModel1>().stuning = false;
            Destroy(introAudio);
            Destroy(shoutAudio);

        }

        if (playerTaser.GetComponent<_ShootWarning>().shouted == true)
        {
            shoutAudio.SetActive(true);
            playerTaser.GetComponent<_ShootWarning>().shouted = false;
            Destroy(introAudio);
        }

    }
}
