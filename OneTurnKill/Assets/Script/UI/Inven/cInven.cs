using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cInven : MonoBehaviour
{
    [Header("Inven")]
    //[SerializeField] GameObject armorPrefabBox;
    //[SerializeField] GameObject weaponPrefabBox;
    //[SerializeField] GameObject helmetOwner;
    //[SerializeField] GameObject armorOwner;
    //[SerializeField] GameObject weaponOwner;
    [SerializeField] GameObject owner;
    [SerializeField] GameObject invenBox;
    [SerializeField] Text itemCount;
    [SerializeField] GameObject exclamationMark;

    cPlayer player;

    [Header("Expansion")]
    cExpansion expansion;
    int curtInvenAmount;
    int resizeCount;

    void Awake()
    {
        player = GameManager.instance.player.GetComponent<cPlayer>();
        expansion = GetComponentInParent<cExpansion>();
    }

    // 아이템을 인스턴스한다.
    // 인스턴스 된 아이템은
    // 1. cInven컴포넌트를 가지고 있는 객체를 부모로 한다.
    // 2. 인스턴스 된 아이템 안에 있는 Image 컴포넌트에 접근하여 습득한 아이템의 이미지로 바꾼다.
    // 3. 버튼 컴포넌트에 접근하여 해당 아이템의 능력치를 플레이어에게 줄 수 있도록 한다.
    public void InstItem(cItemData itemData)
    {
        if (itemData == null)
        {
            Debug.LogError("cInven - itemData is null");
            return;
        }
        GameObject invenItem = Instantiate(invenBox);
        invenItem.transform.SetParent(owner.transform, false);
        invenItem.GetComponentsInChildren<Image>()[1].sprite = itemData.itemSprite;
        invenItem.GetComponent<Button>().onClick.AddListener(() => player.WearItem(itemData));

        //count
        CheckResize();
        itemCount.text = curtInvenAmount + "/42";
    }

    void CheckResize()
    {
        curtInvenAmount++;

        if (curtInvenAmount > 28)
        {
            CheckMaxInvenSize();

            resizeCount++;
            int count = (resizeCount / 8) + 1;
            ReSizeRect(count);
        }
    }

    void CheckMaxInvenSize()
    {
        if (curtInvenAmount > 42)
            exclamationMark.SetActive(true);
        else
            exclamationMark.SetActive(false);
    }

    void ReSizeRect(int expansionCount)
    {
        expansion.RectHeight(expansionCount);
    }

    //cItemData itemData = item.GetComponent<cItemData>();
    //if (itemData == null)
    //{
    //    Debug.LogError("cInven - itemData is null");
    //    return;
    //}
    //switch (itemData.type)
    //{
    //    case ItemType.HELMET:
    //        GameObject helmet = Instantiate(armorPrefabBox);
    //        helmet.transform.SetParent(helmetOwner.transform, false);
    //        helmet.GetComponentsInChildren<Image>()[1].sprite = itemData.itemSprite;
    //        helmet.GetComponent<Button>().onClick.AddListener(() => player.WearHelmet(itemData.itemIndex));
    //        break;
    //    case ItemType.ARMOR:
    //        GameObject armor = Instantiate(armorPrefabBox);
    //        armor.transform.SetParent(armorOwner.transform, false);
    //        armor.GetComponentsInChildren<Image>()[1].sprite = itemData.itemSprite;
    //        armor.GetComponent<Button>().onClick.AddListener(() => player.WearArmor(itemData.itemIndex));
    //        break;
    //    case ItemType.WEAPON:
    //        GameObject weapon = Instantiate(armorPrefabBox);
    //        weapon.transform.SetParent(weaponOwner.transform, false);
    //        weapon.GetComponentsInChildren<Image>()[1].sprite = itemData.itemSprite;
    //        weapon.GetComponent<Button>().onClick.AddListener(() => player.EquipWeapon(itemData.itemIndex));
    //        break;
    //    default:
    //        break;
    //}








    //#region Inven

    //void OnEnable()
    //{
    //    HelmetInven();
    //}

    //public void HelmetInven()
    //{
    //    InitialInven();
    //    ReSizeRect(helmetExpansionCount);

    //    int index = 0;
    //    foreach (var sprite in player.ReturnHelmetList())
    //    {
    //        if (index >= invenBoxs.Length)
    //            break;

    //        invenBoxs[index].gameObject.SetActive(true);
    //        invenBoxs[index].ChangeSprite(sprite);
    //        index++;
    //    }
    //}

    //public void ArmorInven()
    //{
    //    InitialInven();
    //    ReSizeRect(armorExpansionCount);

    //    List<Sprite> spriteList = player.ReturnArmorList();

    //    int index = 0;
    //    foreach (var sprite in player.ReturnArmorList())
    //    {
    //        if (index >= invenBoxs.Length)
    //            break;

    //        invenBoxs[index].gameObject.SetActive(true);
    //        invenBoxs[index].ChangeSprite(sprite);
    //        index++;
    //    }
    //}

    //public void WeaponInven()
    //{
    //    InitialInven();
    //    ReSizeRect(weaponExpansionCount);

    //    int index = 0;
    //    foreach (var sprite in player.ReturnWeaponList())
    //    {
    //        if (index > invenBoxs.Length - 1)
    //            break;

    //        invenBoxs[index].gameObject.SetActive(true);
    //        invenBoxs[index].ChangeSprite(sprite);
    //        index++;
    //    }
    //}

    //void InitialInven()
    //{
    //    //foreach (var box in invenBoxs)
    //    //    box.ChangeSprite(defaultInvenBox.sprite);
    //}

    //#endregion


    //#region Expansion

    //public void ExpansionInven(string parts)
    //{
    //    switch (parts)
    //    {
    //        case "Helmet":

    //            if (helmetExpansionCount > maxCount)
    //                break;

    //            helmetExpansionCount++;
    //            ReSizeRect(helmetExpansionCount);
    //            break;

    //        case "Armor":

    //            if (armorExpansionCount > maxCount)
    //                break;

    //            armorExpansionCount++;
    //            ReSizeRect(armorExpansionCount);
    //            break;

    //        case "Weapon":

    //            if (weaponExpansionCount > maxCount)
    //                break;

    //            weaponExpansionCount++;
    //            ReSizeRect(weaponExpansionCount);
    //            break;
    //    }
    //}

    //#endregion
}
