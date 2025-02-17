using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cEquipArea : cItemArea
{
    protected override void GetItem(Collider2D collision)
    {
        // *** EquipArea�� �浹�� ��� �����۵��� ��� �κ��� �ø��� ***

        // Area -> Player -> Inven 
        // {
        //      Inven�� player�� ������ �ִ� ������ �����´�.
        //      Inven�� ��� List�� sprite�� ������ �κ� ���κ��� Sprite�� �ٲ۴�.
        //      Player�� ���� ��� ������ �ִ��� �˾ƾ��Ѵ�.(List�� ��� �ε����� ��Ƽ� sprite�� return�� �� �ְ� �Ѵ�.)
        //      Area���� ���� ����� �ε����� Player�� �ѱ��.
        //      item���� ����� �ε����� �� �� �ְ��Ѵ�.
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
