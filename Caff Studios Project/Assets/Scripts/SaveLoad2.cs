using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad2 : MonoBehaviour
{
    public void Save(string Progress, int state)
    {
        PlayerPrefs.SetInt(Progress, state);
    }
    public int Load(string Progress)
    {
        return PlayerPrefs.GetInt(Progress);
    }


    //  SaveManager.Save("progress", number); //line to save data - progress is an int
    // *variable* = SaveManager.Load("progress"); //line to load or check data -  returns an int
}
