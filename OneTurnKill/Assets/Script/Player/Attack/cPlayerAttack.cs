using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cPlayerAttack : MonoBehaviour
{
    Animator anim;
    SkillDataManager dataManager;
    cDefaultSkill skill = null;

    public event Action OnAttack;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        Scene scene = SceneManager.GetSceneByName("1SampleScene");
        if (scene.name == "1SampleScene")
            dataManager = GameObject.FindWithTag("SkillData").GetComponent<SkillDataManager>();
    }

    void Setskill()
    {
        skill = new cDefaultSkill();
        skill.SetAnim(anim);
        skill.SetTransform(this.transform);
    }

    public void Attack(string skillName)
    {
        SkillData skillData = dataManager.GetSkillData(skillName);
        if (skillData == null)
            return;

        Setskill();
        if (skill == null)
            Debug.LogError("cPlayerAttack - skill is null");
        skill.Execution(skillData);
        OnAttack?.Invoke();
    }
}