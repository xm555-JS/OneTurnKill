using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cSkillEnforce : MonoBehaviour
{
    [Header("Enforce")]
    [SerializeField] Image skillImg;
    [SerializeField] Text skillName;
    [SerializeField] Text skillAmount;
    [SerializeField] Button enforceBtn;

    //[Header("Setting")]
    //[SerializeField] Button btn1;
    //[SerializeField] Button btn2;
    //[SerializeField] Button btn3;

    //[Header("Player_Attack_Btn")]
    //[SerializeField] Button playerBtn1;
    //[SerializeField] Button playerBtn2;
    //[SerializeField] Button playerBtn3;

    public void Initialize(SkillData skillData)
    {
        // 모든 UI요소 초기화
        enforceBtn.onClick.RemoveAllListeners();

        skillImg.sprite = skillData.skillSprite;
        skillName.text = skillData.skillName;
        skillAmount.text = cSkillManager.instance.ReturnSkillAmount(skillData.skillName) + "/" + skillData.enforceAmount[skillData.level];
        enforceBtn.onClick.AddListener(() => cSkillManager.instance.Enforce(skillData));
        enforceBtn.onClick.AddListener(() => UpdataeUI(skillData));

        //btn1.onClick.AddListener(() => SetSkillBtn(btn1, playerBtn1, skillData));
        //btn2.onClick.AddListener(() => SetSkillBtn(btn2, playerBtn2, skillData));
        //btn3.onClick.AddListener(() => SetSkillBtn(btn3, playerBtn3, skillData));
    }

    public void UpdataeUI(SkillData skillData)
    {
        skillAmount.text = cSkillManager.instance.ReturnSkillAmount(skillData.skillName) + "/" + skillData.enforceAmount[skillData.level];
    }

    //public void SetSkillBtn(Button btn,Button playerBtn, SkillData skillData)
    //{
    //    btn.GetComponent<Image>().sprite = skillData.skillSprite;
    //    playerBtn.GetComponent<cPlayerSkillButton>().SkillName = skillData.skillName;
    //    playerBtn.GetComponent<cPlayerSkillButton>().ChangeImage(skillData.skillSprite);
    //}
}
