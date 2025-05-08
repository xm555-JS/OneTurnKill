using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cItemInstance
{
    [Header("For_UI")]
    public Sprite itemSprite;
    public string itemName;
    public stats itemStats;
    public ItemType type;
    public int itemIndex;
    public int price;
    public bool isInstance;

    [Header("For_Enforce")]
    public int ID;
    public GameObject owner;
    public int level;
    public int[] levelDamage = new int[5] { 1, 10, 20, 40, 60 };
    public int[] enforceAmount = new int[5] { 2, 3, 4, 6, 10 };

    public cItemInstance(cItemData itemData)
    {
        owner = itemData.owner;
        level = itemData.level;
        ID = itemData.ID;
        itemSprite = itemData.itemSprite;
        itemName = itemData.itemName;
        type = itemData.type;
        itemIndex = itemData.itemIndex;
        price = itemData.price;
        isInstance = itemData.isInstance;

        if (isInstance)
        {
            itemStats.att = itemData.itemStats.att;
            itemStats.bossAtt = itemData.itemStats.bossAtt;
            itemStats.criticalChance = itemData.itemStats.criticalChance;
            itemStats.criticalDamage = itemData.itemStats.criticalDamage;
            return;
        }
            

        if (type == ItemType.ARMOR || type == ItemType.HELMET)
        {
            itemStats = new stats
            {
                criticalChance = itemData.itemStats.criticalChance + Random.Range(-2, 6),
                criticalDamage = itemData.itemStats.criticalDamage + Random.Range(-2, 6)
            };
        }
        else if (type == ItemType.WEAPON)
        {
            itemStats = new stats
            {
                att = itemData.itemStats.att + Random.Range(-2, 6),
                bossAtt = itemData.itemStats.bossAtt + Random.Range(-2, 6),
                criticalChance = itemData.itemStats.criticalChance + Random.Range(-2, 6),
                criticalDamage = itemData.itemStats.criticalDamage + Random.Range(-2, 6)
            };
        }
    }
}
