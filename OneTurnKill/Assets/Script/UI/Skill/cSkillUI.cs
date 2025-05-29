using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cSkillUI : MonoBehaviour
{
    [SerializeField] SkillData skillData;

    Button skillButton;

    static cEnforceMoving skillEnforceMoving;
    static cSkillEnforce skillEnforce;
    static cSkillSetting skillSetting;
    static cPassiveSkillSetting passiveSetting;

    public SkillData SkillData { get => skillData; }

    void Awake()
    {
        skillButton = GetComponent<Button>();

        if (skillEnforceMoving == null)
            skillEnforceMoving = FindObjectOfType<cEnforceMoving>(true);
        if (skillEnforce == null)
            skillEnforce = FindObjectOfType<cSkillEnforce>(true);
        if (passiveSetting == null)
            passiveSetting = FindObjectOfType<cPassiveSkillSetting>(true);

        if (skillSetting == null && skillData.skillType == SkillType.ACTIVE)
            skillSetting = FindObjectOfType<cSkillSetting>(true);
        else if (passiveSetting == null && skillData.skillType == SkillType.PASSIVE)
            passiveSetting = FindObjectOfType<cPassiveSkillSetting>(true);

        skillButton.onClick.AddListener(() => skillEnforceMoving.MoveToShow());
        skillButton.onClick.AddListener(() => skillEnforce.Initialize(skillData));

        if (skillData.skillType == SkillType.ACTIVE)
            skillButton.onClick.AddListener(() => skillSetting.Initialize(skillData));
        else if (skillData.skillType == SkillType.PASSIVE)
            skillButton.onClick.AddListener(() => passiveSetting.Initialize(skillData));

        skillButton.onClick.AddListener(() => AudioManager.instance.PlayerSfx(AudioManager.Sfx.CLICK));
    }
}