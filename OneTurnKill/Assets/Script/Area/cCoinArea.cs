using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cCoinArea : cItemArea
{
    public Action<float> OnCoinDrop;

    protected override void GetItem(Collider2D collision)
    {
        cItemData data = collision.GetComponent<cItem>().ItemData;
        if (data != null)
        {
            float coinValue = CalculatePrice(data.price);
            OnCoinDrop?.Invoke(coinValue);
        }
    }

    long CalculatePrice(int price)
    {
        // 특성도 적용시켜야함

        long resultPrice = price + (price * (GameManager.instance.playerCom.GoldAcquire / 100));
        return resultPrice;
    }
}
