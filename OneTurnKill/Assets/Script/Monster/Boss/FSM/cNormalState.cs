using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cNormalState : IState
{
    cBoss boss;
    GameObject bossHpObj;

    public cNormalState(cBoss boss) { this.boss = boss; }

    public void Enter()
    {
    }
}
