using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _warning : MonoBehaviour
{

    public Camera fpsCam;
    public AudioSource shootWarning;
    public bool shouted;

    // Start is called before the first frame update
    void Start()
    {
        shouted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            Warning();
        }
    }

    void Warning()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 10))
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                shootWarning.Play();
                shouted = true;
            }
        }
    }
}
