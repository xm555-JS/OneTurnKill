using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cEquipArea : cItemArea
{
    protected override void GetItem(Collider2D collision)
    {
        // *** EquipArea에 충돌된 장비 아이템들을 어떻게 인벤에 올릴지 ***

        // Area -> Player -> Inven 
        // {
        //      Inven이 player가 가지고 있는 장비들을 가져온다.
        //      Inven은 장비 List의 sprite를 가져와 인벤 장비부분의 Sprite를 바꾼다.
        //      Player는 무슨 장비를 가지고 있는지 알아야한다.(List로 장비 인덱스를 모아서 sprite를 return할 수 있게 한다.)
        //      Area에서 먹은 장비의 인덱스를 Player로 넘긴다.
        //      item에서 장비의 인덱스를 알 수 있게한다.
        // }
        // Area -> Inven

        if (collision.name == "Item_Armor_Material")
            player.AddArmorMat(1);
        else if (collision.name == "Item_Weapon_Material")
            player.AddWeaponMat(1);
        else
        {
            cItem item = collision.GetComponent<cItem>();

            if (item.type == cItem.ITEMTYPE.Helmet)
                player.AddHelmetList(item.index);
            else if (item.type == cItem.ITEMTYPE.Armor)
                player.AddArmorList(item.index);
            else if (item.type == cItem.ITEMTYPE.Weapon)
                player.AddWeaponList(item.index);
        }
    }
}
