using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TargetBoard_a : MonoBehaviour
{
    

    public TMP_Text position;
    public TMP_Text description;
    public GameObject image;
    public List<Sprite> popImage;

    public GameObject head;
    public GameObject weaponHand;
    public GameObject body;
    public GameObject leg;
    public GameObject arm;

    public bool _head, _weaponhand, _body, _leg, _arm;


    void Start()
    {
        
    }

    public void Headshot()
    {
        position.text = "Headshot";
        description.text = "Object die, panic level and stress level rise++";
        image.GetComponent<Image>().sprite = popImage[0];
    }

    public void Armshot()
    {
        position.text = "Arm";
        description.text = "Injure target";
        image.GetComponent<Image>().sprite = popImage[1];
    }

    public void Bodyshot()
    {
        position.text = "Body";
        description.text = "Injure target";
        image.GetComponent<Image>().sprite = popImage[1];
    }

    public void Legshot()
    {
        position.text = "Leg";
        description.text = "Injure target and target cannot move";
        image.GetComponent<Image>().sprite = popImage[2];
    }

    public void WaeopnArmshot()
    {
        position.text = "Arm (with weapon)";
        description.text = "Injure target and the target drop the weapon";
        image.GetComponent<Image>().sprite = popImage[3];
    }

    void Update()
    {
        if (transform.position.x >= 8)
        {
            transform.position = transform.position + new Vector3(-0.005f, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Armshot();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Bodyshot();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Headshot();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            Legshot();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            WaeopnArmshot();
        }

    }

}
