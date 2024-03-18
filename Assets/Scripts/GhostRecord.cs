using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GhostRecord
{
    public float time = float.MaxValue;
    public List<Vector3> positions = new List<Vector3>();
    public List<Quaternion> rotations = new List<Quaternion>();
    
    public void SaveToPrefs(string key)
    {
        string json = ToJson();

        try
        {
            PlayerPrefs.SetString(key, json);
            Debug.Log("## Lap Info Saved!");
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    public static GhostRecord LoadFromPrefs(string key)
    {
        string json = PlayerPrefs.GetString(key, "null");
        return GhostRecord.FromJson(json);
    }

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public static GhostRecord FromJson(string json)
    {        
        if (json == "null")
            return null;

        GhostRecord record = null;

        try 
        {
            record = JsonUtility.FromJson<GhostRecord>(json);
            Debug.Log("## Lap Info Retrieved!");
        } 
        catch (Exception e)
        {
            Debug.Log("## Loading JSON Prefs failed!");
            Debug.LogException(e);
        }

        return record;
    }
}
