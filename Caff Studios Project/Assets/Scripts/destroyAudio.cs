using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAudio : MonoBehaviour
{
    public GameObject audio;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(audio);
    }
}
