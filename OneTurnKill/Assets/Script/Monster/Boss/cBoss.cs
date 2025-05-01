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
        stateMachine.Initialize(stateMachine.groggyState);
        //bossHpObj.SetActive(false);
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
        if (!isArrive)
        {
            // anim
            anim.SetBool("Run", true);

            // move
            Vector2 moveVec = player.transform.position - this.transform.position;
            rigid.MovePosition(rigid.position + moveVec.normalized * speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("Run", false);
            if (stateMachine == null)
            {
                stateMachine = new cStateMachine(this);
                stateMachine.Initialize(stateMachine.skill1State);
            }
        }
    }
}
