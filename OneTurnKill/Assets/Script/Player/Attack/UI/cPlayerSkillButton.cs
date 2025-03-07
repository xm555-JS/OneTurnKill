using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cPlayerSkillButton : MonoBehaviour
{
    Button skillButton;

    StageManager stageManager;

    cPlayerAttack playerAttack;
    [SerializeField] string skillName;

    void Awake()
    {
        skillButton = GetComponent<Button>();
        skillButton.interactable = false;
    }

    void Start()
    {
        GetPlayerAttack();
        GetStageManager();
        SetAddListner();
    }

    void Update()
    {
        if (stageManager.IsAttackReady)
            skillButton.interactable = true;
        else
            skillButton.interactable = false;
    }

    void GetPlayerAttack()
    {
        playerAttack = GameManager.instance.player.GetComponent<cPlayerAttack>();
        if (!playerAttack)
            Debug.LogError("cPlayerSkillButton - playerAttack is null.");
    }

    void GetStageManager()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
    }

    void SetAddListner()
    {
        skillButton.onClick.AddListener(() => playerAttack.Attack(skillName));
    }
}
