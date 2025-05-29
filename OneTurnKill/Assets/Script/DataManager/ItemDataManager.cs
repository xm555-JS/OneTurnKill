using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class ItemData
{
    public int ID;
    public string itemName;
    public ItemType type;
    public int itemIndex;
    public int price;
    public int level;
    public string path;
    public bool isInstance;

    public long att;
    public int bossAtt;
    public int criticalChance;
    public int criticalDamage;
}

[System.Serializable]
public class ItemDataListWrapper
{
    public List<ItemData> Items = new List<ItemData>();
}

public class ItemDataManager : MonoBehaviour
{
    static public ItemDataManager instance;

    string path => Application.persistentDataPath + "/itemdata.json";

    void Awake()
    {
        instance = this;
    }

    public void SaveItemData(ItemData data)
    {
        List<ItemData> itemList = LoadItemdata();
        if (itemList == null)
            itemList = new List<ItemData>();

        itemList.Add(data);

        ItemDataListWrapper wrapper = new ItemDataListWrapper();
        wrapper.Items = itemList;

        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(path, json);
    }

    public List<ItemData> LoadItemdata()
    {
        if (!File.Exists(path))
            return null;

        string json = File.ReadAllText(path);
        ItemDataListWrapper wrapper = JsonUtility.FromJson<ItemDataListWrapper>(json);
        return wrapper.Items;
    }

    public void RewriteItemData(cItemInstance itemData)
    {
        List<ItemData> itemList = LoadItemdata();

        int index = 0;
        foreach (var item in itemList)
        {
            if (item.ID == itemData.ID)
                break;
            index++;
        }

        itemList[index].level = itemData.level;
        itemList[index].att = itemData.itemStats.att;
        itemList[index].bossAtt = itemData.itemStats.bossAtt;
        itemList[index].criticalChance = itemData.itemStats.criticalChance;
        itemList[index].criticalDamage = itemData.itemStats.criticalDamage;

        ItemDataListWrapper wrapper = new ItemDataListWrapper();
        wrapper.Items = itemList;

        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(path, json);
    }
}
