using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cBossUIBtn : MonoBehaviour
{
    [SerializeField] Button bossBtn;
    [SerializeField] Image bossImg;
    [SerializeField] Image rockImg;

    [SerializeField] Sprite[] bossSprites;

    [SerializeField] Text conditionTxt;
    string[] conditionStr = { "1-7 스테이지 완료시 개방", "2-7 스테이지 완료시 개방" };

    int bossIndex = 0;

    void Start()
    {
        // 여기서 UI의 enable이 false이기 때문에 게임이 시작되고 해당 ui를 켜지 않는 이상 구독이 되지않기 때문에 OpenBossEntry이 실행되지 않았다.
        StageManager.instance.OnOpenOrcBoss += OpenBossEntry;
        if (StageManager.instance == null)
            Debug.Log("instance is null");
    }

    //void OnDisable()
    //{
    //    StageManager.instance.OnOpenOrcBoss -= OpenBossEntry;
    //}

    public void NextBoss()
    {
        bossIndex++;
        if (bossIndex > bossSprites.Length - 1)
        {
            bossIndex--;
            return;
        }
            BossUISetting(bossIndex);
    }

    public void PreBoss()
    {
        bossIndex--;
        if (bossIndex < 0)
        {
            bossIndex++;
            return;
        }
            
        BossUISetting(bossIndex);
    }

    void Awake()
    {
        // unity action으로 Boss Level로 이동하게 끔
        bossBtn.onClick.AddListener(() => cPopupManager.instance.Push("MainPopup", "보스에 입장하시겠습니까?", () => LevelManager.instance.GoToOrcBossLevel()));
    }

    void BossUISetting(int index)
    {
        bossImg.sprite = bossSprites[index];
        conditionTxt.text = conditionStr[index];
    }

    void OpenBossEntry()
    {
        Debug.Log("보스 해방!");
        bossBtn.interactable = true;
        rockImg.enabled = false;
    }
}
