using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0414

public class cPlayerStats : MonoBehaviour
{
    public float maxHp { get; private set; }
    public float hp { get; private set; }
    public float strength { get; private set; }
    public float defense { get; private set; }

    int hpLevel, strLevel, defenLevel;

    int charHpLevel, charStrLevel, charDefenLevel;

    float hpIncrease, strengthIncrease, defenseIncrease;
    static float increaseAmount = 10;

    float charHpIncrease, charStrIncrease, charDefenIncrease;
    static float increaseCharAmoun = 2;

    #region Level

    public int getHp { get => hpLevel; }
    public int getStr { get => strLevel; }
    public int getDefen { get => defenLevel; }

    #endregion

    #region Next_Stats
    public float nextHp { get => maxHp + hpIncrease + increaseAmount; }
    public float nextStr { get => strength + hpIncrease + increaseAmount; }
    public float nextDefen { get => defense + hpIncrease + increaseAmount; }
    #endregion

    #region Stat_Up

    public void HpUp()
    {
        hpLevel++;
        hpIncrease += increaseAmount;
        maxHp += hpIncrease;
        Debug.Log("MaxHP : " + maxHp);
    }

    public void StrengthUp()
    {
        strLevel++;
        strengthIncrease += increaseAmount;
        strength += strengthIncrease;
        Debug.Log("Strength : " + strength);
    }

    public void DefenseUp()
    {
        defenLevel++;
        defenseIncrease += increaseAmount;
        defense += defenseIncrease;
        Debug.Log("Defense : " + defense);
    }

    #endregion

    #region Stat_Down
    public void HpDown(float damage) { hp -= damage; }
    #endregion

    #region Character_Stats_Level

    public int getCharHp { get => charHpLevel; }
    public int getCharStr { get => charStrLevel; }
    public int getCharDefen { get => charDefenLevel; }

    #endregion

    //#region Next_Char_Stats

    //public float nextCharHp { get => maxHp + hpIncrease + increaseAmount; }
    //public float nextCharStr { get => strength + hpIncrease + increaseAmount; }
    //public float nextCharDefen { get => defense + hpIncrease + increaseAmount; }

    //#endregion

    #region Character_Stats_Up

    public void Character_StrengthUp()
    {
        charStrLevel++;
        strengthIncrease += increaseAmount;
        strength += strengthIncrease;
        Debug.Log("Strength : " + strength);
    }

    #endregion

    void Awake()
    {
        InitializeStats();
    }

    void InitializeStats()
    {
        maxHp = 100f;
        hp = maxHp;
        strength = 10f;
        defense = 10f;
    }
}
