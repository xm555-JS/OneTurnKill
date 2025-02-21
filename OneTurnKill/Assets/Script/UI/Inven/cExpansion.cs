using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cExpansion : MonoBehaviour
{
    //cInven inven;
    RectTransform rectTransform;

    void Awake()
    {
        //inven = GetComponentInChildren<cInven>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void RectHeight(int count)
    {
        if (count >= 4)
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 1600f);
        else
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 800f + (180f * count));
    }

    //int expansionCount;
    //static int maxInvenExpansionCount = 4;

    //int helmet;
    //int armor;
    //int weapon;

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.B))
    //        expansion("Helmet");
    //    else if (Input.GetKeyDown(KeyCode.N))
    //        expansion("Armor");
    //    else if (Input.GetKeyDown(KeyCode.M))
    //        expansion("Weapon");
    //}

    //public void expansion(string part)
    //{
    //    // 이 코드 Inven class로 ㄱㄱ
    //    if (expansionCount > maxInvenExpansionCount)
    //        return;

    //    expansionCount++;

    //    switch (part)
    //    {
    //        case "Helmet":
    //            helmet++;
    //            break;
    //        case "Armor":
    //            armor++;
    //            break;
    //        case "Weapon":
    //            weapon++;
    //            break;
    //    }
    //}

    //public void CheckExpansion(string part)
    //{
    //    // 현재 어느 정도로 확장이 됐는지 확인
    //    StartCoroutine(IExpansion(part));
    //}

    //IEnumerator IExpansion(string part)
    //{
    //    yield return null;

    //    switch (part)
    //    {
    //        case "Helmet":
    //            for (int i = 0; i < helmet; i++)
    //            {
    //                inven.Expansion_Inven();
    //            }
    //            RectHeight(helmet);
    //            break;
    //        case "Armor":
    //            for (int i = 0; i < armor; i++)
    //            {
    //                inven.Expansion_Inven();
    //            }
    //            RectHeight(armor);
    //            break;
    //        case "Weapon":
    //            for (int i = 0; i < weapon; i++)
    //            {
    //                inven.Expansion_Inven();
    //            }
    //            RectHeight(weapon);
    //            break;
    //    }
    //}

}
