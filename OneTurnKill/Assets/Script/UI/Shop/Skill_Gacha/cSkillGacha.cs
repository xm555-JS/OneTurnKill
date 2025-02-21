using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkillGacha : MonoBehaviour
{
    [Header("Component")]
    RectTransform rect;

    [Header("Position")]
    const float moveX = -800f;

    [Header("Count")]
    static int instanceCount;
    int count;

    void Awake()
    {
        rect = GetComponent<RectTransform>();

        count = instanceCount;
        instanceCount++;

        if (instanceCount >= 6)
            instanceCount = 0;
    }

    void LateUpdate()
    {
        rect.anchoredPosition = Vector2.MoveTowards(rect.anchoredPosition,
                                                    new Vector2(moveX + (400f * count), rect.anchoredPosition.y),
                                                    Time.deltaTime * 2000f);
    }
}
