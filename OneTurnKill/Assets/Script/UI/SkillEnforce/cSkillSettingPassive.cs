using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cSkillSettingPassive : MonoBehaviour
{
    [Header("Default")]
    [SerializeField] Sprite defaultBtnSprite;

    [Header("Setting")]
    [SerializeField] Button btn1;
    [SerializeField] Button btn2;
    [SerializeField] Button btn3;
    Button[] btnArray;

    Dictionary<Button, SkillData> buttonID = new Dictionary<Button, SkillData>();

    void Awake()
    {
        // initialize
        btnArray = new Button[] { btn1, btn2, btn3 };
    }

    public void Initialize(SkillData skillData)
    {
        foreach (var btn in btnArray)
            btn.onClick.RemoveAllListeners();

        foreach (var btn in btnArray)
            btn.onClick.AddListener(() => SetSkillBtn(btn, skillData));
    }

    public void SetSkillBtn(Button btn, SkillData skillData)
    {
        DuplicateCheck(btn, skillData);

        // 버튼 셋팅
        btn.GetComponent<Image>().sprite = skillData.skillSprite;

        ButtonIDRegister(btn, skillData);
    }

    void DuplicateCheck(Button btn, SkillData skillData)
    {
        // 스킬 셋팅 중복 체크
        foreach (var otherBtn in btnArray)
        {
            if (otherBtn == btn)
                continue;

            if (buttonID.ContainsKey(otherBtn) && skillData == buttonID[otherBtn]) // 셋팅된 스킬중에 중복된 스킬이 있다면 스킬 버튼을 바꾼다
            {
                if (buttonID.ContainsKey(btn) == false) // 바꾸려는 버튼이 빈칸일 때
                {
                    ChangeButtonInfo(otherBtn, btn);
                    break;
                }
                else // 빈칸이 아닐때
                {
                    SkillData preData = buttonID[btn];
                    ChangeButtonInfo(otherBtn, btn, preData);
                    return;
                }
            }
        }
    }

    void ChangeButtonInfo(Button otherbtn, Button btn, SkillData skillData = null)  // 스킬 버튼 바꾸는 함수
    {
        if (skillData == null)
        {
            otherbtn.GetComponent<Image>().sprite = btn.GetComponent<Image>().sprite;
            ButtonIDRemove(otherbtn);
        }
        else
        {
            otherbtn.GetComponent<Image>().sprite = btn.GetComponent<Image>().sprite;
            ButtonIDChange(otherbtn, skillData);
        }
    }

    void ButtonIDRegister(Button btn, SkillData data)   // 버튼 정보 등록
    {
        if (buttonID.ContainsKey(btn))
            buttonID[btn] = data;
        else
            buttonID.Add(btn, data);
    }

    void ButtonIDRemove(Button btn) { buttonID.Remove(btn); }   // 버튼 정보 삭제

    void ButtonIDChange(Button btn, SkillData data) { buttonID[btn] = data; }   // 버튼 정보 바꾸기
}
