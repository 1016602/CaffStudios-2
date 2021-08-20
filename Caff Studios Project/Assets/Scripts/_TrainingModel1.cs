using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace TutorLevel
{
    public class _TrainingModel1 : MonoBehaviour
    {

        public GameObject handcuffBarUI;
        public Image handcuffBar;
        public float currentHcLevel;
        public float maxHcLevel;

        public TMP_Text stunTimer;
        public float stunTime = 8f;
        float currentStunTime;

        float chTime = 0f;
        public float HandcuffTime = 2f;

        Animator anim;

        public bool stuning, chAction, arrested;


        void Start()
        {
            chAction = false;
            stuning = false;
            arrested = false;

            currentHcLevel = 0f;
            chTime = HandcuffTime;

            currentStunTime = stunTime;

            anim = GetComponent<Animator>();
        }

        void Update()
        {

            if (chAction && !arrested)
            {
                anim.SetBool("Handcuffing", true);
                handcuffBar.fillAmount = currentHcLevel / maxHcLevel;

                handcuffBarUI.SetActive(true);

                if (chTime > 0)
                {
                    chTime -= 1 * Time.deltaTime;
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

            if (stuning && !arrested)
            {
                Stun();
            }

            if (stuning && chAction)
            {
                Handcuff_Success();
            }

            if (arrested)
            {
                StartCoroutine(_Arrest());
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

        }

        void Stun()
        {
            anim.SetBool("Stun", true);
            currentStunTime -= 1 * Time.deltaTime;
            stunTimer.text = currentStunTime.ToString("0");

            if (currentStunTime <= 0)
            {
                anim.SetBool("Stun", false);
                stunTimer.text = ("");
                stuning = false;
                anim.SetBool("Stun", false);
                Start();
            }

        }

        IEnumerator _Arrest()
        {
            anim.SetBool("Stun", false);
            anim.SetBool("Handcuffing", false);
            anim.SetBool("Arrested", true);

            yield return new WaitForSeconds(5);
            anim.SetBool("Arrested", false);
            Start();

        }

    }
}

