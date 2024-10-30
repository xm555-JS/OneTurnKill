using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkill1 : cSkillBase, IPlayerAttack
{
    // 세부 기능
    public void Execution(string skillName)
    {
        Debug.Log(skillName);
        Debug.Log("Skill 1 실행!");
    }
}
