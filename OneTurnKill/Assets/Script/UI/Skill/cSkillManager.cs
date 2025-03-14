using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkillManager : MonoBehaviour
{
    //���� �÷��̾ ������ �ִ� ��ų ����, ����, ��ų ��ȭ, ��ų ����, ��ų ���� ã�⸦ ����
    public static cSkillManager instance;

    Dictionary<string, int> skillID = new Dictionary<string, int>();

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void RegisterSkill(string name)
    {
        if (!skillID.ContainsKey(name))
            skillID.Add(name, 0);
        else if (skillID.ContainsKey(name))
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
            Debug.LogError("cSkillManager - ������ ���� ���� ��ų�Դϴ�.");
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
