using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cDateTimeBtn : MonoBehaviour
{
    Button btn;
    Image itemImg;

    WaitForSeconds waiting30Sec = new WaitForSeconds(30f);
    WaitForSeconds waitDuplication = new WaitForSeconds(60f);

    Color rockColor = new Color(1f, 1f, 1f, 0.3f);
    Color defaultColor = Color.white;

    public void BuyButton()
    {
        btn.interactable = false;
        SetImgColor();
    }

    void Awake()
    {
        btn = GetComponent<Button>();
        itemImg = GetComponentsInChildren<Image>()[1];

        //test
        //DateTime now = DateTime.Now;
        //Debug.Log(now.Month);
        //Debug.Log(now.Minute);

        CheckOtherDate();

        StartCoroutine(CheckDateTime());
    }

    IEnumerator CheckDateTime()
    {
        while (true)
        {
            DateTime now = DateTime.Now;
            //Debug.Log("cDateTimeBtn : " + now.Minute);
            if (now.Hour == 0 && now.Minute == 34)
            {
                btn.interactable = true;
                SetImgColor();

                yield return waitDuplication;
            }
            yield return waiting30Sec;
            PlayerPrefs.SetInt("Month", now.Month);
            PlayerPrefs.SetInt("Day", now.Day);
        }
    }

    void CheckOtherDate()
    {
        int registerDay = 0;
        int registermonth = 0;

        registerDay = PlayerPrefs.GetInt("day", registerDay);
        registermonth = PlayerPrefs.GetInt("Month", registermonth);

        if (registermonth == 0)
            return;

        DateTime now = DateTime.Now;
        int nowDay = now.Day;
        int nowMonth = now.Month;

        if (nowMonth != registermonth)
            btn.interactable = true;
        else
        {
            if (nowDay != registerDay)
                btn.interactable = true;
            else
                btn.interactable = false;
        }

        SetImgColor();
    }

    void SetImgColor()
    {
        if (btn.interactable)
        {
            itemImg.color = defaultColor;
            PlayerPrefs.SetInt("isInteract" + btn.gameObject.name, 1);
        }
        else
        {
            itemImg.color = rockColor;
            PlayerPrefs.SetInt("isInteract" + btn.gameObject.name, 0);
        }
    }
}
