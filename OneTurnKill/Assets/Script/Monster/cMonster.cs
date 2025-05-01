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

    [SerializeField] bool isBoss;
    [SerializeField] protected float maxHP;
    [SerializeField] protected float defence;
    float hp;

    protected Rigidbody2D rigid;
    protected Animator anim;

    protected GameObject player;

    protected bool isArrive;

    WaitForSeconds takeDamageTime = new WaitForSeconds(0.5f);

    // hp
    public GameObject bossHpObj;
    GameObject hpBarPrefab;
    GameObject hpBar;

    IObjectPool<GameObject> objectPool;
    public IObjectPool<GameObject> ObjectPool { get => objectPool; set => objectPool = value; }

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

        player = GameManager.instance.player;

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
        StartCoroutine(OnTakeDamage(collision));
    }

    IEnumerator OnTakeDamage(Collider2D collision)
    {
        yield return takeDamageTime;

        int damage = CalculateDamage(collision);
        if (damage == -1)
            yield break;

        hp -= damage;
        Debug.Log(damage);

        OnDamage?.Invoke(this, hp);

        if (hp <= 0)
        {
            anim.SetTrigger("Die");

            yield return new WaitForSeconds(0.1f);
            Time.timeScale = 0.2f;

            yield return new WaitForSeconds(0.1f);
            Time.timeScale = 1f;

            yield return new WaitForSeconds(1f);
            if (objectPool != null)
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

    void HpBarInitialize()
    {
        if (isBoss == false)
        {
            hpBarPrefab = Resources.Load<GameObject>("UI/HPBar");
            hpBar = Instantiate(hpBarPrefab);

            Transform parent = GameObject.FindWithTag("MonsterHpBar").transform;
            if (parent == null)
                return;
            hpBar.transform.SetParent(parent);

            HpBar hpUI = hpBar.GetComponent<HpBar>();
            hpUI.Initialize(this);
        }
        else
        {
            HpBar hpUI = bossHpObj.GetComponent<HpBar>();
            hpUI.Initialize(this);
        }
    }

    int CalculateDamage(Collider2D collision)
    {
        // 특성도 적용시켜야함

        cSKillDamage skillDamage = collision.GetComponent<cSKillDamage>();
        if (skillDamage == null)
            return -1;

        int playerStr = GameManager.instance.playerCom.Strength;
        if (IsCritical())
            playerStr += GameManager.instance.playerCom.Strength * (GameManager.instance.playerCom.CriticalDamage / 100);

        int resultDamage = playerStr * (skillDamage.Damage + (skillDamage.Damage * skillDamage.LevelDamage / 100));

        return resultDamage;
    }

    bool IsCritical()
    {
        int value = UnityEngine.Random.Range(1, 100);
        if (GameManager.instance.playerCom.CriticalChance >= value)
            return true;

        return false;
    }
}
