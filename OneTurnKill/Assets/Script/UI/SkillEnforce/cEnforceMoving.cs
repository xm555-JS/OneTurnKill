using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cEnforceMoving : MonoBehaviour
{
    RectTransform rect;

    Vector2 targetVec = new Vector2(0f, 0f);
    Vector2 originVec = new Vector2(3000f, 0f);
    public float moveSpeed = 8000f;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public void MoveToShow()
    {
        StopAllCoroutines();
        StartCoroutine(Show());
    }

    public void MoveToHide()
    {
        StopAllCoroutines();
        StartCoroutine(Hide());
    }

    IEnumerator Show()
    {
        while (Vector2.Distance(rect.anchoredPosition, targetVec) > 0.1f)
        {
            rect.anchoredPosition = Vector2.MoveTowards(rect.anchoredPosition, targetVec, Time.deltaTime * moveSpeed);  // 2400 -> 0
            yield return null;
        }

        rect.anchoredPosition = targetVec;
    }

    IEnumerator Hide()
    {
        while (Vector2.Distance(rect.anchoredPosition, originVec) > 0.1f)
        {
            rect.anchoredPosition = Vector2.MoveTowards(rect.anchoredPosition, originVec, Time.deltaTime * moveSpeed);  // 0 -> 2400
            yield return null;
        }

        rect.anchoredPosition = originVec;
    }
}
