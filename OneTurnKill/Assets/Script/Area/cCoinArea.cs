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
            float coinValue = CalculatePrice(data.price);
            OnCoinDrop?.Invoke(coinValue);
        }
    }

    int CalculatePrice(int price)
    {
        // 특성도 적용시켜야함

        int resultPrice = price + (price * (GameManager.instance.playerCom.GoldAcquire / 100));
        return resultPrice;
    }
}
