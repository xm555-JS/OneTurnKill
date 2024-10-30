using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cPlayerAttack
{
    IPlayerAttack skill;

    void Setskill(string skillName)
    {
        switch (skillName)
        {
            case "Base":
                this.skill = new cSkill1();
                break;
        }
    }

    public void Attack(string skillName)
    {
        Setskill(skillName);
        skill.Execution(skillName);
    }
}