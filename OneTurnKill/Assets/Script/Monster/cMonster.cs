using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

#pragma warning disable 0108

[RequireComponent(typeof(cDropItem))]
public class cMonster : MonoBehaviour
{
    public event Action OnDead;
    public event EventHandler<float> OnDamage;

    [SerializeField] protected float maxHP;
    [SerializeField] protected float defence;
    float hp;

    protected Rigidbody2D rigid;
    protected Animator anim;
    //protected SpriteRenderer renderer;

    // test
    float originColrR;
    float originColrG;
    float originColrB;
    // test

    protected GameObject player;

    protected bool isArrive;

    WaitForSeconds takeDamageTime = new WaitForSeconds(0.5f);

    // hp
    GameObject hpBarPrefab;
    GameObject hpBar;

    // test
    IObjectPool<GameObject> objectPool;
    public IObjectPool<GameObject> ObjectPool { get => objectPool; set => objectPool = value; }
    // test

    //Drop_Item
    cDropItem dropItem;

    [SerializeField] protected GameObject[] dropItemObj;
    [SerializeField] protected float[] dropItemProbs;

    public bool IsArrive { get => isArrive; }
    public float MaxHP { get => maxHP; }
    public float CurrentHP { get => hp; }

    void Awake()
    {
        hp = maxHP;
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        //renderer = GetComponent<SpriteRenderer>();

        ////test
        //originColrR = renderer.color.r;
        //originColrG = renderer.color.g;
        //originColrB = renderer.color.b;

        player = GameObject.FindWithTag("Player");

        // Drop_Item
        dropItem = GetComponent<cDropItem>();
    }

    void OnEnable()
    {
        hp = maxHP;
        if (hpBar)
        {
            HpBar hpUI = hpBar.GetComponent<HpBar>();
            hpUI.Initialize();
        }
        isArrive = false;
        //renderer.color = new Color(originColrR, originColrG, originColrB);
    }

    void Start()
    {
        HpBarInitialize();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Skill"))
            TakeDamage(collision);

        if (collision.gameObject.CompareTag("Area"))
            isArrive = true;
    }

    void TakeDamage(Collider2D collision)
    {
        //hp -= collision.gameObject.GetComponent<cDamage>();

        //Reaction();

        //if (hp <= 0)
        //    anim.SetTrigger("Dead");


        /*test code*/
        StartCoroutine(OnTakeDamage());
    }

    IEnumerator OnTakeDamage()
    {
        yield return takeDamageTime;

        // test code 데미지 방식을 적용시킬 것.
        hp -= 200;

        OnDamage?.Invoke(this, hp);
        Reaction();

        if (hp <= 0)
        {
            anim.SetTrigger("Die");

            yield return new WaitForSeconds(0.1f);
            Time.timeScale = 0.2f;

            yield return new WaitForSeconds(0.1f);
            Time.timeScale = 1f;

            yield return new WaitForSeconds(1f);
            objectPool.Release(this.gameObject);
            OnDead?.Invoke();

            // drop item
            GameObject item = dropItemObj[(int)dropItem.Drop_Item(dropItemProbs)];

            if (item != null)
            {
                GameObject instItem = Instantiate(item);
                instItem.transform.position = this.transform.position;
            }
        }
    }

    IEnumerator Dead()
    {
        anim.SetTrigger("Dead");
        Debug.Log("잘 들어오니?");
        yield return new WaitForSeconds(1f);

        objectPool.Release(this.gameObject);
        OnDead?.Invoke();
    }

    void Reaction()
    {
        // 몬스터의 renderer를 빨갛게
        StartCoroutine(ChangeRenderer());
    }

    IEnumerator ChangeRenderer()
    {
        //renderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        //renderer.color = new Color(originColrR, originColrG, originColrB);
        ///* renderer.color = Color.white; /*나중에 sprite 생기면 이걸로 변경*/
    }

    void HpBarInitialize()
    {
        hpBarPrefab = Resources.Load<GameObject>("UI/HPBar");
        hpBar = Instantiate(hpBarPrefab);

        Transform parent = GameObject.FindWithTag("MonsterHpBar").transform;
        hpBar.transform.SetParent(parent);

        HpBar hpUI = hpBar.GetComponent<HpBar>();
        hpUI.Initialize(this);
    }
}
