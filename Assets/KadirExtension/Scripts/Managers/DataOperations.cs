using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class DataOperations : Singleton<DataOperations>
{
    public GameDatas gameDatas;


    public void SaveData()
    {
        PlayerPrefs.SetString("GameDatas", JsonUtility.ToJson(gameDatas));
        PlayerPrefs.Save();
    }

    void OnApplicationQuit()
    {
        SaveData();
    }
    void OnApplicationPause(bool paused)
    {
        if (paused)
            OnApplicationQuit();
    }
}