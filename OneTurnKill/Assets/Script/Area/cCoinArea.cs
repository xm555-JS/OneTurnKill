using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cCoinArea : cItemArea
{
    public Action<float> OnCoinDrop;

    protected override void GetItem(Collider2D collision)
    {
        cItemData data = collision.GetComponent<cItemData>();
        if (data != null)
        {
            float coinValue = data.price;
            OnCoinDrop?.Invoke(coinValue);
        }
    }
}
