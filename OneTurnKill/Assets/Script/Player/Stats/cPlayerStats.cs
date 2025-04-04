using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0414

public class cPlayerStats : MonoBehaviour
{
    #region Stats

    public int strength { get; private set; }
    public int bossStrength { get; private set; }
    public int criticalChance { get; private set; }
    public int criticalDamage { get; private set; }
    public int goldAcquire { get; private set; }
    public int expAcquire { get; private set; }

    int hpLevel, strLevel, defenLevel, criChanceLevel, criDamageLevel, goldAcqLevel, expAcqLevel;

    public int strengthIncrease { get; private set; }
    public int criChanceIncrease { get; private set; }
    public int criDamageIncrease { get; private set; }
    public int goldAcqIncrease { get; private set; }
    public int expAcqIncrease { get; private set; }

    static int increaseAmount = 10;

    #endregion

    #region Level

    public int getStrLevel { get => strLevel; }
    public int getCriChanceLevel { get => criChanceLevel; }
    public int getCriDamageLevel { get => criDamageLevel; }
    public int getGoldAcqLevel { get => goldAcqLevel; }
    public int getExpAcqLevel { get => expAcqLevel; }

    #endregion

    #region Next_Stats

    public int nextStr { get => strengthIncrease + increaseAmount; }
    public int nextCriChance { get => criChanceIncrease + increaseAmount; }
    public int nextCriDamage { get => criDamageIncrease + increaseAmount; }
    public int nextGoldAcq { get => goldAcqIncrease + increaseAmount; }
    public int nextExpAcq { get => expAcqIncrease + increaseAmount; }
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

    public int charStrIncrease { get; private set; }
    public int charCriChanceIncrease { get; private set; }
    public int charCriDamageIncrease { get; private set; }
    public int charGoldAcqIncrease { get; private set; }
    public int charExpAcqIncrease { get; private set; }

    static int increaseCharAmoun = 2;

    #endregion

    #region Character_Stats_Level

    public int getCharStrLevel { get => charStrLevel; }
    public int getCharCriChanceLevel { get => charCriChanceLevel; }
    public int getCharCriDamageLevel { get => charCriDamageLevel; }
    public int getCharGoldAcqLevel { get => charGoldAcqLevel; }
    public int getCharExpAcqLevel { get => charExpAcqLevel; }

    #endregion

    #region Next_Char_Stats

    public int nextCharStr { get => charStrIncrease + increaseCharAmoun; }
    public int nextCharCriChance { get => charCriChanceIncrease + increaseCharAmoun; }
    public int nextCharCriDamage { get => charCriDamageIncrease + increaseCharAmoun; }
    public int nextCharGoldAcq { get => charGoldAcqIncrease + increaseCharAmoun; }
    public int nextCharExpAcq { get => charExpAcqIncrease + increaseCharAmoun; }

    #endregion

    #region Character_Stats_Up

    public void Character_StrengthUp()
    {
        charStrLevel++;
        charStrIncrease += increaseCharAmoun;
        strength += (strength / charStrIncrease);
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

    #region Equip_Item

    cItemInstance hemelStats;
    cItemInstance armorStats;
    cItemInstance weaponStats;

    // ¾ÆÀÌÅÛ ÀåÂø
    void WearEquip(cItemInstance itemData)
    {
        // ÀåÂøÁßÀÎ ¾ÆÀÌÅÛ Á¦°Å
        switch (itemData.type)
        {
            case ItemType.HELMET:
                hemelStats = null;
                break;

            case ItemType.ARMOR:
                armorStats = null;
                break;

            case ItemType.WEAPON:
                weaponStats = null;
                break;
        }

        // ÀåÂøÁßÀÎ ¾ÆÀÌÅÛ ½ºÅÈ Á¦°Å

        // ¾ÆÀÌÅÛ ÀåÂø
        switch (itemData.type)
        {
            case ItemType.HELMET:
                hemelStats = itemData;
                break;

            case ItemType.ARMOR:
                armorStats = itemData;
                break;

            case ItemType.WEAPON:
                weaponStats = itemData;
                break;
        }
    }

    // ¾ÆÀÌÅÛ ÇØÁ¦
    void RemoveEquip()
    {

    }

    // ½ºÅÈ +
    void UpdateEquipStats()
    {

    }

    // ½ºÅÈ -
    void RemoveEquipStats()
    {

    }

    #endregion

    void Awake()
    {
        InitializeStats();
    }

    void InitializeStats()
    {
        strength = 10;
        criticalChance = 10;
        criticalDamage = 10;
        goldAcquire = 0;
        expAcquire = 0;
    }
}
