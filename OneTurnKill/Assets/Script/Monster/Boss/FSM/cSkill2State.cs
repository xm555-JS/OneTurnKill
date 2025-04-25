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
        Debug.Log("2 시작");
        this.attackArea = boss.attackArea;

        foreach (var area in attackArea)
        {
            areaList.Add(area);
        }
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
            Debug.Log("Attack 시작");
            int indexNum = Random.Range(0, areaList.Count);
            areaList[indexNum].GetComponent<cBossAreaAttack>().AttackStart();
            areaList.RemoveAt(indexNum);

            yield return new WaitForSeconds(0.5f);
        }

        boss.StateMachine.TransitionTo(boss.StateMachine.skill3State);
    }

    // 22 - 오늘 1보스 스킬
    // 23 - 내일 코드 리펙토링 && 2보스 스킬
    // 24 - 2보스 스킬 리펙토링 && 보스 UI
    // 25 - 스토리
    // 30 - 데이터 저장
    // 5/1 - 음악
}
