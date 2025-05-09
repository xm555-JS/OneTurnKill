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

    int hpLevel, strLevel, criChanceLevel, criDamageLevel, goldAcqLevel, expAcqLevel;

    public int strengthIncrease { get; private set; }
    public int criChanceIncrease { get; private set; }
    public int criDamageIncrease { get; private set; }
    public int goldAcqIncrease { get; private set; }
    public int expAcqIncrease { get; private set; }

    static int increaseAmount = 10;

    #endregion

    #region PureStats

    int pureAtt;
    int pureBossAtt;
    int pureCriChance;
    int pureCriDamage;

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
        StatsDataManager.instance.SaveStatsData(stats, "criticalChance");
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
    }

    public void Character_CriChanceUp()
    {
        charCriChanceLevel++;
        charCriChanceIncrease += increaseCharAmoun;

        charCriChanceRate += charCriChanceIncrease;
    }

    public void Character_CriDamageUp()
    {
        charCriDamageLevel++;
        charCriDamageIncrease += increaseCharAmoun;

        charCriDamageRate += charCriDamageIncrease;
    }

    public void Character_GoldAcqUp()
    {
        charGoldAcqLevel++;
        charGoldAcqIncrease += increaseCharAmoun;

        charGoldAcqRate += charGoldAcqIncrease;
    }

    public void Character_ExpAcqUp()
    {
        charExpAcqLevel++;
        charExpAcqIncrease += increaseCharAmoun;

        charExpAcqRate += charExpAcqIncrease;
    }

    #endregion

    #region Equip_Item

    cItemInstance hemelStats;
    cItemInstance armorStats;
    cItemInstance weaponStats;

    // ������ ����
    public void UpdateWearEquipStats(cItemInstance itemData)
    {
        RemoveEquip(itemData);

        // ������ ����
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

    // ������ ����
    void RemoveEquip(cItemInstance itemData)
    {
        // �������� ������ ����
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

    // ���� +
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

    // ���� -
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

    // �������� ������ ���¿��� ��ȭ�� ������ ��
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

        //Stats bossStats = StatsDataManager.instance.LoadStatsData("strength");
        //if (stats != null)
        //{
        //    strLevel = stats.statLevel;
        //    strengthIncrease = stats.statIncrease;
        //    strength = stats.stat;
        //    pureAtt = stats.pureStat;
        //}
        //else
        //{
        bossStrength = 10;
        pureBossAtt = bossStrength;
        //}

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
    }

    void InitializeCharStats()
    {
        // ���࿡ ����� �����Ͱ� ���ٸ�
        charStrRate = 1f;
        charCriChanceRate = 1f;
        charCriDamageRate = 1f;
        charGoldAcqRate = 1f;
        charExpAcqRate = 1f;
        // ���࿡ ����� �����Ͱ� �ִٸ� �ش� ����� �����͸� �������� ����
    }
}
