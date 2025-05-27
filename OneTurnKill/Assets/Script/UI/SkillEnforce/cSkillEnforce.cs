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

    public void Initialize(SkillData skillData)
    {
        // 모든 UI요소 초기화
        enforceBtn.onClick.RemoveAllListeners();

        skillImg.sprite = skillData.skillSprite;
        skillName.text = skillData.skillName;
        skillAmount.text = cSkillManager.instance.ReturnSkillAmount(skillData.skillName) + "/" + skillData.enforceAmount[skillData.level];
        enforceBtn.onClick.AddListener(() => cSkillManager.instance.Enforce(skillData));
        enforceBtn.onClick.AddListener(() => UpdataeUI(skillData));
        enforceBtn.onClick.AddListener(() => AudioManager.instance.PlayerSfx(AudioManager.Sfx.ENFORCE));
    }

    public void UpdataeUI(SkillData skillData)
    {
        skillAmount.text = cSkillManager.instance.ReturnSkillAmount(skillData.skillName) + "/" + skillData.enforceAmount[skillData.level];
    }
}
