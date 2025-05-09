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
        if (ErrorPopUp() == false)
            return;

        playerStats.StrengthUp();
        statsView.UpdateStat("Str", playerStats.getStrLevel, playerStats.strengthIncrease, playerStats.nextStr);
    }
    public void OnCriChanceUp()
    {
        if (ErrorPopUp() == false)
            return;

        playerStats.CriChanceUp();
        statsView.UpdateStat("CriChance", playerStats.getCriChanceLevel, playerStats.criChanceIncrease, playerStats.nextCriChance);
    }
    public void OnCriDamageUp()
    {
        if (ErrorPopUp() == false)
            return;

        playerStats.CriDamageUp();
        statsView.UpdateStat("CriDamage", playerStats.getCriDamageLevel, playerStats.criDamageIncrease, playerStats.nextCriDamage);
    }
    public void OnGoldAcquireUp()
    {
        if (ErrorPopUp() == false)
            return;

        playerStats.GoldAcquireUp();
        statsView.UpdateStat("GoldAcq", playerStats.getGoldAcqLevel, playerStats.goldAcqIncrease, playerStats.nextGoldAcq);
    }
    public void OnExpAcquireUp()
    {
        if (ErrorPopUp() == false)
            return;

        playerStats.ExpAcquireUp();
        statsView.UpdateStat("ExpAcq", playerStats.getExpAcqLevel, playerStats.expAcqIncrease, playerStats.nextExpAcq);
    }

    #endregion

    #region Charator_Stats_Up

    public void OnCharStrengthUp()
    {
        if (ErrorPopUp() == false)
            return;

        playerStats.Character_StrengthUp();
        statsView.UpdateCharStat("Str", playerStats.getCharStrLevel, playerStats.charStrRate, playerStats.nextCharStr);
    }
    public void OnCharCriChanceUp()
    {
        if (ErrorPopUp() == false)
            return;

        playerStats.Character_CriChanceUp();
        statsView.UpdateCharStat("CriChance", playerStats.getCharCriChanceLevel, playerStats.charCriChanceRate, playerStats.nextCharCriChance);
    }
    public void OnCharCriDamageUp()
    {
        if (ErrorPopUp() == false)
            return;

        playerStats.Character_CriDamageUp();
        statsView.UpdateCharStat("CriDamage", playerStats.getCharCriDamageLevel, playerStats.charCriDamageRate, playerStats.nextCharCriDamage);
    }
    public void OnCharGoldAcqUp()
    {
        if (ErrorPopUp() == false)
            return;

        playerStats.Character_GoldAcqUp();
        statsView.UpdateCharStat("GoldAcq", playerStats.getCharGoldAcqLevel, playerStats.charGoldAcqRate, playerStats.nextCharGoldAcq);
    }
    public void OnCharExpAcqUp()
    {
        if (ErrorPopUp() == false)
            return;

        playerStats.Character_ExpAcqUp();
        statsView.UpdateCharStat("ExpAcq", playerStats.getCharExpAcqLevel, playerStats.charExpAcqRate, playerStats.nextCharExpAcq);
    }

    #endregion

    bool ErrorPopUp()
    {
        bool isSpend = statsView.IsSpend();

        if (isSpend == false)
            cPopupManager.instance.Push("ErrorPopup", "골드가 부족합니다.");

        return isSpend;
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
