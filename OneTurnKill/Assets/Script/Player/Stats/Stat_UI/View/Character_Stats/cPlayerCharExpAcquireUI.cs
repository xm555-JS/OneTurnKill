using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cPlayerCharExpAcquireUI : cPlayerStatsUI
{
    protected override void StatUp()
    {
        present.OnCharExpAcqUp();
    }
}
