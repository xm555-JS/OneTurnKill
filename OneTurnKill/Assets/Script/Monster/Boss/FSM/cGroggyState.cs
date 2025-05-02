using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cGroggyState : IState
{
    cBoss boss;
    GameObject bossHpObj;

    // event
    public event Action OnGroggy;
    public cGroggyState(cBoss boss) { this.boss = boss; }

    public void Enter()
    {
        bossHpObj = boss.bossHpObj;
        bossHpObj.SetActive(true);
        OnGroggy?.Invoke();
    }
}
