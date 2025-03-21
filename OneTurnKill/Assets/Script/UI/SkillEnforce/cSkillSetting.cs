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

        // 정보 저장
        if (buttonID.ContainsKey(btn))
            buttonID[btn] = skillData;
        else
            buttonID.Add(btn, skillData);
    }

    void DuplicateCheck(Button btn, SkillData skillData)
    {
        // 만약 지금 설정하려는 스킬이 다른 칸에 설정되어 있다면
        // 스킬을 서로 바꾼다.
        foreach (var otherBtn in btnArray)
        {
            if (buttonID.ContainsKey(otherBtn))
            {
                // 만약에 btn에 설정하려는 스킬(skillData)이 otherBtn와 같다면
                if (skillData == buttonID[otherBtn])
                {
                    // btn이 empty일 때
                    // otherBtn을 empty로 만든다.
                    if (buttonID.ContainsKey(btn) == false)
                    {
                        otherBtn.GetComponent<Image>().sprite = btn.GetComponent<Image>().sprite;
                        buttonPair[otherBtn].GetComponent<cPlayerSkillButton>().SkillName = "";
                        buttonPair[otherBtn].GetComponent<cPlayerSkillButton>().ChangeImage(defaultBtnSprite);
                        break;
                    }
                    // btn이 설정되어있을 때
                    // otherBtn을 btn에 있는 스킬로 만든다
                    else
                    {
                        otherBtn.GetComponent<Image>().sprite = btn.GetComponent<Image>().sprite;
                        SkillData preData = buttonID[btn];
                        buttonPair[otherBtn].GetComponent<cPlayerSkillButton>().SkillName = preData.skillName;
                        buttonPair[otherBtn].GetComponent<cPlayerSkillButton>().ChangeImage(preData.skillSprite);
                        return;
                        // 이거 원래 같은 스킬을 가지고있는 버튼 하나만 바꿔야하는데
                        // 모든 다른 버튼을 바꿔버려서 고쳐야함.
                    }
                }
            }
        }
    }
}


//if (otherBtn == btn)    // 설정하려는 버튼은 제외
//    continue;
////if (buttonID.ContainsKey(otherBtn) == false)
////    continue;

//if (skillData == buttonID[otherBtn]) // 설정하려는 버튼은 제외하고 나머지 두 버튼 중 같은 스킬이있다면
//{
//    // btn의 셋팅을 skillBtn로 옮기자
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