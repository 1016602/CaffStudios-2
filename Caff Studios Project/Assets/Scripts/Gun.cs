using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public AudioSource gunShot;

    public Camera fpsCam;
    //public ParticleSystem muzzleFlash;
   // public GameObject impactEffect;

    private float nextTimeToFire = 0f;
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

    }

    void Shoot()
    {
        //muzzleFlash.Play();
        gunShot.Play();

        RaycastHit hit;
        if
        (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            //GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
           // Destroy(impactGo, 2f);
        }
    }
}
