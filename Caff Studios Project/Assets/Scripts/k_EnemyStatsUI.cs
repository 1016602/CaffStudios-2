using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class k_EnemyStatsUI : MonoBehaviour
{
    public GameObject handcuffBarUI;
    public Image handcuffBar;
    public float currentHcLevel;
    public float maxHcLevel;

    public TMP_Text stunTimer;
    float stunTime = 8f;

    public bool stuning, chAction, arrested;

    float chTime = 0f;
    float startingTime = 2f;

    Animator anim;

    void Start()
    {
        arrested = false;
        currentHcLevel = 0f;
        chTime = startingTime;

        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (chAction)
        {
            anim.SetBool("Handcuffing", true);
            handcuffBar.fillAmount = currentHcLevel / maxHcLevel;

            handcuffBarUI.SetActive(true);

            if (chTime > 0) 
            {
                chTime -= 1 * Time.deltaTime;
                print(chTime);
            }
            if (chTime <= 0f)
            {
                chTime = 0f;
                Handcuff_Fail();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                currentHcLevel += 1f;
            }

            if (currentHcLevel == maxHcLevel)
            {
                Handcuff_Success();
            }
        }

        if (stuning)
        {
            Stun();
        }

    }

    void Handcuff_Fail()
    {
        anim.SetBool("Handcuffing", false);
        handcuffBarUI.SetActive(false);
        chAction = false;
        Start();
    }

    void Handcuff_Success()
    {
        handcuffBarUI.SetActive(false);
        chAction = false;
        Start();
        arrested = true;

        anim.SetBool("Stun", false);
        anim.SetBool("Handcuffing", false);
        anim.SetBool("Arrest", true);

        gameObject.GetComponent<_TutorAI>().arrested = true;
        
    }

    void Stun()
    {
        anim.SetBool("Stun", true);
        stunTime -= 1 * Time.deltaTime;
        stunTimer.text = stunTime.ToString("0");
        if (stunTime <= 0)
        {
            anim.SetBool("Stun", false);
            stunTimer.text = ("");
            stuning = false;
            stunTime = 8f;
        }

        gameObject.GetComponent<_TutorAI>().stun = true;

        if (chAction)
        {
            Handcuff_Success();
        }
    }

}
