using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public int money;
    public List<string> buyItem = new List<string>();
}

public class SaveLoad
{
    public static SaveData Data = new SaveData();

    public static void Save()
    {
        var json = JsonUtility.ToJson(SaveLoad.Data);
        PlayerPrefs.SetString("Save", json);
        PlayerPrefs.Save();
    }

    public static void Load()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            var json = PlayerPrefs.GetString("Save");
            SaveLoad.Data = JsonUtility.FromJson<SaveData>(json);
        }
    }
}
