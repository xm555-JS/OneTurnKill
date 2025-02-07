using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cPlayerCharStrUI : cPlayerStatsUI
{
    protected override void StatUp()
    {
        present.OnCharStrengthUp();
    }
}
