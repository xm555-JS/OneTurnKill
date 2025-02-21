using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cInven : MonoBehaviour
{
    [Header("Inven")]
    [SerializeField] Image defaultInvenBox;
    [SerializeField] GameObject InvenPrefab;
    cPlayer player;
    cInvenBox[] invenBoxs;

    [Header("Expansion")]
    cExpansion expansion;
    const int maxCount = 4;
    int helmetExpansionCount = 0;
    int armorExpansionCount = 0;
    int weaponExpansionCount = 0;

    void Awake()
    {
        player = GameManager.instance.player.GetComponent<cPlayer>();
        invenBoxs = GetComponentsInChildren<cInvenBox>();
        expansion = GetComponentInParent<cExpansion>();
    }

    #region Inven

    void OnEnable()
    {
        HelmetInven();
    }

    public void HelmetInven()
    {
        InitialInven();
        ReSizeRect(helmetExpansionCount);

        int index = 0;
        foreach (var sprite in player.ReturnHelmetList())
        {
            if (index >= invenBoxs.Length)
                break;

            invenBoxs[index].gameObject.SetActive(true);
            invenBoxs[index].ChangeSprite(sprite);
            index++;
        }
    }

    public void ArmorInven()
    {
        InitialInven();
        ReSizeRect(armorExpansionCount);

        List<Sprite> spriteList = player.ReturnArmorList();

        int index = 0;
        foreach (var sprite in player.ReturnArmorList())
        {
            if (index >= invenBoxs.Length)
                break;

            invenBoxs[index].gameObject.SetActive(true);
            invenBoxs[index].ChangeSprite(sprite);
            index++;
        }
    }

    public void WeaponInven()
    {
        InitialInven();
        ReSizeRect(weaponExpansionCount);

        int index = 0;
        foreach (var sprite in player.ReturnWeaponList())
        {
            if (index > invenBoxs.Length - 1)
                break;

            invenBoxs[index].gameObject.SetActive(true);
            invenBoxs[index].ChangeSprite(sprite);
            index++;
        }
    }

    void InitialInven()
    {
        foreach (var box in invenBoxs)
            box.ChangeSprite(defaultInvenBox.sprite);
    }

    #endregion


    #region Expansion

    public void ExpansionInven(string parts)
    {
        switch (parts)
        {
            case "Helmet":

                if (helmetExpansionCount > maxCount)
                    break;

                helmetExpansionCount++;
                ReSizeRect(helmetExpansionCount);
                break;

            case "Armor":

                if (armorExpansionCount > maxCount)
                    break;

                armorExpansionCount++;
                ReSizeRect(armorExpansionCount);
                break;

            case "Weapon":

                if (weaponExpansionCount > maxCount)
                    break;

                weaponExpansionCount++;
                ReSizeRect(weaponExpansionCount);
                break;
        }
    }

    void ReSizeRect(int expansionCount)
    {
        expansion.RectHeight(expansionCount);
    }

    #endregion
}
