using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkill3State : IState
{
    // 보스가 타겟을 고정시킨다.
    // 타겟이 고정되었다면 보스는 공격 준비를하고
    // 플레이어에게 타켓 ui가 나타난다.
    // 이 때 보스는 플레이어의 왼쪽 오른쪽을 구분하여 filpX를 시켜준다.

    // 몇 초 뒤 보스는 검기 공격을 한다.
    // 플레이어는 보스에게 최대한 멀리 떨어져 자신에게 빠르게 다가오는 검기를 피해야한다.
    cBoss boss;
    
    public cSkill3State(cBoss boss) { this.boss = boss; }
    
    public void Enter()
    {
        Debug.Log("Skill3 Enter");
        boss.StateMachine.TransitionTo(boss.StateMachine.groggyState);
    }
}
