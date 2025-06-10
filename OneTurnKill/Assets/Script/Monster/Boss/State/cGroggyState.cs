using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cGroggyState : IState
{
    cBoss boss;
    GameObject bossHpObj;

    public cGroggyState(cBoss boss) { this.boss = boss; }

    public void Enter()
    {
        Debug.Log("cGroggyState - �׷α� ����");

        bossHpObj = boss.bossHpObj;
        bossHpObj.SetActive(true);
        BossStageManager.instance.ReadyAttack();
    }
}
