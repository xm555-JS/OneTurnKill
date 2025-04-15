using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkill3State : IState
{
    cBoss boss;

    public cSkill3State(cBoss boss) { this.boss = boss; }
    
    public void Enter()
    {
        Debug.Log("Skill3 Enter");
        boss.StateMachine.TransitionTo(boss.StateMachine.groggyState);
    }
}
