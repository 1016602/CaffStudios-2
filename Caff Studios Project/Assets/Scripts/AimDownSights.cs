using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimDownSights : MonoBehaviour
{

    void Update()
    {
        if (Input.GetButton("Fire2")) // Script repurposed from previous project - neato!
        {
            transform.localPosition = (new Vector3(0.02f, -0.1034f, 0.25f)); // Raised and centered on screen to Aim down sights

        }
        else
        {

            transform.localPosition = (new Vector3(0.15f, -0.2f, 0.25f)); // if right click is not held, returns down to the side, Can still shoot.

        }
    }
}
