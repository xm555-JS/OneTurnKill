using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cItemUI : MonoBehaviour
{
    static cItemEnforceMoving itemEnforceMoving;
    static cItemEnforce itemEnforce;
    static cItemUI itemUI;
    Button btn;

    public void itemboxInitialize(cItemData itemData)
    {
        if (itemEnforceMoving == null)
            itemEnforceMoving = FindObjectOfType<cItemEnforceMoving>(true);
        if (itemEnforce == null)
            itemEnforce = FindObjectOfType<cItemEnforce>(true);

        itemUI = GetComponent<cItemUI>();
        btn = GetComponent<Button>();

        btn.onClick.AddListener(() => itemEnforceMoving.MoveToShow());
        btn.onClick.AddListener(() => itemEnforce.Initialize(itemData));
    }
}
