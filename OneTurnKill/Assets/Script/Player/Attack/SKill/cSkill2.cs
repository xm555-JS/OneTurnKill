using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkill2 : cPlayerSkill, IPlayerAttack
{
    // 세부 기능
    public void Execution(SkillData skillData)
    {
        Debug.Log("Skill 2 실행!");

        PlayEffect(skillData);
        PlayAnimation(skillData);
        PlaySound(skillData);
    }

    protected override void PlayAnimation(SkillData skillData)
    {
        Debug.Log("Skill 2 애니메이션 실행");
    }

    protected override void PlayEffect(SkillData skillData)
    {
        Debug.Log("Skill 2 이펙트 실행");
    }

    protected override void PlaySound(SkillData skillData)
    {
        Debug.Log("Skill 2 사운드 실행");
    }
}
