using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct stats
{
    public float str;
    public float criticalChance;
    public float criticalDamage;
}

public enum ItemType { COIN, MATERIALS, HELMET, ARMOR, WEAPON }

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/ItemData")]
public class cItemData : MonoBehaviour
{
    public Sprite itemSprite;
    public stats itemStats;
    public ItemType type;
    public int itemIndex;
    public float price;
}
