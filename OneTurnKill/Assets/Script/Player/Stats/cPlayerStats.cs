using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0414

public class cPlayerStats : MonoBehaviour
{
    #region Stats

    public long strength { get; private set; }
    public int bossStrength { get; private set; }
    public long criticalChance { get; private set; }
    public long criticalDamage { get; private set; }
    public long goldAcquire { get; private set; }
    public long expAcquire { get; private set; }

    int hpLevel, strLevel, criChanceLevel, criDamageLevel, goldAcqLevel, expAcqLevel;

    public int strengthIncrease { get; private set; }
    public int criChanceIncrease { get; private set; }
    public int criDamageIncrease { get; private set; }
    public int goldAcqIncrease { get; private set; }
    public int expAcqIncrease { get; private set; }

    static int increaseAmount = 10;

    #endregion

    #region PureStats

    long pureAtt;
    int pureBossAtt;
    long pureCriChance;
    long pureCriDamage;

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
        strength += (long)strengthIncrease;

        pureAtt += strengthIncrease;
        Debug.Log("Strength : " + strength);

        Stats stats = new Stats
        {
            statLevel = strLevel,
            statIncrease = strengthIncrease,
            stat = strength,
            pureStat = pureAtt
        };
        StatsDataManager.instance.SaveStatsData(stats, "strength");
    }

    public void CriChanceUp()
    {
        criChanceLevel++;
        criChanceIncrease += increaseAmount;
        criticalChance += criChanceIncrease;

        pureCriChance += criChanceIncrease;
        Debug.Log("CriticalChance : " + criticalChance);

        Stats stats = new Stats
        {
            statLevel = criChanceLevel,
            statIncrease = criChanceIncrease,
            stat = criticalChance,
            pureStat = pureCriChance
        };
        StatsDataManager.instance.SaveStatsData(stats, "criticalChance");
    }

    public void CriDamageUp()
    {
        criDamageLevel++;
        criDamageIncrease += increaseAmount;
        criticalDamage += criDamageIncrease;

        pureCriDamage += criDamageIncrease;
        Debug.Log("CriticalDamage : " + criticalDamage);

        Stats stats = new Stats
        {
            statLevel = criDamageLevel,
            statIncrease = criDamageIncrease,
            stat = criticalDamage,
            pureStat = pureCriDamage
        };
        StatsDataManager.instance.SaveStatsData(stats, "criticalDamage");
    }

    public void GoldAcquireUp()
    {
        goldAcqLevel++;
        goldAcqIncrease += increaseAmount;
        goldAcquire += goldAcqIncrease;
        Debug.Log("GoldAcquire : " + goldAcquire);

        Stats stats = new Stats
        {
            statLevel = goldAcqLevel,
            statIncrease = goldAcqIncrease,
            stat = goldAcquire,
        };
        StatsDataManager.instance.SaveStatsData(stats, "goldAcquire");
    }

    public void ExpAcquireUp()
    {
        expAcqLevel++;
        expAcqIncrease += increaseAmount;
        expAcquire += expAcqIncrease;
        Debug.Log("ExpAcquire : " + expAcquire);

        Stats stats = new Stats
        {
            statLevel = expAcqLevel,
            statIncrease = expAcqIncrease,
            stat = expAcquire,
        };
        StatsDataManager.instance.SaveStatsData(stats, "expAcquire");
    }

    #endregion

    #region Character_Stats

    int charStrLevel, charCriChanceLevel, charCriDamageLevel, charGoldAcqLevel, charExpAcqLevel;

    public float charStrRate { get; private set; }
    public float charCriChanceRate { get; private set; }
    public float charCriDamageRate { get; private set; }
    public float charGoldAcqRate { get; private set; }
    public float charExpAcqRate { get; private set; }

    public float charStrIncrease { get; private set; }
    public float charCriChanceIncrease { get; private set; }
    public float charCriDamageIncrease { get; private set; }
    public float charGoldAcqIncrease { get; private set; }
    public float charExpAcqIncrease { get; private set; }

    static float increaseCharAmoun = 0.1f;

    #endregion

    #region Character_Stats_Level

    public int getCharStrLevel { get => charStrLevel; }
    public int getCharCriChanceLevel { get => charCriChanceLevel; }
    public int getCharCriDamageLevel { get => charCriDamageLevel; }
    public int getCharGoldAcqLevel { get => charGoldAcqLevel; }
    public int getCharExpAcqLevel { get => charExpAcqLevel; }

    #endregion

    #region Next_Char_Stats

    public float nextCharStr { get => charStrRate + increaseCharAmoun; }
    public float nextCharCriChance { get => charCriChanceRate + increaseCharAmoun; }
    public float nextCharCriDamage { get => charCriDamageRate + increaseCharAmoun; }
    public float nextCharGoldAcq { get => charGoldAcqRate + increaseCharAmoun; }
    public float nextCharExpAcq { get => charExpAcqRate + increaseCharAmoun; }

    #endregion

    #region Character_Stats_Up

    public void Character_StrengthUp()
    {
        charStrLevel++;
        charStrIncrease += increaseCharAmoun;

        charStrRate += charStrIncrease;

        CharactorStats charStr = new CharactorStats
        {
            charStatLevel = charStrLevel,
            charStatIncrease = charStrIncrease,
            charStatRate = charStrRate,
        };
        StatsDataManager.instance.SaveCharStatsData(charStr, "strength");
    }

    public void Character_CriChanceUp()
    {
        charCriChanceLevel++;
        charCriChanceIncrease += increaseCharAmoun;

        charCriChanceRate += charCriChanceIncrease;

        CharactorStats charCriChance = new CharactorStats
        {
            charStatLevel = charCriChanceLevel,
            charStatIncrease = charCriChanceIncrease,
            charStatRate = charCriChanceRate,
        };
        StatsDataManager.instance.SaveCharStatsData(charCriChance, "criticalChance");
    }

    public void Character_CriDamageUp()
    {
        charCriDamageLevel++;
        charCriDamageIncrease += increaseCharAmoun;

        charCriDamageRate += charCriDamageIncrease;

        CharactorStats charCriDamage = new CharactorStats
        {
            charStatLevel = charCriDamageLevel,
            charStatIncrease = charCriDamageIncrease,
            charStatRate = charCriDamageRate,
        };
        StatsDataManager.instance.SaveCharStatsData(charCriDamage, "criticalDamage");
    }

    public void Character_GoldAcqUp()
    {
        charGoldAcqLevel++;
        charGoldAcqIncrease += increaseCharAmoun;

        charGoldAcqRate += charGoldAcqIncrease;

        CharactorStats charGoldAcq = new CharactorStats
        {
            charStatLevel = charGoldAcqLevel,
            charStatIncrease = charGoldAcqIncrease,
            charStatRate = charGoldAcqRate,
        };
        StatsDataManager.instance.SaveCharStatsData(charGoldAcq, "goldAcquire");
    }

    public void Character_ExpAcqUp()
    {
        charExpAcqLevel++;
        charExpAcqIncrease += increaseCharAmoun;

        charExpAcqRate += charExpAcqIncrease;

        CharactorStats charExpAcq = new CharactorStats
        {
            charStatLevel = charExpAcqLevel,
            charStatIncrease = charExpAcqIncrease,
            charStatRate = charExpAcqRate,
        };
        StatsDataManager.instance.SaveCharStatsData(charExpAcq, "expAcquire");
    }

    #endregion

    #region Equip_Item

    cItemInstance hemelStats;
    cItemInstance armorStats;
    cItemInstance weaponStats;

    // 아이템 장착
    public void UpdateWearEquipStats(cItemInstance itemData)
    {
        RemoveEquip(itemData);

        // 아이템 장착
        switch (itemData.type)
        {
            case ItemType.HELMET:
                hemelStats = itemData;
                UpdateEquipStats(hemelStats);
                break;

            case ItemType.ARMOR:
                armorStats = itemData;
                UpdateEquipStats(armorStats);
                break;

            case ItemType.WEAPON:
                weaponStats = itemData;
                UpdateEquipStats(weaponStats);
                break;
        }
    }

    // 아이템 해제
    void RemoveEquip(cItemInstance itemData)
    {
        // 장착중인 아이템 제거
        switch (itemData.type)
        {
            case ItemType.HELMET:
                RemoveEquipStats(hemelStats);
                hemelStats = null;
                break;

            case ItemType.ARMOR:
                RemoveEquipStats(armorStats);
                armorStats = null;
                break;

            case ItemType.WEAPON:
                RemoveEquipStats(weaponStats);
                weaponStats = null;
                break;
        }
    }

    // 스탯 +
    void UpdateEquipStats(cItemInstance itemData)
    {
        if (itemData == null)
            return;

        if (itemData.itemStats.att > 0)
            strength += itemData.itemStats.att;
        if (itemData.itemStats.bossAtt > 0)
            bossStrength += itemData.itemStats.bossAtt;
        if (itemData.itemStats.criticalChance > 0)
            criticalChance += itemData.itemStats.criticalChance;
        if (itemData.itemStats.criticalDamage > 0)
            criticalDamage += itemData.itemStats.criticalDamage;

        Debug.Log("Att : " + strength + "\n" + "BossAtt : " + bossStrength + "\n" + "Crichance : " + criticalChance + "\n" + "CriDamage : " + criticalDamage);
    }

    // 스탯 -
    void RemoveEquipStats(cItemInstance itemData)
    {
        if (itemData == null)
            return;

        if (itemData.itemStats.att > 0)
            strength -= itemData.itemStats.att;
        if (itemData.itemStats.bossAtt > 0)
            bossStrength -= itemData.itemStats.bossAtt;
        if (itemData.itemStats.criticalChance > 0)
            criticalChance -= itemData.itemStats.criticalChance;
        if (itemData.itemStats.criticalDamage > 0)
            criticalDamage -= itemData.itemStats.criticalDamage;

        Debug.Log("Att : " + strength + "\n" + "BossAtt : " + bossStrength + "\n" + "Crichance : " + criticalChance + "\n" + "CriDamage : " + criticalDamage);
    }

    // 아이템을 장착한 상태에서 강화를 눌렀을 때
    public void UpdateStats(cItemInstance itemData)
    {
        strength = pureAtt + itemData.itemStats.att;
        bossStrength = pureBossAtt + itemData.itemStats.bossAtt;
        criticalChance = pureCriChance + itemData.itemStats.criticalChance;
        criticalDamage = pureCriDamage + itemData.itemStats.criticalDamage;

        Debug.Log("Att : " + strength + "\n" + "BossAtt : " + bossStrength + "\n" + "Crichance : " + criticalChance + "\n" + "CriDamage : " + criticalDamage);
    }

    #endregion

    void Start()
    {
        InitializeStats();
        InitializeCharStats();
    }

    void InitializeStats()
    {
        Stats strStats = StatsDataManager.instance.LoadStatsData("strength");
        if (strStats != null)
        {
            strLevel = strStats.statLevel;
            strengthIncrease = strStats.statIncrease;
            strength = strStats.stat;
            pureAtt = strStats.pureStat;
        }
        else
        {
            strength = 10;
            pureAtt = strength;
        }

        Stats criChanceStats = StatsDataManager.instance.LoadStatsData("criticalChance");
        if (criChanceStats != null)
        {
            criChanceLevel = criChanceStats.statLevel;
            criChanceIncrease = criChanceStats.statIncrease;
            criticalChance = criChanceStats.stat;
            pureCriChance = criChanceStats.pureStat;
        }
        else
        {
            criticalChance = 10;
            pureCriChance = criticalChance;
        }

        Stats criDamageStats = StatsDataManager.instance.LoadStatsData("criticalDamage");
        if (criDamageStats != null)
        {
            criDamageLevel = criDamageStats.statLevel;
            criDamageIncrease = criDamageStats.statIncrease;
            criticalDamage = criDamageStats.stat;
            pureCriDamage = criDamageStats.pureStat;
        }
        else
        {
            criticalDamage = 10;
            pureCriDamage = criticalDamage;
        }

        Stats goldAcqStats = StatsDataManager.instance.LoadStatsData("goldAcquire");
        if (goldAcqStats != null)
        {
            goldAcqLevel = goldAcqStats.statLevel;
            goldAcqIncrease = goldAcqStats.statIncrease;
            goldAcquire = goldAcqStats.stat;
        }
        else
            goldAcquire = 0;

        Stats expAcqStats = StatsDataManager.instance.LoadStatsData("expAcquire");
        if (expAcqStats != null)
        {
            expAcqLevel = expAcqStats.statLevel;
            expAcqIncrease = expAcqStats.statIncrease;
            expAcquire = expAcqStats.stat;
        }
        else
            expAcquire = 0;

        //Stats bossStats = StatsDataManager.instance.LoadStatsData("bossStrength");
        //if (bossStats != null)
        //{
        //    bossStrength = bossStats.stat;
        //    pureBossAtt = bossStats.pureStat;
        //}
        //else
        //{
            bossStrength = 10;
            pureBossAtt = bossStrength;
        //}
    }

    void InitializeCharStats()
    {
        CharactorStats strStats = StatsDataManager.instance.LoadCharStatsData("strength");
        if (strStats != null)
        {
            charStrLevel = strStats.charStatLevel;
            charStrIncrease = strStats.charStatIncrease;
            charStrRate = strStats.charStatRate;
        }
        else
            charStrRate = 1f;

        CharactorStats criChanceStats = StatsDataManager.instance.LoadCharStatsData("criticalChance");
        if (criChanceStats != null)
        {
            charCriChanceLevel = criChanceStats.charStatLevel;
            charCriChanceIncrease = criChanceStats.charStatIncrease;
            charCriChanceRate = criChanceStats.charStatRate;
        }
        else
            charCriChanceRate = 1f;

        CharactorStats criDamageStats = StatsDataManager.instance.LoadCharStatsData("criticalDamage");
        if (criDamageStats != null)
        {
            charCriDamageLevel = criDamageStats.charStatLevel;
            charCriDamageIncrease = criDamageStats.charStatIncrease;
            charCriDamageRate = criDamageStats.charStatRate;
        }
        else
            charCriDamageRate = 1f;

        CharactorStats goldAcqStats = StatsDataManager.instance.LoadCharStatsData("goldAcquire");
        if (goldAcqStats != null)
        {
            charGoldAcqLevel = goldAcqStats.charStatLevel;
            charGoldAcqIncrease = goldAcqStats.charStatIncrease;
            charGoldAcqRate = goldAcqStats.charStatRate;
        }
        else
            charGoldAcqRate = 1f;

        CharactorStats expAcqStats = StatsDataManager.instance.LoadCharStatsData("expAcquire");
        if (expAcqStats != null)
        {
            charExpAcqLevel = expAcqStats.charStatLevel;
            charExpAcqIncrease = expAcqStats.charStatIncrease;
            charExpAcqRate = expAcqStats.charStatRate;
        }
        else
            charExpAcqRate = 1f;
    }
}
