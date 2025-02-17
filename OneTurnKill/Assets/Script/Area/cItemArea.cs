using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class cItemArea : MonoBehaviour
{
    protected cPlayer player;

    float stayTime = 0f;

    protected abstract void GetItem(Collider2D collision);

    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<cPlayer>();
    }

    //void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Item"))
    //    {
    //        stayTime += Time.deltaTime;

    //        if (stayTime > 0.3f)
    //        {
    //            GetItem(collision);
    //            Destroy(collision.gameObject);
    //            stayTime = 0f;
    //        }
    //    }
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            StartCoroutine(ColliderItem(collision));
        }
    }

    IEnumerator ColliderItem(Collider2D collision)
    {
        yield return new WaitForSeconds(0.3f);

        GetItem(collision);
        Destroy(collision.gameObject);
    }
}
