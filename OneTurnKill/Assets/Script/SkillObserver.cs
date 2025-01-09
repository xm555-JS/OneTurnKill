using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillObserver : MonoBehaviour
{
    GameObject skill;
    void Update()
    {
        //skill = GameObject.FindWithTag("Skill");
        //if (skill)
        //    StartCoroutine(destroySkill());
    }

    IEnumerator destroySkill()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(skill);
    }
}
