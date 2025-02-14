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
    public void AddArmorMat(float value) { armorMaterial += value; }
    public void SpendArmorMat(float value) { armorMaterial -= value; }
    public void AddWeaponMat(float value) { weaponMaterial += value; }
    public void SpendWeaponMat(float value) { weaponMaterial -= value; }

    Customizing custom;

    void Awake()
    {
        coin = 0f;
        armorMaterial = 0f;
        weaponMaterial = 0f;

        custom = GetComponent<Customizing>();
    }

    public void WearHelmet(int index){ custom.WearHelmet(index); }
    public void WearArmor(int index) { custom.WearArmor(index); }
    public void EquipWeapon(int index) { custom.EquipWeapon(index); }
}
