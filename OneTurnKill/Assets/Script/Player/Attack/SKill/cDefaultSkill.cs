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
    }

    protected override void PlaySound(SkillData skillData)
    {
        //Debug.Log("Base ���� ����");
    }

    //IEnumerator ToggleEffect(SkillData skillData)
    //{
    //    GameObject effectObj = GameObject.Instantiate(skillData.skillEffect);
    //    yield return new WaitForSeconds(0.3f);
    //    effectObj.SetActive(false);
    //}
}
