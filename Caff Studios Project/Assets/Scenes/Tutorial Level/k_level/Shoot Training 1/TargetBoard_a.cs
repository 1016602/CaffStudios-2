using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TargetBoard_a : MonoBehaviour
{
    public TMP_Text message;
    //public GameObject image;
    //public List<Sprite> popImage;


    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.x >= 8)
        {
            transform.position = transform.position + new Vector3(-0.005f, 0, 0);
        }
    }

}
