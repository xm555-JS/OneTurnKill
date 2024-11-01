using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cDefaultMonster : cMonster
{
    void FixedUpdate()
    {
        if (!isArrive)
        {
            Vector2 moveVec = player.transform.position - this.transform.position;
            rigid.MovePosition(rigid.position + moveVec.normalized * Time.deltaTime);
        }
    }
}
