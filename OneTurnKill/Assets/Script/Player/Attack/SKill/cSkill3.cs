using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkill3 : cPlayerSkill, IPlayerAttack
{
    // ���� ���
    public void Execution(SkillData skillData)
    {
        Debug.Log("Skill 3 ����!");

        PlayEffect(skillData);
        PlayAnimation(skillData);
        PlaySound(skillData);
    }

    protected override void PlayAnimation(SkillData skillData)
    {
        Debug.Log("Skill 3 �ִϸ��̼� ����");
    }

    protected override void PlayEffect(SkillData skillData)
    {
        Debug.Log("Skill 3 ����Ʈ ����");
    }

    protected override void PlaySound(SkillData skillData)
    {
        Debug.Log("Skill 3 ���� ����");
    }
}
