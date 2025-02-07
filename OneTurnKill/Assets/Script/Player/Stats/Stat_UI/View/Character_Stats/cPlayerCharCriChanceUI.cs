using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cPlayerCharCriChanceUI : cPlayerStatsUI
{
    protected override void StatUp()
    {
        present.OnCharCriChanceUp();
    }
}
