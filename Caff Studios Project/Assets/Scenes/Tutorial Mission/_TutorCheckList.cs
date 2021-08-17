using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;


namespace MissionCheckList
{
    public class _TutorCheckList : MonoBehaviour
    {
        public bool alerted, nPC, shootWarning, arrested, gunShoot, aiEscape, shootTaser, calculateScore;

        public GameObject player;
        public GameObject Enemy;
        public GameObject NPC;

        public GameObject ResultUI;
        public GameObject Pass;
        public GameObject Fail;

        public int score;
        //public TMP_Text playerScore;

        void Start()
        {
            calculateScore = true;
        }

        void Update()
        {
            //playerScore.text = score.ToString();
            if (score < 0) 
            { 
                Fail.SetActive(true);
                //score = 0; 
            }

            if (score > 0)
            {
                Pass.SetActive(true);
                //score = 0; 
            }

            if (arrested == true || aiEscape == true || gunShoot == true)
            {
                MissionResult();
            }


            if (Enemy.GetComponent<_TutorialMissionAI>().warned == true) { alerted = true; }
            if (Enemy.GetComponent<_TutorialMissionAI>().shootWarned == true) { shootWarning = true; }
            if (Enemy.GetComponent<_TutorialMissionAI>().arrested == true) { arrested = true; }

            if (Enemy.GetComponent<_TutorialMissionAI>().stunned == true) { shootTaser = true; }
            if (Enemy.GetComponent<_TutorialMissionAI>().escaped == true) { aiEscape = true; }
        }

        public void MissionResult()
        {
            ResultUI.SetActive(true);
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (calculateScore == true) { ScoreCalculate(); }
        }

        public void ScoreCalculate()
        {

            if (alerted == true) { score += 5; }
            if (shootWarning == true) { score += 5; }
            if (nPC == true) { score += 10; }
            if (arrested == true) { score += 50; }

            if (gunShoot == true) { score -= 50; }
            if (shootTaser == true) { score -= 5; }
            if (aiEscape == true) { score -= 50; }
            

            calculateScore = false;


        }



    }


}






