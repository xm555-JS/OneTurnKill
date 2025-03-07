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
                int rIndex = UnityEngine.Random.Range(0, rSkill.Length);
                GameObject rSkillObj = Instantiate(rSkill[rIndex]);
                rSkillObj.GetComponent<Image>().sprite = rSkillObj.GetComponent<cSkillUI>().skillData.skillSprite;
                switch (rSkillObj.GetComponent<cSkillUI>().skillData.skillType)
                {
                    case SkillType.ACTIVE:
                        rSkillObj.transform.SetParent(activeOwner.transform, false);
                        break;
                    case SkillType.PASSIVE:
                        rSkillObj.transform.SetParent(passiveOwner.transform, false);
                        break;
                }

                // Shop SKill UI Instantiate
                GameObject skillUIInst = Instantiate(skillUI[0]);
                skillUIList.Add(skillUIInst);
                skillUIInst.transform.SetParent(uiOwner.transform, false);
                Image skillImage = skillUIInst.GetComponent<Image>();
                skillImage.sprite = rSkillObj.GetComponent<Image>().sprite;
                break;
            case 1:
                int srIndex = UnityEngine.Random.Range(0, srSkill.Length);
                GameObject srSkillObj = Instantiate(srSkill[srIndex]);
                srSkillObj.GetComponent<Image>().sprite = srSkillObj.GetComponent<cSkillUI>().skillData.skillSprite;
                switch (srSkillObj.GetComponent<cSkillUI>().skillData.skillType)
                {
                    case SkillType.ACTIVE:
                        srSkillObj.transform.SetParent(activeOwner.transform, false);
                        break;
                    case SkillType.PASSIVE:
                        srSkillObj.transform.SetParent(passiveOwner.transform, false);
                        break;
                }

                // Shop SKill UI Instantiate
                GameObject srSkillUIInst = Instantiate(skillUI[1]);
                skillUIList.Add(srSkillUIInst);
                srSkillUIInst.transform.SetParent(uiOwner.transform, false);
                Image srSkillImage = srSkillUIInst.GetComponent<Image>();
                srSkillImage.sprite = srSkillObj.GetComponent<Image>().sprite;
                break;
            case 2:
                int ssrIndex = UnityEngine.Random.Range(0, ssrSkill.Length);
                GameObject ssrSkillObj = Instantiate(ssrSkill[ssrIndex]);
                ssrSkillObj.GetComponent<Image>().sprite = ssrSkillObj.GetComponent<cSkillUI>().skillData.skillSprite;
                switch (ssrSkillObj.GetComponent<cSkillUI>().skillData.skillType)
                {
                    case SkillType.ACTIVE:
                        ssrSkillObj.transform.SetParent(activeOwner.transform, false);
                        break;
                    case SkillType.PASSIVE:
                        ssrSkillObj.transform.SetParent(passiveOwner.transform, false);
                        break;
                }

                // Shop SKill UI Instantiate
                GameObject ssrSkillUIInst = Instantiate(skillUI[2]);
                skillUIList.Add(ssrSkillUIInst);
                ssrSkillUIInst.transform.SetParent(uiOwner.transform, false);
                Image ssrSkillImage = ssrSkillUIInst.GetComponent<Image>();
                ssrSkillImage.sprite = ssrSkillObj.GetComponent<Image>().sprite;
                break;
        }
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
