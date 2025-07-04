using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkill2State : IState
{
    public cSkill2State(cBoss boss) { this.boss = boss; }

    cBoss boss;

    GameObject[] attackArea;
    List<GameObject> areaList = new List<GameObject>();

    Coroutine skill2Coroution;


    public void Enter()
    {
        Debug.Log("cSkill2State - 두 번째 스킬 공격 상태");

        this.attackArea = boss.attackArea;

        foreach (var area in attackArea)
            areaList.Add(area);

        skill2Coroution = boss.StartCoroutine(Attack());
    }

    public void Exit()
    {
        if (skill2Coroution != null)
            boss.StopCoroutine(skill2Coroution);
    }

    IEnumerator Attack()
    {
        while (areaList.Count > 0)
        {
            if (boss.StateMachine == null || boss.isDead)
                break;

            int indexNum = Random.Range(0, areaList.Count);
            areaList[indexNum].GetComponent<cBossAreaAttack>().AttackStart();
            areaList.RemoveAt(indexNum);

            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(3f);

        if (boss.isDead == false)
            boss.StateMachine.TransitionTo(boss.StateMachine.skill3State);
    }
}
