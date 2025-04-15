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
    string[] conditionStr = { "1-7 �������� �Ϸ�� ����", "2-7 �������� �Ϸ�� ����" };

    int bossIndex = 0;

    void Start()
    {
        // ���⼭ UI�� enable�� false�̱� ������ ������ ���۵ǰ� �ش� ui�� ���� �ʴ� �̻� ������ �����ʱ� ������ OpenBossEntry�� ������� �ʾҴ�.
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
        // unity action���� Boss Level�� �̵��ϰ� ��
        bossBtn.onClick.AddListener(() => cPopupManager.instance.Push("MainPopup", "������ �����Ͻðڽ��ϱ�?", () => LevelManager.instance.GoToOrcBossLevel()));
    }

    void BossUISetting(int index)
    {
        bossImg.sprite = bossSprites[index];
        conditionTxt.text = conditionStr[index];
    }

    void OpenBossEntry()
    {
        Debug.Log("���� �ع�!");
        bossBtn.interactable = true;
        rockImg.enabled = false;
    }
}
