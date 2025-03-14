using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cSkillSetting : MonoBehaviour
{
    [Header("Default")]
    [SerializeField] Sprite defaultSprite;

    [Header("Setting")]
    [SerializeField] Button btn1;
    [SerializeField] Button btn2;
    [SerializeField] Button btn3;
    Button[] btnArray;

    [Header("Player_Attack_Btn")]
    [SerializeField] Button playerBtn1;
    [SerializeField] Button playerBtn2;
    [SerializeField] Button playerBtn3;

    Dictionary<Button, SkillData> buttonID = new Dictionary<Button, SkillData>();

    void Awake()
    {
        btnArray = new Button[]{ btn1, btn2, btn3 };
    }

    public void Initialize(SkillData skillData)
    {
        btn1.onClick.AddListener(() => SetSkillBtn(btn1, playerBtn1, skillData));
        btn2.onClick.AddListener(() => SetSkillBtn(btn2, playerBtn2, skillData));
        btn3.onClick.AddListener(() => SetSkillBtn(btn3, playerBtn3, skillData));
    }

    public void SetSkillBtn(Button btn, Button playerBtn, SkillData skillData)
    {
        btn.GetComponent<Image>().sprite = skillData.skillSprite;
        playerBtn.GetComponent<cPlayerSkillButton>().SkillName = skillData.skillName;
        playerBtn.GetComponent<cPlayerSkillButton>().ChangeImage(skillData.skillSprite);
    }
    
    void DuplicateCheck(Button btn, SkillData skillData)
    {
        foreach (var skillBtn in btnArray)
        {
            if (skillBtn == btn)
                continue;

            if (skillData.skillSprite == skillBtn.GetComponent<Image>().sprite)
            {
                //Sprite tempSprite = null;
                //skillBtn.GetComponent<Image>().sprite = defaultSprite;
                // ������ �÷��̾� ��ų ��ư�� ���� �ٲ���
            }
        }
    }

    // �̰� ��ųâ ��ư�� �ٲٸ� �ڵ����� �÷��̾� ��ų�� �ٲٰ��ؾ��Ұ� ������
}
