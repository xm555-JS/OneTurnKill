using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cPlayerStatsPresent
{
    cPlayerStats playerStats;
    cPlayerStatsUI statsView;
    //cPlayerHpUI hpView;
    //cPlayerStrUI strView;
    //cPlayerDefenseUI defenseView;

    public cPlayerStatsPresent(cPlayerStatsUI view, cPlayerStats stats)
    {
        statsView = view;
        playerStats = stats;
    }

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

    public void OnHpUp()
    {
        playerStats.HpUp();
        statsView.UpdateStat(playerStats.hp);
    }
    public void OnStrengthUp()
    {
        playerStats.StrengthUp();
        statsView.UpdateStat(playerStats.strength);
    }
    public void OnDefenseUp()
    {
        playerStats.DefenseUp();
        statsView.UpdateStat(playerStats.defense);
    }

}
