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
            case "����":
                AudioManager.instance.PlayerSKill(AudioManager.Skill.HORIZONTAL);
                break;
            case "����Ʈ":
                AudioManager.instance.PlayerSKill(AudioManager.Skill.IMPACT);
                break;
            case "�Ŀ� ��":
                AudioManager.instance.PlayerSKill(AudioManager.Skill.POWERSHOT);
                break;
            case "��Ʈ����ũ":
                AudioManager.instance.PlayerSKill(AudioManager.Skill.SWING);
                break;
            case "�ڸ�":
                AudioManager.instance.PlayerSKill(AudioManager.Skill.COMET, 0.7f);    // 0.3 ���� ������
                break;
            case "�ǴϽ�":
                AudioManager.instance.PlayerSKill(AudioManager.Skill.FINISH);
                break;
            case "��ũ":
                AudioManager.instance.PlayerSKill(AudioManager.Skill.SHOCK);
                break;
            case "��Ÿ":
                AudioManager.instance.RepeatPlayerSkill(AudioManager.Skill.STAR, 5, 0.2f);
                break;
            case "������Ʈ":
                AudioManager.instance.RepeatPlayerSkill(AudioManager.Skill.JUDGEMENT, 3, 0.1f);
                break;
            case "���׿�":
                AudioManager.instance.PlayerSKill(AudioManager.Skill.METEOR, 0.8f);
                break;
        }
    }
}
