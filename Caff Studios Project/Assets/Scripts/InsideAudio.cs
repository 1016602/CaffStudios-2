using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideAudio : MonoBehaviour
{
    public GameObject outSideAudio;
    public GameObject insideAudio;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            insideAudio.SetActive(true);
            outSideAudio.SetActive(false);
        }
    }

}
