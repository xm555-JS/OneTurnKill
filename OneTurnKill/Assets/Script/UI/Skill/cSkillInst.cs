using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0414

public class cSkillInst : MonoBehaviour
{
    // inven류의 UI에서 객체를 계속 생성할 때 
    [Header("Owner")]
    [SerializeField] GameObject activeOwner;
    [SerializeField] GameObject passiveOwner;

    [Header("Skill")]
    [SerializeField] GameObject[] rSkill;
    [SerializeField] GameObject[] srSkill;
    [SerializeField] GameObject[] ssrSkill;


    // Shop SKill UI Instantiate
    enum GACHASTATE { STAY, START, ING, END }
    GACHASTATE gachaState;

    [Header("UIOwer")]
    [SerializeField] GameObject uiOwner;

    [Header("SkillUI")]
    [SerializeField] GameObject[] skillUI;

    List<GameObject> skillUIList = new List<GameObject>();

    WaitForSeconds skillInstTime = new WaitForSeconds(0.2f);

    float[] skillProbs = { 60f, 30f, 10f };

    bool isLoad = false;

    void Awake()
    {
        LoadSkillData();
    }

    void OnEnable()
    {
        if (isLoad)
            StartCoroutine(ISkillInst());
        isLoad = true;
    }

    void LateUpdate()
    {
        Close();
    }

    IEnumerator ISkillInst()
    {
        yield return null;

        inst();

        yield return skillInstTime;
        inst();

        yield return skillInstTime;
        inst();

        yield return skillInstTime;
        inst();

        yield return skillInstTime;
        inst();

        gachaState = GACHASTATE.END;
    }

    void inst()
    {
        float skill = Choice(skillProbs);
        switch (skill)
        {
            case 0:
                InstanteSkill(rSkill, "r");
                break;
            case 1:
                InstanteSkill(srSkill, "sr");
                break;
            case 2:
                InstanteSkill(ssrSkill, "ssr");
                break;
        }
    }

    void InstanteSkill(GameObject[] skill, string grade)
    {
        // classification - Active Skill or Passive Skill
        int index = UnityEngine.Random.Range(0, skill.Length);
        GameObject SkillObj = Instantiate(skill[index]);
        SkillObj.GetComponent<Image>().sprite = SkillObj.GetComponent<cSkillUI>().SkillData.skillSprite;
        switch (SkillObj.GetComponent<cSkillUI>().SkillData.skillType)
        {
            case SkillType.ACTIVE:
                SkillObj.transform.SetParent(activeOwner.transform, false);
                break;
            case SkillType.PASSIVE:
                SkillObj.transform.SetParent(passiveOwner.transform, false);
                break;
        }

        // Save Skill Data
        SaveSkillData(grade, index);

        // Shop SKill UI Instantiate
        GameObject skillUIInst = Instantiate(skillUI[0]);       // skillUI[0] - Need To Fix - why - 등급에 따라 색깔을 다르게 해야함
        skillUIList.Add(skillUIInst);
        skillUIInst.transform.SetParent(uiOwner.transform, false);
        Image skillImage = skillUIInst.GetComponent<Image>();
        skillImage.sprite = SkillObj.GetComponent<Image>().sprite;

        // Skill Register
        bool isDup = cSkillManager.instance.CheckDuplicate(SkillObj.GetComponent<cSkillUI>().SkillData.skillName);    // CheckDuplicate
        cSkillManager.instance.RegisterSkill(SkillObj.GetComponent<cSkillUI>().SkillData.skillName);
        if (isDup)
            Destroy(SkillObj);
    }

    #region SaveAndLoad

    void SaveSkillData(string grade, int index)
    {
        SkillSaveData data = new SkillSaveData
        {
            skillGrade = grade,
            skillIndex = index
        };

        SkillJsonManager.instance.SaveData(data);
    }

    void LoadSkillData()
    {
        List<SkillSaveData> dataList = SkillJsonManager.instance.LoadData();
        if (dataList == null)
            return;

        foreach (var data in dataList)
        {
            GameObject[] skill = null;
            switch (data.skillGrade)
            {
                case "r":
                    skill = rSkill;
                    break;
                case "sr":
                    skill = srSkill;
                    break;
                case "ssr":
                    skill = ssrSkill;
                    break;
            }

            int index = data.skillIndex;

            GameObject SkillObj = Instantiate(skill[index]);
            SkillData skillData = SkillObj.GetComponent<cSkillUI>().SkillData;
            SkillObj.GetComponent<Image>().sprite = skillData.skillSprite;
            switch (skillData.skillType)
            {
                case SkillType.ACTIVE:
                    SkillObj.transform.SetParent(activeOwner.transform, false);
                    break;
                case SkillType.PASSIVE:
                    SkillObj.transform.SetParent(passiveOwner.transform, false);
                    break;
            }

            // Skill Register
            bool isDup = cSkillManager.instance.CheckDuplicate(skillData.skillName);    // CheckDuplicate
            cSkillManager.instance.RegisterSkill(SkillObj.GetComponent<cSkillUI>().SkillData.skillName);
            if (isDup)
                Destroy(SkillObj);
        }
    }

    #endregion

    void Close()
    {
        if (gachaState == GACHASTATE.END)
            if (Input.GetMouseButtonUp(0))
            {
                foreach (var uiObj in skillUIList)
                    Destroy(uiObj);

                this.gameObject.SetActive(false);
                gachaState = GACHASTATE.STAY;
            }
    }

    float Choice(float[] probs)
    {
        float total = 0;
        foreach (var elem in probs)
            total += elem;

        float randomPoint = UnityEngine.Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
                return i;
            else
                randomPoint -= probs[i];
        }

        return probs.Length - 1;
    }

    public void SkillGachaPopup()
    {
        cPopupManager.instance.Push("MainPopup", "정말로 구입하시겠습니까?", () => this.gameObject.SetActive(true));
    }
}
