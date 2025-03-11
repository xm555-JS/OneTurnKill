using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cSkillUI : MonoBehaviour
{
    public SkillData skillData;

    Button skillButton;

    //static cSkillEnforceMoving skillEnforce;
    static GameObject skillEnforce;
    bool isInitial;

    void OnEnable()
    {
        if (!isInitial)
        {
            skillEnforce = GameObject.Find("SkillEnforce");
            cSkillEnforceMoving skillMoving = skillEnforce.GetComponent<cSkillEnforceMoving>();
            skillButton.onClick.AddListener(() => skillMoving.startShow());
            isInitial = true;
        }
    }

    void Awake()
    {
        skillButton = GetComponent<Button>();
        //.GetComponent<cSkillEnforceMoving>();
    }

    //void Start()
    //{
        
    //}
}
