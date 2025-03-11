using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkillEnforceMoving : MonoBehaviour
{
    RectTransform rect;

    Vector2 startVec = new Vector2(2400f, 0f);
    Vector2 destinationVec = new Vector2(0f, 0f);
    float moveSpeed = 500f;

    bool isShow;
    bool isHide;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        if (isShow)
            rect.anchoredPosition = Vector2.MoveTowards(startVec, destinationVec, Time.deltaTime * moveSpeed);
        else if (isHide)
            rect.anchoredPosition = Vector2.MoveTowards(destinationVec, startVec, Time.deltaTime * moveSpeed);
    }

    public void startShow() { isHide = false; isShow = true; }
    public void startHide() { isShow = false; isHide = true; }
}
