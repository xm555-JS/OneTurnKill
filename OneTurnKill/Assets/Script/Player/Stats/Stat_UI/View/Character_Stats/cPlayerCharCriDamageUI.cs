using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cPlayerCharCriDamageUI : cPlayerStatsUI
{
    protected override void StatUp()
    {
        present.OnCharCriDamageUp();
    }
}
