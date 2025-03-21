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
            btn.onClick.RemoveAllListeners();

        foreach (var btn in btnArray)
            btn.onClick.AddListener(() => SetSkillBtn(btn, skillData));
    }

    public void SetSkillBtn(Button btn, SkillData skillData)
    {
        DuplicateCheck(btn, skillData);

        btn.GetComponent<Image>().sprite = skillData.skillSprite;
        buttonPair[btn].GetComponent<cPlayerSkillButton>().SkillName = skillData.skillName;
        buttonPair[btn].GetComponent<cPlayerSkillButton>().ChangeImage(skillData.skillSprite);

        // ���� ����
        if (buttonID.ContainsKey(btn))
            buttonID[btn] = skillData;
        else
            buttonID.Add(btn, skillData);
    }

    void DuplicateCheck(Button btn, SkillData skillData)
    {
        // ���� ���� �����Ϸ��� ��ų�� �ٸ� ĭ�� �����Ǿ� �ִٸ�
        // ��ų�� ���� �ٲ۴�.
        foreach (var otherBtn in btnArray)
        {
            if (buttonID.ContainsKey(otherBtn))
            {
                // ���࿡ btn�� �����Ϸ��� ��ų(skillData)�� otherBtn�� ���ٸ�
                if (skillData == buttonID[otherBtn])
                {
                    // btn�� empty�� ��
                    // otherBtn�� empty�� �����.
                    if (buttonID.ContainsKey(btn) == false)
                    {
                        otherBtn.GetComponent<Image>().sprite = btn.GetComponent<Image>().sprite;
                        buttonPair[otherBtn].GetComponent<cPlayerSkillButton>().SkillName = "";
                        buttonPair[otherBtn].GetComponent<cPlayerSkillButton>().ChangeImage(defaultBtnSprite);
                        break;
                    }
                    // btn�� �����Ǿ����� ��
                    // otherBtn�� btn�� �ִ� ��ų�� �����
                    else
                    {
                        otherBtn.GetComponent<Image>().sprite = btn.GetComponent<Image>().sprite;
                        SkillData preData = buttonID[btn];
                        buttonPair[otherBtn].GetComponent<cPlayerSkillButton>().SkillName = preData.skillName;
                        buttonPair[otherBtn].GetComponent<cPlayerSkillButton>().ChangeImage(preData.skillSprite);
                        return;
                        // �̰� ���� ���� ��ų�� �������ִ� ��ư �ϳ��� �ٲ���ϴµ�
                        // ��� �ٸ� ��ư�� �ٲ������ ���ľ���.
                    }
                }
            }
        }
    }
}


//if (otherBtn == btn)    // �����Ϸ��� ��ư�� ����
//    continue;
////if (buttonID.ContainsKey(otherBtn) == false)
////    continue;

//if (skillData == buttonID[otherBtn]) // �����Ϸ��� ��ư�� �����ϰ� ������ �� ��ư �� ���� ��ų���ִٸ�
//{
//    // btn�� ������ skillBtn�� �ű���
//    otherBtn.GetComponent<Image>().sprite = btn.GetComponent<Image>().sprite;

//    if (buttonID.ContainsKey(otherBtn))
//    {
//        SkillData preData = buttonID[btn];
//        buttonPair[btn].GetComponent<cPlayerSkillButton>().SkillName = preData.skillName;
//        buttonPair[btn].GetComponent<cPlayerSkillButton>().ChangeImage(preData.skillSprite);
//    }
//    else
//    {
//        buttonPair[btn].GetComponent<cPlayerSkillButton>().SkillName = "";
//        buttonPair[btn].GetComponent<cPlayerSkillButton>().ChangeImage(defaultBtnSprite);
//    }
//}