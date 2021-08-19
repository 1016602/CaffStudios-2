using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TutorLevel;

public class _TutorDoorUnlock : MonoBehaviour
{
    public bool T1, T2, T3;
    public GameObject model;
    public GameObject door;

    public GameObject TaskUI1;
    public GameObject TaskUI2;
    public GameObject TaskUI3;


    private bool st;

    void Update()
    {
        if (T1)
        {
            if (model.GetComponent<_TrainingModel1>().arrested == true)
            {
                door.GetComponent<_DoorOpen>().doorLocked = false;
                TaskUI1.SetActive(true);
            }
        }

        if (T2)
        {
            
            if (model.GetComponent<_TrainingModel1>().stuning == true) { st = true; }
                
            if (st == true && model.GetComponent<_TrainingModel1>().arrested == true)
            {
                door.GetComponent<_DoorOpen>().doorLocked = false;
                TaskUI2.SetActive(true);
            }
        }

        if (T3)
        {
            if (model.GetComponent<_ShootWarning>().shouted == true && model.GetComponent<Gun>().training == true)
            {
                door.GetComponent<_DoorOpen>().doorLocked = false;
                TaskUI3.SetActive(true);
            }
           
        }
        
    }
}
