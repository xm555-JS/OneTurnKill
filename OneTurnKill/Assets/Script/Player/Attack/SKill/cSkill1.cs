using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkill1 : cSkillBase, IPlayerAttack
{
    // ���� ���
    public void Execution(string skillName)
    {
        Debug.Log(skillName);
        Debug.Log("Skill 1 ����!");
    }
}
