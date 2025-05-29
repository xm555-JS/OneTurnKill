using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cBossBullet : MonoBehaviour
{
    Rigidbody2D rigid;
    float time;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= 3f)
            Destroy(this.gameObject);
    }

    void FixedUpdate()
    {
        rigid.velocity = this.transform.right * 10f;
    }
}
