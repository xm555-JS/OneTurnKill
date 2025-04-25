using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cBossBullet : MonoBehaviour
{
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigid.velocity = this.transform.right * 5f;
    }
}
