using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class k_ShootTrain : MonoBehaviour
{
    public GameObject train1;
    public GameObject train2;
    public GameObject trainingUI;
    public GameObject trainingMessage;

    public bool arrive, t_active;


    void OnTriggerEnter(Collider other)
    {
        trainingUI.SetActive(true);
        arrive = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trainingMessage.SetActive(false);
            trainingUI.SetActive(false);
            t_active = false;
            arrive = false;
        }
    }

    void ActiveGame()
    {
        if (arrive)
        {
            
            if (!t_active && Input.GetKeyDown(KeyCode.K))
            {
                trainingUI.SetActive(false);
                train1.SetActive(true);
                t_active = true;
            }

            if (!t_active && Input.GetKeyDown(KeyCode.L))
            {
                trainingUI.SetActive(false);
                train2.SetActive(true);
                t_active = true;
            }
        }
        if (!arrive)
        {
            train1.SetActive(false);
            train2.SetActive(false);
        }
    }


        void Update()
        {
            ActiveGame();

            if (t_active)
            {   trainingMessage.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    trainingMessage.SetActive(false);
                    t_active = false;
                    trainingUI.SetActive(true);
                    train1.SetActive(false);
                    train2.SetActive(false);
                }
            }
        }
    }
