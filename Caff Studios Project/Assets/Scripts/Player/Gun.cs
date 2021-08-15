using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissionCheckList;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public AudioSource gunShot;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public GameObject checkList;



    private float nextTimeToFire = 0f;
    public bool training = false;

    void Start()
    {
        PlayerGun playerGun = GetComponent<PlayerGun>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            PlayerGun.Fire();

            

            if (PlayerGun.mag != 0)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
                PlayerGun.Fire();

                checkList.GetComponent<_TutorCheckList>().gunShoot = true;
            }
        }

        
    }

    void Shoot()
    {
        checkList.GetComponent<_TutorCheckList>().gunShoot = true;
        muzzleFlash.Play();
        gunShot.Play();
        checkList.GetComponent<_TutorCheckList>().gunShoot = true;
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

           GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
           Destroy(impactGo, 2f);


            if (hit.collider.gameObject.tag == "Training")
            {
                training = true;
            }
        }
    }
}
