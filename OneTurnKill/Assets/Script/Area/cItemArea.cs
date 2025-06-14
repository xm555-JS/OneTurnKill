using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class cItemArea : MonoBehaviour
{
    protected abstract void GetItem(Collider2D collision);

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Need To Fix
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
