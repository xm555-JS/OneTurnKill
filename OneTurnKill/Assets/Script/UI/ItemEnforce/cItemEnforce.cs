using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cItemEnforce : MonoBehaviour
{
    [Header("Enforce")]
    [SerializeField] Image itemImage;
    [SerializeField] Text itemName;
    [SerializeField] Text itemEnforceMaterial;
    [SerializeField] Button enforceButton;

    [Header("Item_Stats")]
    [SerializeField] Text statTxt1;
    [SerializeField] Text statTxt2;
    [SerializeField] Text statTxt3;
    [SerializeField] Text statTxt4;

    public void Initialize(cItemData itemData)
    {
        InitializeEnforce(itemData);
        InitializeStatTxt(itemData);
    }

    void InitializeEnforce(cItemData itemData)
    {
        itemImage.sprite = itemData.itemSprite;
        itemName.text = itemData.itemName;
        if (itemData.type == ItemType.HELMET && itemData.type == ItemType.ARMOR)
            itemEnforceMaterial.text = GameManager.instance.playerCom.ArmorMaterial.ToString() + "/" + itemData.enforceAmount[itemData.level];
        else if (itemData.type == ItemType.WEAPON)
            itemEnforceMaterial.text = GameManager.instance.playerCom.WeaponMaterial.ToString() + "/" + itemData.enforceAmount[itemData.level];
        //enforceButton.onClick.AddListener()
    }

    void InitializeStatTxt(cItemData itemData)
    {
        if (itemData.itemStats.Att != 0)
            statTxt1.text = "공격력 " + itemData.itemStats.Att.ToString();
        else
            statTxt1.gameObject.SetActive(false);

        if (itemData.itemStats.bossAtt != 0)
            statTxt2.text = "보스 공격력 " + itemData.itemStats.bossAtt.ToString();
        else
            statTxt2.gameObject.SetActive(false);

        if (itemData.itemStats.criticalChance != 0)
            statTxt3.text = "치명타 확률 증가 " + itemData.itemStats.criticalChance.ToString();
        else
            statTxt3.gameObject.SetActive(false);

        if (itemData.itemStats.criticalDamage != 0)
            statTxt4.text = "치명타 피해 증가 " + itemData.itemStats.criticalDamage.ToString();
        else
            statTxt4.gameObject.SetActive(false);

    }
}
