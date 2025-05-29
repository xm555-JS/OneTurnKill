using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cAutoButton : MonoBehaviour
{
    [SerializeField] cPlayerSkillButton[] skillBtns;

    Image img;
    Color selectColor = new Color(1f, 1f, 1f, 1f);
    Color nonSelectColor = new Color(1f, 1f, 1f, 0.5f);

    bool isAuto;

    public void ClickAutoBtn()
    {
        if (isAuto)
        {
            isAuto = false;
            StartCoroutine(AutoSKill());
        }
        else
        {
            isAuto = true;
            StopAllCoroutines();
        }
        ChangeBtnAlpha();
        PlayerPrefs.SetInt("isAuto", System.Convert.ToInt32(isAuto));
    }

    void Awake()
    {
        img = GetComponent<Image>();

        isAuto = System.Convert.ToBoolean(PlayerPrefs.GetInt("isAuto", 0));
        ChangeBtnAlpha();
    }

    void OnDisable()
    {
        StopCoroutine(AutoSKill());
    }

    IEnumerator AutoSKill()
    {
        while (true)
        {
            yield return null;
            Debug.Log(isAuto);
            Debug.Log(skillBtns[0].GetIsReadyAuto());
            yield return new WaitUntil(() => isAuto && skillBtns[0].GetIsReadyAuto() == true);

            ChooseSkillBtn();

            yield return new WaitForSeconds(0.3f);
        }
    }

    void ChooseSkillBtn()
    {
        int length = ReturnBtnLength();
        if (length == 0)
            return;

        int index = Random.Range(0, length);
        if (skillBtns[index].skillButton.interactable == true)
            skillBtns[index].skillButton.onClick.Invoke();
    }

    void ChangeBtnAlpha()
    {
        if (isAuto)
        {
            img.color = selectColor;
            StartCoroutine(AutoSKill());
        }
        else
            img.color = nonSelectColor;
    }

    int ReturnBtnLength()
    {
        int length = 0;
        foreach (var btn in skillBtns)
        {
            string skillName = btn.GetSkillName;
            if (skillName == "")
                continue;
            else
                length++;
        }

        return length;
    }
}
