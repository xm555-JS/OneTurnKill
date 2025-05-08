using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct stats
{
    public int att;
    public int bossAtt;
    public int criticalChance;
    public int criticalDamage;
}

public enum ItemType { COIN, ARMORMATERIALS, WEAPONMATERIALS, HELMET, ARMOR, WEAPON }

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/ItemData")]
public class cItemData : ScriptableObject
{
    [Header("For_UI")]
    public Sprite itemSprite;
    public string itemName;
    public stats itemStats;
    public ItemType type;
    public int itemIndex;
    public int price;
    public string path;
    public bool isInstance;

    [Header("For_Enforce")]
    public int ID;
    public GameObject owner;
    public int level;
    public int[] levelDamage = new int[5] { 1, 10, 20, 40, 60 };
    public int[] enforceAmount = new int[5] { 2, 3, 4, 6, 10 };
}
