using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cCoinArea : cItemArea
{

    protected override void GetItem()
    {
        player.AddCoin(100f);
    }
}
