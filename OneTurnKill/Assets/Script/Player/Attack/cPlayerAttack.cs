using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cPlayerAttack : MonoBehaviour
{
    SkillDataManager dataManager;
    Animator anim;
    IPlayerAttack skill;

    public event Action OnAttack;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        Scene gamePlayScene = SceneManager.GetSceneByName("SampleScene");
        if (gamePlayScene.name == "SampleScene")
            dataManager = GameObject.FindWithTag("SkillData").GetComponent<SkillDataManager>();
    }

    void Setskill()
    {
        cDefaultSkill baseskill = new cDefaultSkill();

        baseskill.SetAnim(anim);
        baseskill.SetTransform(this.transform);
        this.skill = baseskill;
    }

    public void Attack(string skillName)
    {
        SkillData skillData = dataManager.GetSkillData(skillName);
        Setskill();
        skill.Execution(skillData);
        OnAttack?.Invoke();
    }
}