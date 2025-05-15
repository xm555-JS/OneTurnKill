using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cPlayerSkillButton : MonoBehaviour
{
    public Button skillButton;

    [SerializeField] string skillName;
    
    cPlayerAttack playerAttack;

    static bool isReadyAuto;

    static StageManager stageManager;
    static BossStageManager bossStageManager;

    public string GetSkillName { get => skillName;}
    public bool GetIsReadyAuto() { return isReadyAuto; }

    public void ChangeImage(Sprite image)
    {
        PlayerPrefs.SetString(gameObject.name + "Sprite", image.name);
        skillButton.GetComponent<Image>().sprite = image;
    }

    public void SkillName(string name)
    {
        PlayerPrefs.SetInt("Save" + gameObject.name, 1);
        PlayerPrefs.SetString(gameObject.name, name);
        skillName = name;
    }

    void Awake()
    {
        skillButton = GetComponent<Button>();
        skillButton.interactable = false;
        LoadData();
    }

    void Start()
    {
        GetPlayerAttack();
        GetStageManager();
        SetAddListner();
    }

    void Update()
    {
        bool isReady = false;
        if (stageManager != null && stageManager.IsAttackReady)
            isReady = true;
        if (bossStageManager != null && bossStageManager.IsAttackReady)
            isReady = true;

        if (isReady)
        {
            skillButton.interactable = true;
            isReadyAuto = true;
        }
        else
        {
            skillButton.interactable = false;
            isReadyAuto = false;
        }
            
    }

    void GetPlayerAttack()
    {
        playerAttack = GameManager.instance.playerAttack;
        if (!playerAttack)
            Debug.LogError("cPlayerSkillButton - playerAttack is null.");
    }

    void GetStageManager()
    {
        string SceneName = LevelManager.instance.ReturnCurLevel();
        if (SceneName == "1SampleScene" && stageManager == null)
            stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        if (SceneName == "2OrcBossLevel" && stageManager == null)
            bossStageManager = GameObject.Find("BossStageManager").GetComponent<BossStageManager>();
    }

    public void SetAddListner()
    {
        skillButton.onClick.AddListener(() => Attack());
    }

    void Attack()
    {
        playerAttack.Attack(skillName);
    }

    void LoadData()
    {
        bool isSave = System.Convert.ToBoolean(PlayerPrefs.GetInt("Save" + gameObject.name));
        if (isSave)
        {
            skillName = PlayerPrefs.GetString(gameObject.name);

            Sprite[] sprites = Resources.LoadAll<Sprite>("UI/Skill_Icon");
            FindButtonImage(sprites);

        }
    }

    void FindButtonImage(Sprite[] sprites)
    {
        string spriteName = PlayerPrefs.GetString(gameObject.name + "Sprite");
        foreach (var sprite in sprites)
        {
            if (sprite.name == spriteName)
                skillButton.GetComponent<Image>().sprite = sprite;
        }
    }
}
