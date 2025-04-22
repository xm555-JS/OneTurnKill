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
    // 4개의 attackArea에 각각 attack 스크립트를 만들어 컴포넌트로 붙인다.
    // attack 스크립트에는 자기 자신의 alpha값을 특정 값까지 올려주고
    // 특정 값에 도달했으면 공격 이팩트를 나오게한다.
    // 그 때 tag의 값을 다르게 한다. ex) Tag - attackReady -> attack

    // 다 만든 attackArea를 cBoss에서 4개의 배열에 넣는다.
    // cSkill2State에서 4개를 랜덤으로 중복되지 않게 실행하게한다.

    // 다 끝났으면 Exit에서 skill3를 실행하게 한다.

    // 22 - 오늘 1보스 스킬
    // 23 - 내일 코드 리펙토링 && 2보스 스킬
    // 24 - 2보스 스킬 리펙토링 && 보스 UI
    // 25 - 스토리
    // 30 - 데이터 저장
    // 5/1 - 음악
}
