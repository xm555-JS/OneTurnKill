using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDataManager : MonoBehaviour
{
    [SerializeField] SkillData[] skillData;

    public SkillData GetSkillData(string skillName)
    {
        SkillData skill = null;
        foreach (var data in skillData)
        {
            if (data.skillName == skillName)
            {
                skill = data;
            }
        }
        return skill;
    }
}
