using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cBoss : cMonster
{
    cStateMachine stateMachine;
    float speed = 5f;

    public cStateMachine StateMachine { get => stateMachine; }

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
