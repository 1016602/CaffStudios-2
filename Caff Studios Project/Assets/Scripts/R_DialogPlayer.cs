using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_DialogPlayer : MonoBehaviour
{
    public GameObject model;
    public GameObject playerHands;
    public GameObject cuffAudio;
    public GameObject shoutAudio;
 

    

    // Start is called before the first frame update
    void Update()
    {
        if (model.GetComponent<k_EnemyStatsUI>().arrested == true)
        {
            cuffAudio.SetActive(true);
            model.GetComponent<k_EnemyStatsUI>().arrested = false;
           
        }

        if (playerHands.GetComponent<_Alert>().shouted == true)
        {
            shoutAudio.SetActive(true);
            playerHands.GetComponent<_Alert>().shouted = false;
        }

        
    }


   
}
