using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cItem : MonoBehaviour
{
    public enum ITEMTYPE { Coin, Materials, Helmet, Armor, Weapon }
    //public enum HELMET { None, Helmet2 = 1, Helmet8 = 7, Helmet9 }
    //public enum ARMOR { None, Armor3 = 2, Armor8 = 7 }
    //public enum WEAPON { None, weapon1 = 5, Weapon2= 6, Weapon5 = 9 }

    public ITEMTYPE type;

    public int index;

    //public HELMET helmet;
    //public ARMOR armor;
    //public WEAPON weapon;

    Rigidbody2D rigid;

    float originY = 0f;
    bool isPickUp = false;
    bool isGround = false;

    float thorowPower = 5f;
    float itemMoveSpeed = 20f;
    float yRockTime = 0.5f;

    static Vector2 coinUIVec = new Vector2(8.4f, 4.4f);
    static Vector2 equipUIVec = new Vector2(-6.5f, -3.9f);

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
            switch (type)
            {
                case ITEMTYPE.Coin:
                    this.transform.position = Vector2.MoveTowards(this.transform.position, coinUIVec, Time.deltaTime * itemMoveSpeed);
                    break;
                case ITEMTYPE.Materials:
                case ITEMTYPE.Helmet:
                case ITEMTYPE.Armor:
                case ITEMTYPE.Weapon:
                    this.transform.position = Vector2.MoveTowards(this.transform.position, equipUIVec, Time.deltaTime * itemMoveSpeed);
                    break;
            }
        }
    }
}
