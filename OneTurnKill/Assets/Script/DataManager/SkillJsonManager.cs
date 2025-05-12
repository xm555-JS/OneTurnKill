using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SkillSaveData
{
    public string skillGrade;
    public int skillIndex;
}

[System.Serializable]
public class SkillDataListWrapper
{
    public List<SkillSaveData> skills = new List<SkillSaveData>();
}

public class SkillJsonManager : MonoBehaviour
{
    static public SkillJsonManager instance;

    string path => Application.persistentDataPath + "/skill.json";
    
    void Awake()
    {
        instance = this;
    }

    public void SaveData(SkillSaveData data)
    {
        List<SkillSaveData> skillList = LoadData();
        if (skillList == null)
            skillList = new List<SkillSaveData>();

        skillList.Add(data);

        SkillDataListWrapper dataWrapper = new SkillDataListWrapper();
        dataWrapper.skills = skillList;

        string json = JsonUtility.ToJson(dataWrapper, true);
        File.WriteAllText(path, json);
    }

    public List<SkillSaveData> LoadData()
    {
        if (!File.Exists(path))
            return null;

        string json = File.ReadAllText(path);
        SkillDataListWrapper wrapper = JsonUtility.FromJson<SkillDataListWrapper>(json);
        return wrapper.skills;
    }
}
