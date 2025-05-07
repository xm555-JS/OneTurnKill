using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CustomData
{
    public int hairIndex;
    public int clothIndex;
    public int pantIndex;
    public int armorIndex;
    public int helmetIndex;
    public int backIndex;
    public int weaponIndex;
}

public class CustomDataManager : MonoBehaviour
{
    static public CustomDataManager instance;

    void Awake()
    {
        instance = this;
    }

    string path => Application.persistentDataPath + "/custom.json";
    string equipPath => Application.persistentDataPath + "/equip.json";


    public void SaveCustomData(CustomData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }

    public CustomData LoadCustomData()
    {
        if (!File.Exists(path))
            return null;

        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<CustomData>(json);
    }

    public void SaveEquipData(CustomData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(equipPath, json);
    }

    public CustomData LoadEquipData()
    {
        if (!File.Exists(equipPath))
            return null;

        string json = File.ReadAllText(equipPath);
        return JsonUtility.FromJson<CustomData>(json);
    }
}
