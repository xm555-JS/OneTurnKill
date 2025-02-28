using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelect : MonoBehaviour
{
    // 그룹중 하나를 선택하면 나머지는 원래대로 돌아오고 선택된 객체는 이미지와 글자의 색상이 변경된다.
    [SerializeField] GameObject[] ownerMenuUI;
    [SerializeField] GameObject[] othderMenuUI;
    [SerializeField] GameObject[] othderMenu;
    [SerializeField] Sprite selectedImg;
    [SerializeField] Sprite normalImg;

    Image buttonImg;
    Text buttonTxt;

    Color selectedColor = new Color(0.2f, 0.2f, 0.2f);
    Color nonSelectedColor = new Color(1f, 1f, 1f);

    protected virtual void Awake()
    {
        buttonImg = this.GetComponent<Image>();
        buttonTxt = this.GetComponentInChildren<Text>();
    }

    #region normal_Select
    public void Seleted()
    {
        foreach (var ownerUI in ownerMenuUI)
            ownerUI.SetActive(true);

        foreach (var menu in othderMenuUI)
            menu.SetActive(false);
        foreach (var menu in othderMenu)
            menu.GetComponent<MenuSelect>().NonSeleted();

        buttonImg.enabled = true;
        buttonImg.sprite = selectedImg;
        buttonTxt.color = selectedColor;
    }
    void NonSeleted()
    {
        buttonImg.sprite = normalImg;
        buttonTxt.color = nonSelectedColor;
    }

    #endregion

    #region Shop_Select
    public void ShopSeleted()
    {
        foreach (var ownerUI in ownerMenuUI)
            ownerUI.SetActive(true);

        foreach (var menu in othderMenuUI)
            menu.SetActive(false);
        foreach (var menu in othderMenu)
            menu.GetComponent<MenuSelect>().ShopNonSeleted();

        buttonImg.enabled = true;
        buttonImg.sprite = selectedImg;
        buttonTxt.color = selectedColor;
    }

    void ShopNonSeleted()
    {
        buttonImg.sprite = null;
        buttonImg.enabled = false;
        buttonTxt.color = nonSelectedColor;
    }
    #endregion
}
