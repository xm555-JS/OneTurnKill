using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cItemManager : MonoBehaviour
{
    public stats itemStats;

    public void WeaponStatsInstance(cItemData itemData)
    {
        itemStats = new stats
        {
            Att = itemData.itemStats.Att + Random.Range(-2, 6),
            bossAtt = itemData.itemStats.bossAtt + Random.Range(-2, 6),
            criticalChance = itemData.itemStats.criticalChance + Random.Range(-2, 6),
            criticalDamage = itemData.itemStats.criticalDamage + Random.Range(-2, 6)
        };
    }

    public void ArmorStatsInstance(cItemData itemData)
    {
        itemStats = new stats
        {
            criticalChance = itemData.itemStats.criticalChance + Random.Range(-2, 6),
            criticalDamage = itemData.itemStats.criticalDamage + Random.Range(-2, 6)
        };
    }
}
