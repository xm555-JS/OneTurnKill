using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cDefaultSkill : cPlayerSkill, IPlayerAttack
{
    public void Execution(SkillData skillData)
    {
        Debug.Log("Base ����!");

        PlayEffect(skillData);
        PlayAnimation(skillData);
        PlaySound(skillData);
    }

    protected override void PlayAnimation(SkillData skillData)
    {
        Debug.Log("Base �ִϸ��̼� ����");
    }

    protected override void PlayEffect(SkillData skillData)
    {
        Debug.Log("Base ����Ʈ ����");
    }

    protected override void PlaySound(SkillData skillData)
    {
        Debug.Log("Base ���� ����");
    }
}
