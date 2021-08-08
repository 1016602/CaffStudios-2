using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveloadtester : MonoBehaviour
{
    int number;
    public SaveLoad2 SaveManager;
    public Text textBox;
    void Start()
    {

        //SaveManager = GameObject.Find("SaveLoadController");
        number = SaveManager.Load("progress"); //&
    }

    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            number = number + 1;
        }
        if (Input.GetKeyDown("down") && number != 0)
        {
            number = number - 1;
        }
        if (Input.GetKeyDown("right"))
        {
            number = 10;
        }
        if (Input.GetKeyDown("left"))
        {
            SaveManager.Save("progress", number); //&


        }
        textBox.text = number.ToString();
    }
}
