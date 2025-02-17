using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cCoinArea : cItemArea
{
    protected override void GetItem(Collider2D collision)
    {
        player.AddCoin(1000f);
    }
}
