using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Stats
{
    public int statLevel;
    public int statIncrease;
    public long stat;
    public long pureStat;
}

public class CharactorStats
{
    public int charStatLevel;
    public float charStatIncrease;
    public float charStatRate;
}

public class StatsDataManager : MonoBehaviour
{
    static public StatsDataManager instance;
    string path => Application.persistentDataPath + "/stat";

    void Awake()
    {
        instance = this;
    }

    public void SaveStatsData(Stats data, string name)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path + name + ".json", json);
    }

    public void SaveCharStatsData(CharactorStats data, string name)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path + "char" + name + ".json", json);
    }

    public Stats LoadStatsData(string name)
    {
        if (!File.Exists(path + name + ".json"))
            return null;

        string json = File.ReadAllText(path + name + ".json");
        return JsonUtility.FromJson<Stats>(json);
    }

    public CharactorStats LoadCharStatsData(string name)
    {
        if (!File.Exists(path + "char" + name + ".json"))
            return null;

        string json = File.ReadAllText(path + "char" + name + ".json");
        return JsonUtility.FromJson<CharactorStats>(json);
    }
}
