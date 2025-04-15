using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkill1State : IState
{
    cBoss boss;

    public cSkill1State(cBoss boss) { this.boss = boss; }

    public void Enter()
    {
        Debug.Log("Skill1 Enter");
        boss.StateMachine.TransitionTo(boss.StateMachine.skill2State);
    }

    public void Exit()
    {
        Debug.Log("Skill1 Exit");
    }
}
