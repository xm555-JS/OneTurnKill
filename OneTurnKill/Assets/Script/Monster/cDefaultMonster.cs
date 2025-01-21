using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cDefaultMonster : cMonster
{
    void FixedUpdate()
    {
        if (!isArrive)
        {
            // anim
            anim.SetBool("Run", true);

            // move
            Vector2 moveVec = player.transform.position - this.transform.position;
            rigid.MovePosition(rigid.position + moveVec.normalized * 3f * Time.deltaTime);
        }
        else
            anim.SetBool("Run", false);
    }
}
