using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkill3State : IState
{
    // ������ Ÿ���� ������Ų��.
    // Ÿ���� �����Ǿ��ٸ� ������ ���� �غ��ϰ�
    // �÷��̾�� Ÿ�� ui�� ��Ÿ����.
    // �� �� ������ �÷��̾��� ���� �������� �����Ͽ� filpX�� �����ش�.

    // �� �� �� ������ �˱� ������ �Ѵ�.
    // �÷��̾�� �������� �ִ��� �ָ� ������ �ڽſ��� ������ �ٰ����� �˱⸦ ���ؾ��Ѵ�.
    cBoss boss;
    
    public cSkill3State(cBoss boss) { this.boss = boss; }
    
    public void Enter()
    {
        Debug.Log("Skill3 Enter");
        boss.StateMachine.TransitionTo(boss.StateMachine.groggyState);
    }
}
