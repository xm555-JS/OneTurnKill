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
    public int CriticalChance { get => playerStats.criticalChance; }
    public int CriticalDamage { get => playerStats.criticalDamage; }
    public int GoldAcquire { get => playerStats.goldAcquire; }
    public int ExpAcquire { get => playerStats.expAcquire; }

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

    List<int> helmetList = new List<int>();
    List<int> armorList = new List<int>();
    List<int> weaponList = new List<int>();

    List<Sprite> helmetSprites = new List<Sprite>();
    List<Sprite> armorSprites = new List<Sprite>();
    List<Sprite> weaponSprites = new List<Sprite>();

    // 옷을 입힐 수 있게
    public void WearItem(cItemInstance itemData)
    {
        switch (itemData.type)
        {
            case ItemType.HELMET:
                custom.WearHelmet(itemData.itemIndex);
                // 여기에서 해당 아이템 정보를 기준으로 스탯업
                // 스탯업은 cPlayerStats에서 함수를 만들어야함.
                // 해당 함수는 각 스탯을 업 할 수 있도록하고
                // 장착하고 있는 아이템의 스탯을 저장한 뒤
                // 다른 아이템을 장착하면 해당 스탯을 뺀 뒤 다른 아이템의 스탯을 반영 할 수 있도록
                break;
            case ItemType.ARMOR:
                custom.WearArmor(itemData.itemIndex);
                // Helmet이랑 Armor 스탯 적용하는 함수를 따로 만들어야하나? -> 따로 만들어야함
                // 그렇다면 Helmet, Armor, Weapon 총 3개의 함수를 만들어야함
                break;
            case ItemType.WEAPON:
                custom.EquipWeapon(itemData.itemIndex);
                break;
        }
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
