using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cDefaultSkill : cPlayerSkill, IPlayerAttack
{
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
        GameObject effectObj = GameObject.Instantiate(skillData.skillEffect);
        if (effectObj.GetComponent<cSKillDamage>() == null)
            return;
        effectObj.GetComponent<cSKillDamage>().LevelDamage = skillData.levelDamage[skillData.level];
    }

    protected override void PlaySound(SkillData skillData)
    {
        //Debug.Log("Base 사운드 실행");
    }
}
