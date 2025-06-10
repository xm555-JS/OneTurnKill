using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cStateMachine
{
    public IState CurrenState { get; private set; }

    public cSkill1State skill1State;
    public cSkill2State skill2State;
    public cSkill3State skill3State;
    public cGroggyState groggyState;
    public cNormalState normalState;

    public cStateMachine(cBoss boss)
    {
        this.skill1State = new cSkill1State(boss);
        this.skill2State = new cSkill2State(boss);
        this.skill3State = new cSkill3State(boss);
        this.groggyState = new cGroggyState(boss);
        this.normalState = new cNormalState(boss);
    }

    public void Initialize(IState startingState)
    {
        CurrenState = startingState;
        startingState.Enter();
    }

    public void TransitionTo(IState nextState)
    {
        CurrenState.Exit();
        CurrenState = nextState;
        nextState.Enter();
    }
}
