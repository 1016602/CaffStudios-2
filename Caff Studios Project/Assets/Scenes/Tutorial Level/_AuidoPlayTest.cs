using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _AuidoPlayTest : MonoBehaviour
{

    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;

    public AudioSource gameAudio;


    void Start()
    {
        gameAudio = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameAudio.Stop();
            gameAudio.PlayOneShot(clip1);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            gameAudio.Stop();
            gameAudio.PlayOneShot(clip2);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            gameAudio.Stop();
            gameAudio.PlayOneShot(clip3);
        }

    }
}
