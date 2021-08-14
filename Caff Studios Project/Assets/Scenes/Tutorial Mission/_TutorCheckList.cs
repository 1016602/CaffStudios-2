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

        public int score;
        public TMP_Text playerScore;

        void Start()
        {
            calculateScore = true;
        }

        void Update()
        {
            playerScore.text = score.ToString();
            if (score <= 0) { score = 0; }

            if (arrested == true || Enemy.GetComponent<_TutorialMissionAI>().escaped)
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
            if (arrested == true) { score += 10; }

            if (gunShoot == true) { score -= 20; }
            if (shootTaser == true) { score -= 5; }
            if (aiEscape == true) { score -= 10; }
            

            calculateScore = false;


        }



    }


}






