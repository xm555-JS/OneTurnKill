using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cInven : MonoBehaviour
{
    [Header("Inven")]
    [SerializeField] GameObject owner;
    [SerializeField] GameObject invenBox;
    [SerializeField] Text itemCount;
    [SerializeField] GameObject exclamationMark;

    cPlayer player;

    [Header("Expansion")]
    cExpansion expansion;
    int curtInvenAmount;
    int resizeCount;

    const int defaultSize = 28;
    const int maxtSize = 42;

    void Awake()
    {
        player = GameManager.instance.player.GetComponent<cPlayer>();
        expansion = GetComponentInParent<cExpansion>();
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
        itemData.owner = invenItem;
        invenItem.GetComponent<cItemUI>().itemboxInitialize(itemData);
        invenItem.GetComponentsInChildren<Image>()[1].sprite = itemData.itemSprite;

        //count
        CheckResize();
        itemCount.text = curtInvenAmount + "/42";
    }

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
}
