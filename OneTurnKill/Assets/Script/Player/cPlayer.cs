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

    // 문제 : 아이템 강화를 할 때 착용한 상태에서 강화를 했을 때 문제를 해결하기 위해서 만들었는데
    // 이러면 착용하기 전에 강화를 할 때 문제가 생긴다
    // 착용했을 때, 안했을 때 강화 버튼을 누르는 것을 구분하는 방법이 있고
    // 조금 더 생각을 해서 cPlayerStats에서 강화할 떄 Stat이 update하는 방식을 다르게 해야할 것 같다.
    public void UpdatePlayerStats(cItemInstance itemData) { playerStats.UpdateStats(itemData); }

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
        coin = 0f;
        armorMaterial = 400f;
        weaponMaterial = 0f;

        custom = GetComponent<Customizing>();
        playerStats = GetComponent<cPlayerStats>();
    }
}
