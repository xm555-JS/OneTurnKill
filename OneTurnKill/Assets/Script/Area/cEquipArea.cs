using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cEquipArea : cItemArea
{
    [SerializeField] cInven invenHelmet;
    [SerializeField] cInven invenArmor;
    [SerializeField] cInven invenWeapon;

    protected override void GetItem(Collider2D collision)
    {
        cItemData itemData = collision.gameObject.GetComponent<cItem>().ItemData;
        if (!itemData)
            return;
        switch (itemData.type)
        {
            case ItemType.HELMET:
                invenHelmet.InstItem(itemData);
                break;
            case ItemType.ARMOR:
                invenArmor.InstItem(itemData);
                break;
            case ItemType.WEAPON:
                invenWeapon.InstItem(itemData);
                break;
            case ItemType.ARMORMATERIALS:
                GameManager.instance.playerCom.AddArmorMat(1);
                break;
            case ItemType.WEAPONMATERIALS:
                GameManager.instance.playerCom.AddWeaponMat(1);
                break;
        }
    }
}
