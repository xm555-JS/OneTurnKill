using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(cPlayerStats), typeof(cPlayerAttack))]
public class cPlayer : MonoBehaviour
{
    float coin;
    float armorMaterial;
    float weaponMaterial;

    #region Stats

    cPlayerStats playerStats;

    public int Strength { get => playerStats.strength; }
    public int BossStrength { get => playerStats.bossStrength; }
    public int CriticalChance { get => playerStats.criticalChance; }
    public int CriticalDamage { get => playerStats.criticalDamage; }
    public int GoldAcquire { get => playerStats.goldAcquire; }
    public int ExpAcquire { get => playerStats.expAcquire; }

    public void UpdateEnforceStats(cItemInstance itemData) { playerStats.UpdateStats(itemData); }

    #endregion

    #region PropertyItem

    public float Coin { get => coin; }
    public float ArmorMaterial { get => armorMaterial; }
    public float WeaponMaterial { get => weaponMaterial; }

    #endregion

    #region AddSpend
    public void AddCoin(float value) { coin += value; }
    public void SpendCoin(float value) { coin -= value; }
    public void AddArmorMat(int value) { armorMaterial += value; }
    public void SpendArmorMat(int value) { armorMaterial -= value; }
    public void AddWeaponMat(int value) { weaponMaterial += value; }
    public void SpendWeaponMat(int value) { weaponMaterial -= value; }
    #endregion

    #region Customizing
    Customizing custom;

    public void WearItem(cItemInstance itemData)
    {
        switch (itemData.type)
        {
            case ItemType.HELMET:
                custom.WearHelmet(itemData.itemIndex);
                break;
            case ItemType.ARMOR:
                custom.WearArmor(itemData.itemIndex);
                break;
            case ItemType.WEAPON:
                custom.EquipWeapon(itemData.itemIndex);
                break;
        }

        // 아이템 스텟 적용
        playerStats.UpdateWearEquipStats(itemData);
    }

    #endregion

    #region Event
    public void SubscribeCoinDrop(cCoinArea coinArea) { coinArea.OnCoinDrop += AddCoin; }
    #endregion

    void Awake()
    {
        coin = 100000f;
        armorMaterial = 400f;
        weaponMaterial = 0f;

        custom = GetComponent<Customizing>();
        playerStats = GetComponent<cPlayerStats>();
    }
}
