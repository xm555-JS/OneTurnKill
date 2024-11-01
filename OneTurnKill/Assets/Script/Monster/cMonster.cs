using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0108

public class cMonster : MonoBehaviour
{
    [SerializeField] protected float hp;
    [SerializeField] protected float defence;

    protected Rigidbody2D rigid;
    protected Animator anim;
    protected SpriteRenderer renderer;

    protected GameObject player;

    protected bool isArrive;

    void Awake()
    {
        //anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
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
        hp -= 1000;

        Reaction();

        if (hp <= 0)
            Debug.Log("Á×À½");
    }

    void Reaction()
    {
        // ¸ó½ºÅÍÀÇ renderer¸¦ »¡°²°Ô
        StartCoroutine(ChangeRenderer());
    }

    IEnumerator ChangeRenderer()
    {
        renderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        renderer.color = Color.yellow;
    }
}
