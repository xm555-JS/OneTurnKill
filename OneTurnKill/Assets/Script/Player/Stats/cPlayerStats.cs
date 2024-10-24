using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0414

public class cPlayerStats : MonoBehaviour
{
    public float hp { get; private set; }
    public float strength { get; private set; }
    public float defense { get; private set; }

    float hpIncrease, strengthIncrease, defenseIncrease;
    static float IncreaseAmount = 100;

    public float nextHp { get => hp + hpIncrease + IncreaseAmount; }
    public float nextStr { get => strength + hpIncrease + IncreaseAmount; }
    public float nextDefen { get => defense + hpIncrease + IncreaseAmount; }

    public void HpUp()
    {
        hpIncrease += IncreaseAmount;
        hp += hpIncrease;
        Debug.Log("HP : " + hp);
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

    void Awake()
    {
        InitializeStats();
    }

    void InitializeStats()
    {
        hp = 100f;
        strength = 10f;
        defense = 10f;
    }
}
