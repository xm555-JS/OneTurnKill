using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cSkillSetting : MonoBehaviour
{
    [Header("Default")]
    [SerializeField] Sprite defaultBtnSprite;

    [Header("Setting")]
    [SerializeField] Button btn1;
    [SerializeField] Button btn2;
    [SerializeField] Button btn3;
    Button[] btnArray;

    [Header("Player_Attack_Btn")]
    [SerializeField] Button playerBtn1;
    [SerializeField] Button playerBtn2;
    [SerializeField] Button playerBtn3;
    Button[] playerBtnArray;

    Dictionary<Button, SkillData> buttonID = new Dictionary<Button, SkillData>();
    Dictionary<Button, Button> buttonPair = new Dictionary<Button, Button>();

    void Awake()
    {
        // initialize
        btnArray = new Button[] { btn1, btn2, btn3 };
        playerBtnArray = new Button[] { playerBtn1, playerBtn2, playerBtn3 };

        for (int i = 0; i < btnArray.Length; i++)
            buttonPair.Add(btnArray[i], playerBtnArray[i]);
    }

    public void Initialize(SkillData skillData)
    {
        foreach (var btn in btnArray)
        {
            btn.onClick.RemoveAllListeners();
            btn.GetComponent<Image>().sprite = defaultBtnSprite;
        }

        foreach (var btn in btnArray)
        {
            btn.onClick.AddListener(() => SetSkillBtn(btn, skillData));
            if (buttonID.ContainsKey(btn))
                btn.GetComponent<Image>().sprite = buttonID[btn].skillSprite;
        }
            
    }

    void SetSkillBtn(Button btn, SkillData skillData)
    {
        DuplicateCheck(btn, skillData);

        // ��ư ����
        btn.GetComponent<Image>().sprite = skillData.skillSprite;
        buttonPair[btn].GetComponent<cPlayerSkillButton>().SkillName(skillData.skillName);
        buttonPair[btn].GetComponent<cPlayerSkillButton>().ChangeImage(skillData.skillSprite);

        ButtonIDRegister(btn, skillData);
    }

    void DuplicateCheck(Button btn, SkillData skillData)
    {
        // ��ų ���� �ߺ� üũ
        foreach (var otherBtn in btnArray)
        {
            if (otherBtn == btn)
                continue;

            if (buttonID.ContainsKey(otherBtn) && skillData == buttonID[otherBtn]) // ���õ� ��ų�߿� �ߺ��� ��ų�� �ִٸ� ��ų ��ư�� �ٲ۴�
            {
                if (buttonID.ContainsKey(btn) == false) // �ٲٷ��� ��ư�� ��ĭ�� ��
                {
                    ChangeButtonInfo(otherBtn, btn);
                    break;
                }
                else // ��ĭ�� �ƴҶ�
                {
                    SkillData preData = buttonID[btn];
                    ChangeButtonInfo(otherBtn, btn, preData);
                    return;
                }
            }
        }
    }

    void ChangeButtonInfo(Button otherbtn, Button btn, SkillData skillData = null)  // ��ų ��ư �ٲٴ� �Լ�
    {
        if (skillData == null)
        {
            otherbtn.GetComponent<Image>().sprite = btn.GetComponent<Image>().sprite;
            buttonPair[otherbtn].GetComponent<cPlayerSkillButton>().SkillName("");
            buttonPair[otherbtn].GetComponent<cPlayerSkillButton>().ChangeImage(defaultBtnSprite);

            ButtonIDRemove(otherbtn);
        }
        else
        {
            otherbtn.GetComponent<Image>().sprite = btn.GetComponent<Image>().sprite;
            buttonPair[otherbtn].GetComponent<cPlayerSkillButton>().SkillName(skillData.skillName);
            buttonPair[otherbtn].GetComponent<cPlayerSkillButton>().ChangeImage(skillData.skillSprite);

            ButtonIDChange(otherbtn, skillData);
        }
    }

    void ButtonIDRegister(Button btn, SkillData data)   // ��ư ���� ���
    {
        if (buttonID.ContainsKey(btn))
            buttonID[btn] = data;
        else
            buttonID.Add(btn, data);
    }

    void ButtonIDRemove(Button btn) { buttonID.Remove(btn); }   // ��ư ���� ����

    void ButtonIDChange(Button btn, SkillData data) { buttonID[btn] = data; }   // ��ư ���� �ٲٱ�
}