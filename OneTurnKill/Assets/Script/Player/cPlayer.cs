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

    public void AddCoin(float value) { coin += value; }
    public void SpendCoin(float value) { coin -= value; }
    public void AddArmorMat(int value) { armorMaterial += value; }
    public void SpendArmorMat(int value) { armorMaterial -= value; }
    public void AddWeaponMat(int value) { weaponMaterial += value; }
    public void SpendWeaponMat(int value) { weaponMaterial -= value; }

    Customizing custom;

    List<int> helmetList = new List<int>();
    List<int> armorList = new List<int>();
    List<int> weaponList = new List<int>();

    List<Sprite> helmetSprites = new List<Sprite>();
    List<Sprite> armorSprites = new List<Sprite>();
    List<Sprite> weaponSprites = new List<Sprite>();

    public void AddHelmetList(int index)
    {
        helmetList.Add(index);
    }

    public void AddArmorList(int index)
    {
        armorList.Add(index);
    }

    public void AddWeaponList(int index)
    {
        weaponList.Add(index);
    }

    public List<Sprite> ReturnHelmetList()
    {
        foreach (var index in helmetList)
        {
            helmetSprites.Add(custom.ReturnHelmetSprite(index));
        }

        return helmetSprites;
    }

    public List<Sprite> ReturnArmorList()
    {
        foreach (var index in armorList)
        {
            armorSprites.Add(custom.ReturnArmorSprite(index));
        }

        return armorSprites;
    }

    public List<Sprite> ReturnWeaponList()
    {
        foreach (var index in armorList)
        {
            weaponSprites.Add(custom.ReturnWeaponSprite(index));
        }

        return weaponSprites;
    }

    void Awake()
    {
        coin = 0f;
        armorMaterial = 0f;
        weaponMaterial = 0f;

        custom = GetComponent<Customizing>();
    }

    public void WearHelmet(int index) { custom.WearHelmet(index); }
    public void WearArmor(int index) { custom.WearArmor(index); }
    public void EquipWeapon(int index) { custom.EquipWeapon(index); }
}
