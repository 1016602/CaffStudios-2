using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outsideAudio : MonoBehaviour
{
    public GameObject outAudio;
    public GameObject inAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inAudio.SetActive(false);
            outAudio.SetActive(true);
        }
    }


}
