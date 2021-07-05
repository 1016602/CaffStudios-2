using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class k_popupTraining : MonoBehaviour
{
    public GameObject[] target;
    public Transform[] spwanPoint;
    int targetIndex;
    private GameObject targetA;
    private GameObject targetB;


    public float spwanTime;
    public int score;
    float currentTime = 0f;

    void Start()
    {
        currentTime = spwanTime;
    }

    void Update()
    {
        //Spawning timer
        currentTime -= 1 * Time.deltaTime;
        if (currentTime <= 0)
        {
            TargetSpwan();
            currentTime = spwanTime;
        }

    }

    void TargetSpwan()
    {
        //spwan Random targetA in location A
        targetIndex = Random.Range(0, target.Length);
        targetA = target[targetIndex];
        Instantiate(targetA, spwanPoint[0].position, Quaternion.Euler(0, 180, 0));

        //spwan Random targetB in location B, if the result == A, random pick a new number
        targetIndex = Random.Range(0, target.Length);
        targetB = target[targetIndex];
        while (targetB == targetA)
        {
            Debug.Log("same number");
            targetIndex = Random.Range(0, target.Length);
            targetB = target[targetIndex];
        }
        Instantiate(targetB, spwanPoint[1].position, Quaternion.Euler(0, 180, 0));
    }
}