using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cBoss : cMonster
{
    [Header("Skill1")]
    public Transform spawnerTrans;
    public GameObject bossBullet;

    [Header("Skill2")]
    public GameObject[] attackArea;

    [Header("SKill3")]
    public cBossTargetUI targetUI;

    [Header("Info")]
    Vector3 startVec = new Vector3(10f, 0f, 1f);
    float speed = 5f;
    public bool isDead;

    cStateMachine stateMachine;
    public cStateMachine StateMachine { get => stateMachine; }

    void OnEnable()
    {
        this.OnDead += CheckMonsterDead;
    }

    void OnDisable()
    {
        this.OnDead -= CheckMonsterDead;
    }

    void CheckMonsterDead()
    {
        isDead = true;
    }

    public void ToIdle()
    {
        this.StopAllCoroutines();
        stateMachine.Initialize(stateMachine.normalState);
    }

    public void ResetInfo()
    {
        stateMachine = null;
        isArrive = false;
    }

    public void ResetPosition()
    {
        this.transform.position = startVec;
    }

    void FixedUpdate()
    {
        if (isHit)
            return;

        if (!isArrive)
        {
            anim.SetBool("Run", true);
            rigid.MovePosition(rigid.position + Vector2.left.normalized * speed * Time.deltaTime);
        }
        else
        {
            // 도착했다면 상태 변경
            anim.SetBool("Run", false);
            if (stateMachine == null)
            {
                stateMachine = new cStateMachine(this);
                stateMachine.Initialize(stateMachine.skill1State);
            }
        }
    }
}
