using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TaserGun : MonoBehaviour
{
    public Camera fpsCam;
    public float range = 10f;
    public AudioSource taserShot;
    public float fireRate = 15f;

    private float nextTimeToFire = 0f;

    public ParticleSystem electFlash;
    public GameObject impactEffect;


    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            FireTaser();
        }
    }

    void FireTaser()
    {
        electFlash.Play();
        taserShot.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.collider.gameObject.name == "Training model (1)")
            {
                hit.collider.gameObject.GetComponent<k_EnemyStatsUI>().stuning = true;
                GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGo, 4f);
            }
        }

    }
}
