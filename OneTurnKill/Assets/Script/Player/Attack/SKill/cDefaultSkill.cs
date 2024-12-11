using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cDefaultSkill : cPlayerSkill, IPlayerAttack
{
    public void Execution(SkillData skillData)
    {
        Debug.Log("Base 실행!");

        PlayEffect(skillData);
        PlayAnimation(skillData);
        PlaySound(skillData);
    }

    protected override void PlayAnimation(SkillData skillData)
    {
        Debug.Log("Base 애니메이션 실행");
    }

    protected override void PlayEffect(SkillData skillData)
    {
        Debug.Log("Base 이펙트 실행");
        GameObject effectObj = GameObject.Instantiate(skillData.skillEffect);
    }

    protected override void PlaySound(SkillData skillData)
    {
        Debug.Log("Base 사운드 실행");
    }

    //IEnumerator ToggleEffect(SkillData skillData)
    //{
    //    GameObject effectObj = GameObject.Instantiate(skillData.skillEffect);
    //    yield return new WaitForSeconds(0.3f);
    //    effectObj.SetActive(false);
    //}
}
