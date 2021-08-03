using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class k_PlayerState : MonoBehaviour
{
    public float playerHealth;
    public float currentHealth;


    public bool warning, taserWarning, shootingWarning;


    void Start()
    {
        currentHealth = playerHealth;
    }


    public void DecreaseHealth(float dam)
    {
        currentHealth = currentHealth - dam;
    }

}
