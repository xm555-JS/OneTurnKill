using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cInven : MonoBehaviour
{
    cPlayer player;

    [Header("Inven")]
    [SerializeField] GameObject owner;
    [SerializeField] GameObject invenBox;
    [SerializeField] Text itemCount;
    [SerializeField] GameObject exclamationMark;

    [Header("Expansion")]
    cExpansion expansion;
    int curtInvenAmount;
    int resizeCount;

    [Header("Info")]
    static int id = 0;
    const int defaultSize = 28;
    const int maxtSize = 42;

    void Awake()
    {
        player = GameManager.instance.playerCom;
        expansion = GetComponentInParent<cExpansion>();
    }

    void Start()
    {
        if (owner.name == "Helmet_Inven" || owner.name == "Armor_Inven" || owner.name == "Weapon_Inven")
            LoadItem();
    }

    public void InstItem(cItemData itemData)
    {
        if (itemData == null)
        {
            Debug.LogError("cInven - itemData is null");
            return;
        }
        GameObject invenItem = Instantiate(invenBox);
        invenItem.transform.SetParent(owner.transform, false);
        itemData.ID = id++;
        itemData.owner = invenItem;
        invenItem.GetComponent<cItemUI>().itemboxInitialize(itemData);
        invenItem.GetComponentsInChildren<Image>()[1].sprite = itemData.itemSprite;

        //count
        CheckResize();
        itemCount.text = curtInvenAmount + "/42";
    }

#region Resize
void CheckResize()
{
    curtInvenAmount++;

    if (curtInvenAmount > defaultSize)
    {
        CheckMaxInvenSize();

        resizeCount++;
        int count = (resizeCount / 8) + 1;
        ReSizeRect(count);
    }
}

void CheckMaxInvenSize()
{
    if (curtInvenAmount > maxtSize)
        exclamationMark.SetActive(true);
    else
        exclamationMark.SetActive(false);
}

void ReSizeRect(int expansionCount)
{
    expansion.RectHeight(expansionCount);
}
#endregion

#region Data

void LoadItem()
{
    List<ItemData> dataList = ItemDataManager.instance.LoadItemdata();
    if (dataList == null)
        return;

    foreach (var data in dataList)
    {
        cItemData itemData = ScriptableObject.CreateInstance<cItemData>();
        itemData.type = data.type;
        if (owner.name == "Helmet_Inven")
        {
            if (itemData.type != ItemType.HELMET)
                continue;
        }
        else if (owner.name == "Armor_Inven")
        {
            if (itemData.type != ItemType.ARMOR)
                continue;
        }
        else if (owner.name == "Weapon_Inven")
        {
            if (itemData.type != ItemType.WEAPON)
                continue;
        }

            itemData.ID = data.ID;
            itemData.itemSprite = Resources.Load<Sprite>(data.path);
            itemData.itemName = data.itemName;
            itemData.itemIndex = data.itemIndex;
            itemData.price = data.price;
            itemData.level = data.level;
            itemData.itemStats.att = data.att;
            itemData.itemStats.bossAtt = data.bossAtt;
            itemData.itemStats.criticalChance = data.criticalChance;
            itemData.itemStats.criticalDamage = data.criticalDamage;
            itemData.path = data.path;
            itemData.isInstance = true;
            itemData.isSave = data.isSave;

        GameObject invenItem = Instantiate(invenBox);
        invenItem.transform.SetParent(owner.transform, false);
        itemData.owner = invenItem;
        invenItem.GetComponent<cItemUI>().itemboxInitialize(itemData);
        invenItem.GetComponentsInChildren<Image>()[1].sprite = itemData.itemSprite;

        //count
        CheckResize();
        itemCount.text = curtInvenAmount + "/42";
    }
}

    #endregion

}
