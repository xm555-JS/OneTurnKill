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
        Scene gamePlayScene =  SceneManager.GetSceneByName("SampleScene");
        if (gamePlayScene.name == "SampleScene")
            dataManager = GameObject.FindWithTag("SkillData").GetComponent<SkillDataManager>();
    }

    void Setskill(string skillName)
    {
        switch (skillName)
        {
            case "Base":
                cDefaultSkill baseskill = new cDefaultSkill();

                baseskill.SetAnim(anim);
                baseskill.SetTransform(this.transform);
                this.skill = baseskill;
                break;

            case "Skill1":
                cSkill2 skill2 = new cSkill2();

                skill2.SetAnim(anim);
                skill2.SetTransform(this.transform);
                this.skill = skill2;
                break;

            case "Skill2":
                cSkill3 skill3 = new cSkill3();

                skill3.SetAnim(anim);
                skill3.SetTransform(this.transform);
                this.skill = skill3;
                break;
        }
    }

    public void Attack(string skillName)
    {
        SkillData skillData = dataManager.GetSkillData(skillName);
        Setskill(skillName);
        skill.Execution(skillData);
        OnAttack?.Invoke();
    }
}