using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkillManager : MonoBehaviour
{
    //현재 플레이어가 가지고 있는 스킬 종류, 개수, 스킬 강화, 스킬 삭제, 스킬 정보 찾기를 수행
    public static cSkillManager instance;

    Dictionary<string, int> skillID = new Dictionary<string, int>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void RegisterSkill(string name)
    {
        if (skillID.ContainsKey(name) == false)
            skillID.Add(name, 0);
        else
            skillID[name]++;
    }

    public void RemoveSkill(string name)
    {
        if (skillID.ContainsKey(name))
            skillID.Remove(name);
    }

    public void Enforce(SkillData skillData)
    {
        if (!skillID.ContainsKey(skillData.skillName))
        {
            Debug.LogError("cSkillManager - 가지고 있지 않은 스킬입니다.");
            return;
        }

        if (skillID.ContainsKey(skillData.skillName))
        {
            int value = skillID[skillData.skillName];
            if (value >= skillData.enforceAmount[skillData.level])
            {
                skillID[skillData.skillName] -= skillData.enforceAmount[skillData.level];
                skillData.level++;
            }
        }
    }

    public int ReturnSkillAmount(string name)
    {
        return skillID[name];
    }

    public bool CheckDuplicate(string name)
    {
        return skillID.ContainsKey(name);
    }
}
