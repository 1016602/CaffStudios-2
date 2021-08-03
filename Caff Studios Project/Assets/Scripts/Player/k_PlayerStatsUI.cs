using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class k_PlayerStatsUI : MonoBehaviour
{
    public TMP_Text inGameMessage;
    public GameObject playerC;


    public Image HealthBar;
    public float currentHealth;
    public float maxHealth;

    public Image StressBar;
    public float currentStress;
    public float maxStress;

    public Image PanicBar;
    public float currentPanic;
    public float maxPanic;

    
    
    void Start()
    {
        currentHealth = maxHealth;
        currentStress = 0.01f;
        currentPanic = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        currentHealth = playerC.GetComponent<k_PlayerState>().currentHealth;

        HealthBar.fillAmount = currentHealth / maxHealth;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            //playerDie();
            currentHealth = 0;
        }

        StressBar.fillAmount = currentStress / maxStress;
        //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<k_breathingCam>().BreathCam(currentStress);
        if (currentStress >= maxStress)
        {    
            currentStress = maxStress;
        }

        PanicBar.fillAmount = currentPanic / maxPanic;
        if (currentPanic >= maxPanic)
        {
            currentPanic = maxPanic;
        }
    }


}
