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
    [SerializeField] Button sellButton;

    [Header("Item_Stats")]
    [SerializeField] Text statTxt1;
    [SerializeField] Text statTxt2;
    [SerializeField] Text statTxt3;
    [SerializeField] Text statTxt4;

    bool isWear;

    public void Initialize(cItemInstance itemData)
    {
        InitializeEnforce(itemData);
        InitializeStatTxt(itemData);
        isWear = false;
    }

    void InitializeEnforce(cItemInstance itemData)
    {
        itemImage.sprite = itemData.itemSprite;
        itemName.text = itemData.itemName;
        UpdateMatTxt(itemData);

        enforceButton.onClick.RemoveAllListeners();
        equipButton.onClick.RemoveAllListeners();
        sellButton.onClick.RemoveAllListeners();

        equipButton.onClick.AddListener(() => WearItem(itemData));
        equipButton.onClick.AddListener(() => AudioManager.instance.PlayerSfx(AudioManager.Sfx.WEAR));

        sellButton.onClick.AddListener(() => SellEquip(itemData));
        sellButton.onClick.AddListener(() => AudioManager.instance.PlayerSfx(AudioManager.Sfx.CLOSE));

        if (IsMaxLevel(itemData) == true)
            return;

        enforceButton.onClick.AddListener(() => Enforce(itemData));
        enforceButton.onClick.AddListener(() => InitializeStatTxt(itemData));
        enforceButton.onClick.AddListener(() => UpdateMatTxt(itemData));
        enforceButton.onClick.AddListener(() => AudioManager.instance.PlayerSfx(AudioManager.Sfx.ENFORCE));
    }

    void WearItem(cItemInstance itemData)
    {
        GameManager.instance.playerCom.WearItem(itemData);
        isWear = true;
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
            statTxt1.text = "공격력 " + itemData.itemStats.att.ToString();
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

    void Enforce(cItemInstance itemData)
    {
        cItemManager.instance.EnforceItem(itemData);

        if (isWear == true)
            GameManager.instance.playerCom.UpdateEnforceStats(itemData);
    }

    void UpdateMatTxt(cItemInstance itemData)
    {
        // 최대 강화 일 때
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

    void SellEquip(cItemInstance itemData)
    {
        // Need To Fix

        // 해당 아이템 돈+
        GameManager.instance.playerCom.AddCoin(itemData.price);
        // 강화창 닫기
        itemData.owner.GetComponent<cItemUI>().HideEnforceMoving();
        // 데이터 저장
        ItemDataManager.instance.RemoveItemData(itemData);
        // 해당 아이템 삭제
        Destroy(itemData.owner);
    }
}
