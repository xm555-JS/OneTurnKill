using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0414

public class cPlayerStats : MonoBehaviour
{
    #region Stats

    public float strength { get; private set; }
    public float criticalChance { get; private set; }
    public float criticalDamage { get; private set; }
    public float goldAcquire { get; private set; }
    public float expAcquire { get; private set; }

    int hpLevel, strLevel, defenLevel, criChanceLevel, criDamageLevel, goldAcqLevel, expAcqLevel;

    public float strengthIncrease { get; private set; }
    public float criChanceIncrease { get; private set; }
    public float criDamageIncrease { get; private set; }
    public float goldAcqIncrease { get; private set; }
    public float expAcqIncrease { get; private set; }

    static float increaseAmount = 10;

    #endregion

    #region Level

    public int getStrLevel { get => strLevel; }
    public int getCriChanceLevel { get => criChanceLevel; }
    public int getCriDamageLevel { get => criDamageLevel; }
    public int getGoldAcqLevel { get => goldAcqLevel; }
    public int getExpAcqLevel { get => expAcqLevel; }

    #endregion

    #region Next_Stats

    public float nextStr { get => strengthIncrease + increaseAmount; }
    public float nextCriChance { get => criChanceIncrease + increaseAmount; }
    public float nextCriDamage { get => criDamageIncrease + increaseAmount; }
    public float nextGoldAcq { get => goldAcqIncrease + increaseAmount; }
    public float nextExpAcq { get => expAcqIncrease + increaseAmount; }
    #endregion

    #region Stat_Up

    public void StrengthUp()
    {
        strLevel++;
        strengthIncrease += increaseAmount;
        strength += strengthIncrease;
        Debug.Log("Strength : " + strength);
    }

    public void CriChanceUp()
    {
        criChanceLevel++;
        criChanceIncrease += increaseAmount;
        criticalChance += criChanceIncrease;
        Debug.Log("CriticalChance : " + criticalChance);
    }

    public void CriDamageUp()
    {
        criDamageLevel++;
        criDamageIncrease += increaseAmount;
        criticalDamage += criDamageIncrease;
        Debug.Log("CriticalDamage : " + criticalDamage);
    }

    public void GoldAcquireUp()
    {
        goldAcqLevel++;
        goldAcqIncrease += increaseAmount;
        goldAcquire += goldAcqIncrease;
        Debug.Log("GoldAcquire : " + goldAcquire);
    }

    public void ExpAcquireUp()
    {
        expAcqLevel++;
        expAcqIncrease += increaseAmount;
        expAcquire += expAcqIncrease;
        Debug.Log("ExpAcquire : " + expAcquire);
    }

    #endregion

    #region Character_Stats

    int charStrLevel, charCriChanceLevel, charCriDamageLevel, charGoldAcqLevel, charExpAcqLevel;

    public float charStrIncrease { get; private set; }
    public float charCriChanceIncrease { get; private set; }
    public float charCriDamageIncrease { get; private set; }
    public float charGoldAcqIncrease { get; private set; }
    public float charExpAcqIncrease { get; private set; }

    static float increaseCharAmoun = 2;

    #endregion

    #region Character_Stats_Level

    public int getCharStrLevel { get => charStrLevel; }
    public int getCharCriChanceLevel { get => charCriChanceLevel; }
    public int getCharCriDamageLevel { get => charCriDamageLevel; }
    public int getCharGoldAcqLevel { get => charGoldAcqLevel; }
    public int getCharExpAcqLevel { get => charExpAcqLevel; }

    #endregion

    #region Next_Char_Stats

    public float nextCharStr { get => charStrIncrease + increaseCharAmoun; }
    public float nextCharCriChance { get => charCriChanceIncrease + increaseCharAmoun; }
    public float nextCharCriDamage { get => charCriDamageIncrease + increaseCharAmoun; }
    public float nextCharGoldAcq { get => charGoldAcqIncrease + increaseCharAmoun; }
    public float nextCharExpAcq { get => charExpAcqIncrease + increaseCharAmoun; }

    #endregion

    #region Character_Stats_Up

    public void Character_StrengthUp()
    {
        charStrLevel++;
        charStrIncrease += increaseCharAmoun;
        strength += (strength / charStrIncrease) ;
        Debug.Log("Strength : " + strength);
    }

    public void Character_CriChanceUp()
    {
        charCriChanceLevel++;
        charCriChanceIncrease += increaseCharAmoun;
        criticalChance += (criticalChance / charCriChanceIncrease);
        Debug.Log("CriticalChance : " + criticalChance);
    }

    public void Character_CriDamageUp()
    {
        charCriDamageLevel++;
        charCriDamageIncrease += increaseCharAmoun;
        criticalDamage += (criticalDamage / charCriDamageIncrease);
        Debug.Log("CriticalDamage : " + criticalDamage);
    }

    public void Character_GoldAcqUp()
    {
        charGoldAcqLevel++;
        charGoldAcqIncrease += increaseCharAmoun;
        goldAcquire += (goldAcquire / charGoldAcqIncrease);
        Debug.Log("GoldAcquire : " + goldAcquire);
    }

    public void Character_ExpAcqUp()
    {
        charExpAcqLevel++;
        charExpAcqIncrease += increaseCharAmoun;
        expAcquire += (expAcquire / charExpAcqIncrease);
        Debug.Log("ExpAcquire : " + expAcquire);
    }

    #endregion

    void Awake()
    {
        InitializeStats();
    }

    void InitializeStats()
    {
        strength = 10f;
        criticalChance = 10;
        criticalDamage = 10;
        goldAcquire = 0;
        expAcquire = 0;
    }
}
