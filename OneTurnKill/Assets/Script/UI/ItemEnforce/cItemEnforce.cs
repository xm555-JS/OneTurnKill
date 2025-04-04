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
    [SerializeField] Button equipButton;

    [Header("Item_Stats")]
    [SerializeField] Text statTxt1;
    [SerializeField] Text statTxt2;
    [SerializeField] Text statTxt3;
    [SerializeField] Text statTxt4;

    public void Initialize(cItemInstance itemData)
    {
        InitializeEnforce(itemData);
        InitializeStatTxt(itemData);
    }

    void InitializeEnforce(cItemInstance itemData)
    {
        itemImage.sprite = itemData.itemSprite;
        itemName.text = itemData.itemName;
        UpdateMatTxt(itemData);

        enforceButton.onClick.RemoveAllListeners();

        if (IsMaxLevel(itemData) == true)
            return;

        enforceButton.onClick.AddListener(() => cItemManager.instance.EnforceItem(itemData));
        enforceButton.onClick.AddListener(() => InitializeStatTxt(itemData));
        enforceButton.onClick.AddListener(() => UpdateMatTxt(itemData));

        equipButton.onClick.AddListener(() => GameManager.instance.playerCom.WearItem(itemData));
    }

    bool IsMaxLevel(cItemInstance itemData)
    {
        if (itemData.level >= itemData.enforceAmount.Length)
        {
            enforceButton.interactable = false;
            return true;
        }
        else
            enforceButton.interactable = true;

        return false;
    }

    void InitializeStatTxt(cItemInstance itemData)
    {
        itemName.text = itemData.itemName + " LV." + itemData.level.ToString();

        if (itemData.itemStats.att != 0)
            statTxt1.text = "���ݷ� " + itemData.itemStats.att.ToString();
        else
            statTxt1.gameObject.SetActive(false);

        if (itemData.itemStats.bossAtt != 0)
            statTxt2.text = "���� ���ݷ� " + itemData.itemStats.bossAtt.ToString();
        else
            statTxt2.gameObject.SetActive(false);

        if (itemData.itemStats.criticalChance != 0)
            statTxt3.text = "ġ��Ÿ Ȯ�� ���� " + itemData.itemStats.criticalChance.ToString();
        else
            statTxt3.gameObject.SetActive(false);

        if (itemData.itemStats.criticalDamage != 0)
            statTxt4.text = "ġ��Ÿ ���� ���� " + itemData.itemStats.criticalDamage.ToString();
        else
            statTxt4.gameObject.SetActive(false);
    }

    void UpdateMatTxt(cItemInstance itemData)
    {
        // �ִ� ��ȭ �� ��
        if (IsMaxLevel(itemData) == true)
        {
            itemEnforceMaterial.text = "Max";
            return;
        }

        if (itemData.type == ItemType.HELMET || itemData.type == ItemType.ARMOR)
            itemEnforceMaterial.text = GameManager.instance.playerCom.ArmorMaterial.ToString() + "/" + itemData.enforceAmount[itemData.level];
        else if (itemData.type == ItemType.WEAPON)
            itemEnforceMaterial.text = GameManager.instance.playerCom.WeaponMaterial.ToString() + "/" + itemData.enforceAmount[itemData.level];
    }
}
