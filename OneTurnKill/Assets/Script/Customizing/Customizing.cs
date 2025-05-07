using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customizing : MonoBehaviour
{
#pragma warning disable 0414

    #region Inspector

    [System.Serializable]
    public struct TopCloth
    {
        public Sprite body;
        public Sprite left;
        public Sprite right;
    }

    [System.Serializable]
    public struct Pants
    {
        public Sprite left;
        public Sprite right;
    }

    [System.Serializable]
    public struct Armor
    {
        public Sprite armorBody;
        public Sprite armorArmLeft;
        public Sprite armorArmRight;
    }

    [SerializeField] Sprite[] spriteHairs;
    [SerializeField] TopCloth[] spriteCloths;
    [SerializeField] Pants[] spritePants;
    [SerializeField] Armor[] spriteArmors;
    [SerializeField] Sprite[] spriteHelmets;
    [SerializeField] Sprite[] spriteBacks;
    [SerializeField] Sprite[] spriteWeapons;

    #endregion

    #region SpriteRenderer

    SpriteRenderer hairSpriteRender;

    SpriteRenderer topBodySpriteRender;
    SpriteRenderer topLeftSpriteRender;
    SpriteRenderer topRightSpriteRender;

    SpriteRenderer pantLeftSpriteRender;
    SpriteRenderer pantRightSpriteRender;

    SpriteRenderer armorSpriteRenderer;
    SpriteRenderer armorArmLeftSpriteRenderer;
    SpriteRenderer armorArmRightSpriteRenderer;

    SpriteRenderer helmetSpriteRenderer;

    SpriteRenderer backSpriteRenderer;

    SpriteRenderer weaponSpriteRenderer;

    #endregion

    #region Index

    int hairIndex = 0;
    int clothIndex = 0;
    int pantIndex = 0;
    int armorIndex = 0;
    int helmetIndex = 0;
    int backIndex = 0;
    int weaponIndex = 0;

    #endregion

    void Awake()
    {
        InitializeRenderer();
    }

    void Start()
    {
        LoadCustomData();
        LoadEquipData();
    }

    #region Hair_UI_Button
    public void NextHairs()
    {
        hairIndex++;

        if (hairIndex >= spriteHairs.Length)
            hairIndex = 0;

        hairSpriteRender.sprite = spriteHairs[hairIndex];
    }

    public void PreHairs()
    {
        hairIndex--;

        if (hairIndex < 0)
            hairIndex = spriteHairs.Length - 1;

        hairSpriteRender.sprite = spriteHairs[hairIndex];
    }
    #endregion

    #region Top_UI_Button
    public void NextTop()
    {
        clothIndex++;

        if (clothIndex >= spriteCloths.Length)
            clothIndex = 0;

        topBodySpriteRender.sprite = spriteCloths[clothIndex].body;
        topLeftSpriteRender.sprite = spriteCloths[clothIndex].left;
        topRightSpriteRender.sprite = spriteCloths[clothIndex].right;
    }

    public void PreTop()
    {
        clothIndex--;

        if (clothIndex < 0)
            clothIndex = spriteCloths.Length - 1;

        topBodySpriteRender.sprite = spriteCloths[clothIndex].body;
        topLeftSpriteRender.sprite = spriteCloths[clothIndex].left;
        topRightSpriteRender.sprite = spriteCloths[clothIndex].right;
    }
    #endregion

    #region Pant_UI_Button
    public void NextPants()
    {
        pantIndex++;

        if (pantIndex >= spritePants.Length)
            pantIndex = 0;

        pantLeftSpriteRender.sprite = spritePants[pantIndex].left;
        pantRightSpriteRender.sprite = spritePants[pantIndex].right;
    }

    public void PrePants()
    {
        pantIndex--;

        if (pantIndex < 0)
            pantIndex = spritePants.Length - 1;

        pantLeftSpriteRender.sprite = spritePants[pantIndex].left;
        pantRightSpriteRender.sprite = spritePants[pantIndex].right;
    }
    #endregion

    #region Wear_Armor

    public void WearArmor(int index)
    {
        armorIndex = index;
        armorSpriteRenderer.sprite = spriteArmors[armorIndex].armorBody;
        armorArmLeftSpriteRenderer.sprite = spriteArmors[armorIndex].armorArmLeft;
        armorArmRightSpriteRenderer.sprite = spriteArmors[armorIndex].armorArmRight;

        SaveEquipData();
    }

    #endregion

    #region Wear_Helmet

    public void WearHelmet(int index)
    {
        helmetIndex = index;
        helmetSpriteRenderer.sprite = spriteHelmets[helmetIndex];

        SaveEquipData();
    }

    #endregion

    #region Equip_Weapon

    public void EquipWeapon(int index)
    {
        weaponIndex = index;
        weaponSpriteRenderer.sprite = spriteWeapons[weaponIndex];

        SaveEquipData();
    }

    #endregion

    #region Data

    public void SaveCustomData()
    {
        CustomData data = new CustomData
        {
            hairIndex = hairIndex,
            clothIndex = clothIndex,
            pantIndex = pantIndex,
        };

        CustomDataManager.instance.SaveCustomData(data);
    }

    void LoadCustomData()
    {
        CustomData data = CustomDataManager.instance.LoadCustomData();
        if (data == null)
            return;

        // Load Hair
        hairSpriteRender.sprite = spriteHairs[data.hairIndex];

        // Load Top
        topBodySpriteRender.sprite = spriteCloths[data.clothIndex].body;
        topLeftSpriteRender.sprite = spriteCloths[data.clothIndex].left;
        topRightSpriteRender.sprite = spriteCloths[data.clothIndex].right;

        // Load Pants
        pantLeftSpriteRender.sprite = spritePants[data.pantIndex].left;
        pantRightSpriteRender.sprite = spritePants[data.pantIndex].right;
    }

    public void SaveEquipData()
    {
        EquipData data = new EquipData
        {
            helmetIndex = helmetIndex,
            armorIndex = armorIndex,
            weaponIndex = weaponIndex,
        };
        CustomDataManager.instance.SaveEquipData(data);
    }

    void LoadEquipData()
    {
        EquipData data = CustomDataManager.instance.LoadEquipData();
        if (data == null)
            return;

        helmetIndex = data.helmetIndex;
        armorIndex = data.armorIndex;
        weaponIndex = data.weaponIndex;

        // Load Helmet
        helmetSpriteRenderer.sprite = spriteHelmets[helmetIndex];

        // Load Armor
        armorSpriteRenderer.sprite = spriteArmors[armorIndex].armorBody;
        armorArmLeftSpriteRenderer.sprite = spriteArmors[armorIndex].armorArmLeft;
        armorArmRightSpriteRenderer.sprite = spriteArmors[armorIndex].armorArmRight;

        // Load Weapon
        weaponSpriteRenderer.sprite = spriteWeapons[weaponIndex];
    }

    #endregion

    void InitializeRenderer()
    {
        hairSpriteRender = GameObject.Find("7_Hair").GetComponent<SpriteRenderer>();

        topBodySpriteRender = GameObject.Find("ClothBody").GetComponent<SpriteRenderer>();
        topLeftSpriteRender = GameObject.Find("21_LCArm").GetComponent<SpriteRenderer>();
        topRightSpriteRender = GameObject.Find("-19_RCArm").GetComponent<SpriteRenderer>();

        pantLeftSpriteRender = GameObject.Find("_2L_Cloth").GetComponent<SpriteRenderer>();
        pantRightSpriteRender = GameObject.Find("_11R_Cloth").GetComponent<SpriteRenderer>();

        armorSpriteRenderer = GameObject.Find("BodyArmor").GetComponent<SpriteRenderer>();
        armorArmLeftSpriteRenderer = GameObject.Find("25_L_Shoulder").GetComponent<SpriteRenderer>();
        armorArmRightSpriteRenderer = GameObject.Find("-15_R_Shoulder").GetComponent<SpriteRenderer>();

        helmetSpriteRenderer = GameObject.Find("11_Helmet1").GetComponent<SpriteRenderer>();

        backSpriteRenderer = GameObject.Find("Back").GetComponent<SpriteRenderer>();

        weaponSpriteRenderer = GameObject.Find("L_Weapon").GetComponent<SpriteRenderer>();
    }
}
