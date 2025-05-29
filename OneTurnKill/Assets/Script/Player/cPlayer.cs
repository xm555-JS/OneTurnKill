using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(cPlayerStats), typeof(cPlayerAttack), typeof(cPlayerMouseMoving))]
public class cPlayer : MonoBehaviour
{
    float coin;
    float bossCoin;
    float armorMaterial;
    float weaponMaterial;

    #region Stats

    cPlayerStats playerStats;

    public long Strength { get => playerStats.strength; }
    public int BossStrength { get => playerStats.bossStrength; }
    public long CriticalChance { get => playerStats.criticalChance; }
    public long CriticalDamage { get => playerStats.criticalDamage; }
    public long GoldAcquire { get => playerStats.goldAcquire; }
    public long ExpAcquire { get => playerStats.expAcquire; }

    public void UpdateEnforceStats(cItemInstance itemData) { playerStats.UpdateStats(itemData); }

    // Char_Stats
    public float CharStrRate { get => playerStats.charStrRate; }
    public float CharCriChanceRate { get => playerStats.charCriChanceRate; }
    public float CharCriDamageRate { get => playerStats.charCriDamageRate; }
    public float CharGoldAcqRate { get => playerStats.charGoldAcqRate; }
    public float CharExpAcqRate { get => playerStats.charExpAcqRate; }

    #endregion

    #region PropertyItem

    public float Coin { get => coin; }
    public float BossCoin { get => bossCoin; }
    public float ArmorMaterial { get => armorMaterial; }
    public float WeaponMaterial { get => weaponMaterial; }

    #endregion

    #region AddSpend

    public void AddCoin(float value) { coin += value; SaveCoin(); }
    public void SpendCoin(float value) { coin -= value; SaveCoin(); }
    public void AddBossCoin(float value) { bossCoin += value; SaveBossCoin(); }
    public void SpendBossCoin(float value) { bossCoin -= value; SaveBossCoin(); }
    public void AddArmorMat(int value) { armorMaterial += value; SaveArmorMat();  }
    public void SpendArmorMat(int value) { armorMaterial -= value; SaveArmorMat(); }
    public void AddWeaponMat(int value) { weaponMaterial += value; SaveWeaponMat(); }
    public void SpendWeaponMat(int value) { weaponMaterial -= value; SaveWeaponMat(); }
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

    public void SaveCustomData() { custom.SaveCustomData(); }

    #endregion

    #region Event
    public void SubscribeCoinDrop(cCoinArea coinArea) { coinArea.OnCoinDrop += AddCoin; }
    #endregion

    #region Hit

    bool isHit;
    public bool IsHit { get => isHit; }
    public void ResetHit() { isHit = false; }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MonsterSkill"))
        {
            isHit = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("AreaSkill"))
            isHit = true;
    }

    #endregion

    #region SaveAndLoad

    public void SaveCoin() { PlayerPrefs.SetFloat("coin", coin); }
    public void SaveBossCoin() { PlayerPrefs.SetFloat("bossCoin", bossCoin); }
    public void SaveArmorMat() { PlayerPrefs.SetFloat("armorMaterial", armorMaterial); }
    public void SaveWeaponMat() { PlayerPrefs.SetFloat("weaponMaterial", weaponMaterial); }

    float LoadCoin() { return PlayerPrefs.GetFloat("coin", coin); }
    float LoadBossCoin() { return PlayerPrefs.GetFloat("bossCoin", bossCoin); }
    float LoadArmorMat() { return PlayerPrefs.GetFloat("armorMaterial", armorMaterial); }
    float LoadWeaponMat() { return PlayerPrefs.GetFloat("weaponMaterial", weaponMaterial); }


    #endregion

    #region CatchMoving



    #endregion

    void Awake()
    {
        coin = LoadCoin();
        bossCoin = LoadBossCoin();
        armorMaterial = LoadArmorMat(); ;
        weaponMaterial = LoadWeaponMat();

        custom = GetComponent<Customizing>();
        playerStats = GetComponent<cPlayerStats>();
    }
}
