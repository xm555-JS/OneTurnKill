using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cGachaMove : MonoBehaviour
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

        if (instanceCount > 4)
            instanceCount = 0;
    }

    void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (Vector2.Distance(rect.anchoredPosition, new Vector2(moveX + (400f * count), rect.anchoredPosition.y)) > 0.1f)
        {
            rect.anchoredPosition = Vector2.MoveTowards(rect.anchoredPosition,
                                             new Vector2(moveX + (400f * count), rect.anchoredPosition.y),
                                             Time.deltaTime * 2000f);

            yield return null;
        }

        rect.anchoredPosition = new Vector2(moveX + (400f * count), rect.anchoredPosition.y);
    }

    //void SetPosition(int count)
    //{
    //    rect.anchoredPosition = new Vector2(moveX + (400f * count), rect.anchoredPosition.y);
    //}

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        StopAllCoroutines();
    //        SetPosition(count);
    //    }
    //}
}
