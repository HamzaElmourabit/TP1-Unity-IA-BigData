using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class ClickEvent
{
    public string objectName;
    public float timestamp;
}

[System.Serializable]
public class PositionRecord
{
    public float x, y, z;
    public float timestamp;
}

[System.Serializable]
public class SessionData
{
    public int totalClicks;
    public float sessionDuration;
    public List<PositionRecord> positions = new List<PositionRecord>();
    public List<ClickEvent> clickEvents = new List<ClickEvent>();
}

public class DataLogger : MonoBehaviour
{
    public static DataLogger Instance;
    private SessionData session = new SessionData();
    private float startTime;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        startTime = Time.time;
        InvokeRepeating("LogCurrentPosition", 1f, 1f); // toutes les secondes
    }

    void LogCurrentPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PositionRecord pos = new PositionRecord();
            Vector3 p = player.transform.position;
            pos.x = p.x; pos.y = p.y; pos.z = p.z;
            pos.timestamp = Time.time - startTime;
            session.positions.Add(pos);
        }
    }

    public void RegisterClick(string objectName)
    {
        session.totalClicks++;
        ClickEvent evt = new ClickEvent();
        evt.objectName = objectName;
        evt.timestamp = Time.time - startTime;
        session.clickEvents.Add(evt);
    }

    void OnApplicationQuit()
    {
        session.sessionDuration = Time.time - startTime;
        SaveToCSV();
        SaveToJSON();
    }

    void SaveToCSV()
    {
        string path = Application.dataPath + "/session_data.csv";
        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine("Type,Timestamp,Data");
            sw.WriteLine($"SessionDuration,{session.sessionDuration},");
            sw.WriteLine($"TotalClicks,{session.totalClicks},");
            foreach (var pos in session.positions)
                sw.WriteLine($"Position,{pos.timestamp},\"{pos.x},{pos.y},{pos.z}\"");
            foreach (var click in session.clickEvents)
                sw.WriteLine($"Click,{click.timestamp},{click.objectName}");
        }
        Debug.Log("CSV saved to " + path);
    }

    void SaveToJSON()
    {
        string json = JsonUtility.ToJson(session, true);
        string path = Application.dataPath + "/session_data.json";
        File.WriteAllText(path, json);
        Debug.Log("JSON saved to " + path);
    }
}