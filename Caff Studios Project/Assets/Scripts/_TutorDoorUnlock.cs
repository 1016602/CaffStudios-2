using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TutorLevel;

public class _TutorDoorUnlock : MonoBehaviour
{
    public bool T1, T2;
    public GameObject model;
    public GameObject door;

    private bool st;

    void Update()
    {
        if (T1)
        {
            if (model.GetComponent<_TrainingModel1>().arrested == true)
            {
                door.GetComponent<_DoorOpen>().doorLocked = false;
            }
        }

        if (T2)
        {
            
            if (model.GetComponent<_TrainingModel1>().stuning == true) { st = true; }
                
            if (st == true && model.GetComponent<_TrainingModel1>().arrested == true)
            {
                door.GetComponent<_DoorOpen>().doorLocked = false;
            }
        }
        
    }
}
