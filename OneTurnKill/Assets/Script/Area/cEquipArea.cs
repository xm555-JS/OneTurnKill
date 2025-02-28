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

        cItemData itemData = collision.gameObject.GetComponent<cItemData>();
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
        }
    }
}






//if (collision.name == "Item_Armor_Material")
//    player.AddArmorMat(1);
//else if (collision.name == "Item_Weapon_Material")
//    player.AddWeaponMat(1);
//else
//{
//cItem item = collision.GetComponent<cItem>();

//if (item.type == cItem.ITEMTYPE.Helmet)
//    player.AddHelmetList(item.index);
//else if (item.type == cItem.ITEMTYPE.Armor)
//    player.AddArmorList(item.index);
//else if (item.type == cItem.ITEMTYPE.Weapon)
//    player.AddWeaponList(item.index);
//}
