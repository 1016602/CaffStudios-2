using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TaserGun : MonoBehaviour
{
    public Camera fpsCam;



    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireTaser();
        }
    }

    void FireTaser()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 20f))
        {
            if (hit.collider.gameObject.name == "Training model (1)")
            {
                hit.collider.gameObject.GetComponent<k_EnemyStatsUI>().stuning = true;
            }
        }
    }
}
