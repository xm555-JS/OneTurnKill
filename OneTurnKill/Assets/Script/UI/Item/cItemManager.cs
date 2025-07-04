using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class cItemManager : MonoBehaviour
{
    public static cItemManager instance;
    public stats itemStats;

    void Awake()
    {
        instance = this;
    }

    #region Enforce_Item
    public void EnforceItem(cItemInstance itemData)
    {
        if (itemData.type == ItemType.HELMET || itemData.type == ItemType.ARMOR)
        {
            if (GameManager.instance.playerCom.ArmorMaterial < itemData.enforceAmount[itemData.level])
            {
                cPopupManager.instance.Push("ErrorPopup", "재료가 부족합니다.");
                return;
            }
            else
                UpgradeArmorStats(itemData);
        }
        else if (itemData.type == ItemType.WEAPON)
        {
            if (GameManager.instance.playerCom.ArmorMaterial < itemData.enforceAmount[itemData.level])
            {
                cPopupManager.instance.Push("ErrorPopup", "재료가 부족합니다.");
                return;
            }
            else
                UpgradeWeaponStats(itemData);
        }
    }
    #endregion

    #region Upgrade_Item_Stats
    void UpgradeArmorStats(cItemInstance itemData)
    {
        GameManager.instance.playerCom.SpendArmorMat(itemData.enforceAmount[itemData.level]);
        itemData.itemStats.criticalChance += itemData.enforceAmount[itemData.level];
        itemData.itemStats.criticalDamage += itemData.enforceAmount[itemData.level];
        itemData.level++;

        // update data
        ItemDataManager.instance.RewriteItemData(itemData);
    }

    void UpgradeWeaponStats(cItemInstance itemData)
    {
        GameManager.instance.playerCom.SpendWeaponMat(itemData.enforceAmount[itemData.level]);
        itemData.itemStats.att += itemData.enforceAmount[itemData.level];
        itemData.itemStats.bossAtt += itemData.enforceAmount[itemData.level];
        itemData.itemStats.criticalChance += itemData.enforceAmount[itemData.level];
        itemData.itemStats.criticalDamage += itemData.enforceAmount[itemData.level];
        itemData.level++;
    }
    #endregion
}
