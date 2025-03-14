using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cItem : MonoBehaviour
{
    public enum ITEMTYPE { Coin, Materials, Helmet, Armor, Weapon }

    public ITEMTYPE type;

    public int index;

    Rigidbody2D rigid;

    float originY = 0f;
    bool isPickUp = false;
    bool isGround = false;

    float thorowPower = 5f;
    float itemMoveSpeed = 20f;
    float yRockTime = 0.5f;

    static Vector2 coinUIVec = new Vector2(6.55f, 4.4f);
    static Vector2 equipUIVec = new Vector2(-5.4f, -4.1f);

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        originY = transform.position.y - 0.5f;
        ThrowItem();
    }

    void FixedUpdate()
    {
        Y_Rock();
        MovingItem();
    }

    void ThrowItem()
    {
        rigid.AddForce(Vector2.up * thorowPower, ForceMode2D.Impulse);
        Invoke("StartYRock", yRockTime);    // 던진 아이템이 제자리에 올 수 있도록 y축 고정
    }

    void StartYRock()
    {
        isGround = true;
    }

    void Y_Rock()
    {
        if (isGround)
        {
            if (this.transform.position.y < originY && !isPickUp)
            {
                transform.position = new Vector2(transform.position.x, originY);
                rigid.gravityScale = 0f;
                rigid.velocity = Vector2.zero;

                StartCoroutine(PickUp());
            }
        }
    }

    IEnumerator PickUp()
    {
        yield return new WaitForSeconds(1f);

        isPickUp = true;
    }

    void MovingItem()
    {
        if (isPickUp)
        {
            if (type == ITEMTYPE.Coin)
                this.transform.position = Vector2.MoveTowards(this.transform.position, coinUIVec, Time.deltaTime * itemMoveSpeed);
            else
                this.transform.position = Vector2.MoveTowards(this.transform.position, equipUIVec, Time.deltaTime * itemMoveSpeed);


            //switch (type)
            //{
            //    case ITEMTYPE.Coin:
            //        this.transform.position = Vector2.MoveTowards(this.transform.position, coinUIVec, Time.deltaTime * itemMoveSpeed);
            //        break;
            //    case ITEMTYPE.Materials:
            //    case ITEMTYPE.Helmet:
            //    case ITEMTYPE.Armor:
            //    case ITEMTYPE.Weapon:
            //        this.transform.position = Vector2.MoveTowards(this.transform.position, equipUIVec, Time.deltaTime * itemMoveSpeed);
            //        break;
            //}
        }
    }
}
