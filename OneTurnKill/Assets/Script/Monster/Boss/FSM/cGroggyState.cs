using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cGroggyState : IState
{
    cBoss boss;

    public cGroggyState(cBoss boss) { this.boss = boss; }

    public void Enter()
    {
        Debug.Log("Groggy Enter");
        //boss.StateMachine.TransitionTo(boss.StateMachine.)
    }
}
