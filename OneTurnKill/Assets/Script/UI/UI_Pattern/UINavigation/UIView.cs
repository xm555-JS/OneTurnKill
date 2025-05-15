using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIView : MonoBehaviour
{
    RectTransform rect;

    void Awake()
    {
        rect = this.GetComponent<RectTransform>();
        rect.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f);
    }

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
