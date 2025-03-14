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

    void OnEnable()
    {
        StartCoroutine(ISkillInst());
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
                InstanteSkill(rSkill);
                break;
            case 1:
                InstanteSkill(srSkill);
                break;
            case 2:
                InstanteSkill(ssrSkill);
                break;
        }
    }

    void InstanteSkill(GameObject[] skill)
    {
        // classification - Active Skill or Passive Skill
        int Index = UnityEngine.Random.Range(0, skill.Length);
        GameObject SkillObj = Instantiate(skill[Index]);
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

        // Shop SKill UI Instantiate
        GameObject skillUIInst = Instantiate(skillUI[0]);
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
