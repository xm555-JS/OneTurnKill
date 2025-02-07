using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cPlayerStatsPresent
{
    cPlayerStats playerStats;
    cPlayerStatsUI statsView;

    public cPlayerStatsPresent(cPlayerStatsUI view, cPlayerStats stats)
    {
        statsView = view;
        playerStats = stats;
    }

    public void OnHpUp()
    {
        playerStats.HpUp();
        statsView.UpdateStat(playerStats.getHp, playerStats.maxHp, playerStats.nextHp);
    }
    public void OnStrengthUp()
    {
        playerStats.StrengthUp();
        statsView.UpdateStat(playerStats.getStr, playerStats.strength, playerStats.nextStr);
    }
    public void OnDefenseUp()
    {
        playerStats.DefenseUp();
        statsView.UpdateStat(playerStats.getDefen, playerStats.defense, playerStats.nextDefen);
    }
}

//cPlayerHpUI hpView;
//cPlayerStrUI strView;
//cPlayerDefenseUI defenseView;

//public cPlayerStatsPresent(cPlayerHpUI view, cPlayerStats stats)
//{
//    hpView = view;
//    playerStats = stats;
//}

//public cPlayerStatsPresent(cPlayerStrUI view, cPlayerStats stats)
//{
//    strView = view;
//    playerStats = stats;
//}

//public cPlayerStatsPresent(cPlayerDefenseUI view, cPlayerStats stats)
//{
//    defenseView = view;
//    playerStats = stats;
//}
