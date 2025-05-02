using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cPlayerSkillButton : MonoBehaviour
{
    Button skillButton;

    StageManager stageManager;
    BossStageManager bossStageManager;

    cPlayerAttack playerAttack;
    [SerializeField] string skillName;

    public string SkillName { set => skillName = value; }

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
        if (stageManager != null)
        {
            if (stageManager.IsAttackReady)
                skillButton.interactable = true;
            else
                skillButton.interactable = false;
        }
        else if (bossStageManager != null)
        {
            if (bossStageManager.IsAttackReady)
                skillButton.interactable = true;
            else
                skillButton.interactable = false;
        }
    }

    void GetPlayerAttack()
    {
        playerAttack = GameManager.instance.player.GetComponent<cPlayerAttack>();
        if (!playerAttack)
            Debug.LogError("cPlayerSkillButton - playerAttack is null.");
    }

    void GetStageManager()
    {
        string SceneName = LevelManager.instance.ReturnCurLevel();
        if (SceneName == "1SampleScene")
            stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        if (SceneName == "2OrcBossLevel")
            bossStageManager = GameObject.Find("BossStageManager").GetComponent<BossStageManager>();
    }

    void SetAddListner()
    {
        skillButton.onClick.AddListener(() => playerAttack.Attack(skillName));
    }

    public void ChangeImage(Sprite image)
    {
        skillButton.GetComponent<Image>().sprite = image;
    }
}
