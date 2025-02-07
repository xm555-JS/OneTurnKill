using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cPlayerCharGoldAcquireUI : cPlayerStatsUI
{
    protected override void StatUp()
    {
        present.OnCharGoldAcqUp();
    }
}
