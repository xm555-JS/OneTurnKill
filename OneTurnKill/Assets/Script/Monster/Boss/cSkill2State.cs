using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkill2State : IState
{
    cBoss boss;

    public cSkill2State(cBoss boss) { this.boss = boss; }

    public void Enter()
    {
        Debug.Log("Skill2 Enter");
        boss.StateMachine.TransitionTo(boss.StateMachine.skill3State);
    }
}
