using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkill2 : cPlayerSkill, IPlayerAttack
{
    // 세부 기능
    public void Execution(SkillData skillData)
    {
        PlayEffect(skillData);
        PlayAnimation(skillData);
        PlaySound(skillData);
    }

    protected override void PlayAnimation(SkillData skillData)
    {
        anim.SetTrigger("Attack");
    }

    protected override void PlayEffect(SkillData skillData)
    {
        GameObject.Instantiate(skillData.skillEffect);
    }

    protected override void PlaySound(SkillData skillData)
    {
        Debug.Log("Skill 2 사운드 실행");
    }
}
