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
        if (effectObj.GetComponentInChildren<cSKillDamage>() == null)
            return;
        effectObj.GetComponentInChildren<cSKillDamage>().LevelDamage = skillData.levelDamage[skillData.level];
    }

    protected override void PlaySound(SkillData skillData)
    {
        switch (skillData.skillName)
        {
            case "수평선":
                AudioManager.instance.PlayerSKill(AudioManager.Skill.HORIZONTAL);
                break;
            case "임팩트":
                AudioManager.instance.PlayerSKill(AudioManager.Skill.IMPACT);
                break;
            case "파워 샷":
                AudioManager.instance.PlayerSKill(AudioManager.Skill.POWERSHOT);
                break;
            case "스트라이크":
                AudioManager.instance.PlayerSKill(AudioManager.Skill.SWING);
                break;
            case "코멧":
                AudioManager.instance.PlayerSKill(AudioManager.Skill.COMET, 0.7f);    // 0.3 정도 느리게
                break;
            case "피니쉬":
                AudioManager.instance.PlayerSKill(AudioManager.Skill.FINISH);
                break;
            case "쇼크":
                AudioManager.instance.PlayerSKill(AudioManager.Skill.SHOCK);
                break;
            case "스타":
                AudioManager.instance.RepeatPlayerSkill(AudioManager.Skill.STAR, 5, 0.2f);
                break;
            case "저지먼트":
                AudioManager.instance.RepeatPlayerSkill(AudioManager.Skill.JUDGEMENT, 3, 0.1f);
                break;
            case "메테오":
                AudioManager.instance.PlayerSKill(AudioManager.Skill.METEOR, 0.8f);
                break;
        }
    }
}
