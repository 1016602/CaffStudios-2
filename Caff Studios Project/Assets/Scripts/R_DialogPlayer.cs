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
 

    

    // Start is called before the first frame update
    void Update()
    {
        if (model.GetComponent<_TrainingModel1>().arrested == true)
        {
            cuffAudio.SetActive(true);
            //model.GetComponent<_TrainingModel1>().arrested = false;
           
        }

        if (playerHands.GetComponent<_Alert>().shouted == true)
        {
            shoutAudio.SetActive(true);
            playerHands.GetComponent<_Alert>().shouted = false;
        }

        
    }


   
}
