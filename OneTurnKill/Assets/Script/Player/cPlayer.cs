using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(cPlayerStats), typeof(cPlayerAttack))]
public class cPlayer : MonoBehaviour
{
    float coin;
    float armorMaterial;
    float weaponMaterial;

    #region PropertyItem

    public float Coin { get => coin; }
    public float ArmorMaterial { get => armorMaterial; }
    public float WeaponMaterial { get => weaponMaterial; }

    #endregion

    #region AddSpend
    public void AddCoin(float value) { coin += value; Debug.Log("µ∑ »πµÊ" + value); }
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

    // ø ¿ª ¿‘»˙ ºˆ ¿÷∞‘
    public void WearItem(cItemData itemData)
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
    }
    #endregion

    #region Event
    public void SubscribeCoinDrop(cCoinArea coinArea) { coinArea.OnCoinDrop += AddCoin; }
    #endregion

    void Awake()
    {
        coin = 0f;
        armorMaterial = 0f;
        weaponMaterial = 0f;

        custom = GetComponent<Customizing>();
    }


    //public void WearHelmetTest(cItemData itemData)
    //{
    //    custom.WearHelmet(itemData.itemIndex);


    //}

    //// «ˆ¿Á «√∑π¿ÃæÓ∞° Ω¿µÊ«— ¿Â∫Ò List
    //public void AddHelmetList(int index)
    //{
    //    helmetList.Add(index);
    //    helmetSprites.Add(custom.ReturnHelmetSprite(index));
    //}

    //public void AddArmorList(int index)
    //{
    //    armorList.Add(index);
    //    armorSprites.Add(custom.ReturnArmorSprite(index));
    //}

    //public void AddWeaponList(int index)
    //{
    //    weaponList.Add(index);
    //    weaponSprites.Add(custom.ReturnWeaponSprite(index));
    //}

    //// Ω¿µÊ«— ¿Â∫Ò List Return
    //public List<Sprite> ReturnHelmetList()
    //{
    //    return helmetSprites;
    //}

    //public List<Sprite> ReturnArmorList()
    //{
    //    return armorSprites;
    //}

    //public List<Sprite> ReturnWeaponList()
    //{
    //    return weaponSprites;
    //}
}
