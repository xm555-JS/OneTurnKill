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
        PlayerPrefs.SetString(gameObject.name + "Sprite", image.name);
        skillButton.GetComponent<Image>().sprite = image;
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
