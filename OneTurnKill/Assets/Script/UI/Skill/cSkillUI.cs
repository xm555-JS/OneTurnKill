using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cSkillUI : MonoBehaviour
{
    [SerializeField] SkillData skillData;

    Button skillButton;

    static cSkillEnforceMoving skillEnforceMoving;
    static cSkillEnforce skillEnforce;
    static cSkillSetting skillSetting;

    public SkillData SkillData { get => skillData; /*set => skillData = value;*/ }

    void Awake()
    {
        skillButton = GetComponent<Button>();

        if (skillEnforceMoving == null)
            skillEnforceMoving = FindObjectOfType<cSkillEnforceMoving>(true);
        if (skillEnforce == null)
            skillEnforce = FindObjectOfType<cSkillEnforce>(true);
        if (skillSetting == null)
            skillSetting = FindObjectOfType<cSkillSetting>(true);

        skillButton.onClick.AddListener(() => skillEnforceMoving.MoveToShow());
        skillButton.onClick.AddListener(() => skillEnforce.Initialize(skillData));
        skillButton.onClick.AddListener(() => skillSetting.Initialize(skillData));
    }
}