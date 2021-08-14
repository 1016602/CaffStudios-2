using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TutorLevel;

public class R_DialogPlayer : MonoBehaviour
{
    public GameObject model;
    public GameObject playerHands;
    public GameObject cuffAudio;
    public GameObject shoutAudio;
    public GameObject introAudio;

    

    // Start is called before the first frame update
    void Update()
    {
        if (model.GetComponent<_TrainingModel1>().arrested == true)
        {
            cuffAudio.SetActive(true);
            Destroy(introAudio);
            Destroy(shoutAudio);

            //model.GetComponent<_TrainingModel1>().arrested = false;
           
        }

        if (playerHands.GetComponent<_Alert>().shouted == true)
        {
            shoutAudio.SetActive(true);
            Destroy(introAudio);
            playerHands.GetComponent<_Alert>().shouted = false;
        }

        
    }


   
}
