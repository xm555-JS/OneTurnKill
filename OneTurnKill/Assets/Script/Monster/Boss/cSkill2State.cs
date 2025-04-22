using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkill2State : IState
{
    public cSkill2State(cBoss boss) { this.boss = boss; }

    cBoss boss;
    GameObject[] attackArea;

    public void Enter()
    {
        Debug.Log("Skill2 Enter");

        this.attackArea = boss.attackArea;
        boss.StateMachine.TransitionTo(boss.StateMachine.skill3State);
    }
    // 4���� attackArea�� ���� attack ��ũ��Ʈ�� ����� ������Ʈ�� ���δ�.
    // attack ��ũ��Ʈ���� �ڱ� �ڽ��� alpha���� Ư�� ������ �÷��ְ�
    // Ư�� ���� ���������� ���� ����Ʈ�� �������Ѵ�.
    // �� �� tag�� ���� �ٸ��� �Ѵ�. ex) Tag - attackReady -> attack

    // �� ���� attackArea�� cBoss���� 4���� �迭�� �ִ´�.
    // cSkill2State���� 4���� �������� �ߺ����� �ʰ� �����ϰ��Ѵ�.

    // �� �������� Exit���� skill3�� �����ϰ� �Ѵ�.

    // 22 - ���� 1���� ��ų
    // 23 - ���� �ڵ� �����丵 && 2���� ��ų
    // 24 - 2���� ��ų �����丵 && ���� UI
    // 25 - ���丮
    // 30 - ������ ����
    // 5/1 - ����
}
