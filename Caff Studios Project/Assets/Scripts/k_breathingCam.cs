using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class k_breathingCam : MonoBehaviour
{
    //public float stressLevel;
    

    void Update()
    {
        
    }

    public void BreathCam(float stressLevel)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + (Mathf.PingPong(Time.time * stressLevel * 0.06f, stressLevel * 0.03f)), transform.position.z);
    }
}
