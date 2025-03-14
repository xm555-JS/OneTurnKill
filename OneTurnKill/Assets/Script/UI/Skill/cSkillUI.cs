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

    // skillData가 public인게 마음에 걸리네 이거 skillData를 직렬화로 바꾸고 프로퍼티로 다른 클래스에서 쓸 수 있도록 해야할듯

    public SkillData SkillData { get => skillData; /*set => skillData = value;*/ }

    void Awake()
    {
        skillButton = GetComponent<Button>();

        if (skillEnforceMoving == null)
            skillEnforceMoving = FindObjectOfType<cSkillEnforceMoving>(true);
        if (skillEnforce == null)
            skillEnforce = FindObjectOfType<cSkillEnforce>(true);

        skillButton.onClick.AddListener(() => skillEnforceMoving.MoveToShow());
        skillButton.onClick.AddListener(() => skillEnforce.Initialize(skillData)); // skillEnforce 초기화 함수 실행
    }
}