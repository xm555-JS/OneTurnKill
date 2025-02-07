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

    #region Stats_Up

    public void OnStrengthUp()
    {
        playerStats.StrengthUp();
        statsView.UpdateStat("Str", playerStats.getStrLevel, playerStats.strengthIncrease, playerStats.nextStr);
    }
    public void OnCriChanceUp()
    {
        playerStats.CriChanceUp();
        statsView.UpdateStat("CriChance",playerStats.getCriChanceLevel, playerStats.criChanceIncrease, playerStats.nextCriChance);
    }
    public void OnCriDamageUp()
    {
        playerStats.CriDamageUp();
        statsView.UpdateStat("CriDamage",playerStats.getCriDamageLevel, playerStats.criDamageIncrease, playerStats.nextCriDamage);
    }
    public void OnGoldAcquireUp()
    {
        playerStats.GoldAcquireUp();
        statsView.UpdateStat("GoldAcq", playerStats.getGoldAcqLevel, playerStats.goldAcqIncrease, playerStats.nextGoldAcq);
    }
    public void OnExpAcquireUp()
    {
        playerStats.ExpAcquireUp();
        statsView.UpdateStat("ExpAcq", playerStats.getExpAcqLevel, playerStats.expAcqIncrease, playerStats.nextExpAcq);
    }

    #endregion

    #region Charator_Stats_Up

    public void OnCharStrengthUp()
    {
        playerStats.Character_StrengthUp();
        statsView.UpdateCharStat("Str", playerStats.getCharStrLevel, playerStats.charStrIncrease, playerStats.nextCharStr);
    }
    public void OnCharCriChanceUp()
    {
        playerStats.Character_CriChanceUp();
        statsView.UpdateCharStat("CriChance", playerStats.getCharCriChanceLevel, playerStats.charCriChanceIncrease, playerStats.nextCharCriChance);
    }
    public void OnCharCriDamageUp()
    {
        playerStats.Character_CriDamageUp();
        statsView.UpdateCharStat("CriDamage", playerStats.getCharCriDamageLevel, playerStats.charCriDamageIncrease, playerStats.nextCharCriDamage);
    }
    public void OnCharGoldAcqUp()
    {
        playerStats.Character_GoldAcqUp();
        statsView.UpdateCharStat("GoldAcq", playerStats.getCharGoldAcqLevel, playerStats.charGoldAcqIncrease, playerStats.nextCharGoldAcq);
    }
    public void OnCharExpAcqUp()
    {
        playerStats.Character_ExpAcqUp();
        statsView.UpdateCharStat("ExpAcq", playerStats.getCharExpAcqLevel, playerStats.charExpAcqIncrease, playerStats.nextCharExpAcq);
    }

    #endregion
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
