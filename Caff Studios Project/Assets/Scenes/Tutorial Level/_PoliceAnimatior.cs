using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PoliceAnimatior : MonoBehaviour
{

    public bool sitting1, sitting2, sitWorking, talking, talking2, idle, idle2, idle3;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (sitting1) { anim.SetBool("Sitting1", true); }

        if (sitting2) { anim.SetBool("Sitting2", true); }

        if (sitWorking) { anim.SetBool("Typing", true); }

        if (talking) { anim.SetBool("Talking1", true); }

        if (talking2) { anim.SetBool("Talking2", true); }

        if (idle) { anim.SetBool("Idle1", true); }

        if (idle2) { anim.SetBool("Idle2", true); }

        if (idle3) { anim.SetBool("Idle3", true); }
    }
}
