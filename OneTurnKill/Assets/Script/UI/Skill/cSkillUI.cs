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

    // skillData�� public�ΰ� ������ �ɸ��� �̰� skillData�� ����ȭ�� �ٲٰ� ������Ƽ�� �ٸ� Ŭ�������� �� �� �ֵ��� �ؾ��ҵ�

    public SkillData SkillData { get => skillData; /*set => skillData = value;*/ }

    void Awake()
    {
        skillButton = GetComponent<Button>();

        if (skillEnforceMoving == null)
            skillEnforceMoving = FindObjectOfType<cSkillEnforceMoving>(true);
        if (skillEnforce == null)
            skillEnforce = FindObjectOfType<cSkillEnforce>(true);

        skillButton.onClick.AddListener(() => skillEnforceMoving.MoveToShow());
        skillButton.onClick.AddListener(() => skillEnforce.Initialize(skillData)); // skillEnforce �ʱ�ȭ �Լ� ����
    }
}