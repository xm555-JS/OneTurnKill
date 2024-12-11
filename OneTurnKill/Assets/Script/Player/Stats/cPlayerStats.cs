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

    float hpIncrease, strengthIncrease, defenseIncrease;
    static float IncreaseAmount = 100;

    #region Next_Stats
    public float nextHp { get => maxHp + hpIncrease + IncreaseAmount; }
    public float nextStr { get => strength + hpIncrease + IncreaseAmount; }
    public float nextDefen { get => defense + hpIncrease + IncreaseAmount; }
    #endregion

    #region Stat_Up

    public void HpUp()
    {
        hpIncrease += IncreaseAmount;
        maxHp += hpIncrease;
        Debug.Log("MaxHP : " + maxHp);
    }

    public void StrengthUp()
    {
        strengthIncrease += IncreaseAmount;
        strength += strengthIncrease;
        Debug.Log("Strength : " + strength);
    }

    public void DefenseUp()
    {
        defenseIncrease += IncreaseAmount;
        defense += defenseIncrease;
        Debug.Log("Defense : " + defense);
    }

    #endregion

    #region Stat_Down
    public void HpDown(float damage) { hp -= damage; }
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
