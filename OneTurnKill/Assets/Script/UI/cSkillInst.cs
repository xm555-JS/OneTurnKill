using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// test
using UnityEngine.UI;

public class cSkillInst : MonoBehaviour
{
    // inven류의 UI에서 객체를 계속 생성할 때 
    [Header("Owner")]
    [SerializeField] GameObject owner;

    [Header("Skill")]
    [SerializeField] GameObject[] rSkill;
    [SerializeField] GameObject[] srSkill;
    [SerializeField] GameObject[] ssrSkill;
    
    // Shop SKill UI Instantiate
    [Header("UIOwer")]
    [SerializeField] GameObject uiOwner;

    [Header("SkillUI")]
    [SerializeField] GameObject skillUI;
    Image skillUIImage;

    WaitForSeconds skillInstTime = new WaitForSeconds(0.2f);

    // Shop SKill UI Instantiate
    public event Action OnEnd;

    float[] skillProbs = { 60f, 30f, 10f };

    void Awake()
    {
        skillUIImage = skillUI.GetComponent<Image>();
    }

    public void InstanateUI()
    {
        StartCoroutine(ISkillInst());
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

        // event
        //OnEnd?.Invoke();
    }

    void inst()
    {
        float skill = Choice(skillProbs);

        switch (skill)
        {
            case 0:
                int rIndex = UnityEngine.Random.Range(0, rSkill.Length);
                GameObject rSkillObj = Instantiate(rSkill[rIndex]);
                rSkillObj.transform.SetParent(owner.transform, false);

                // Shop SKill UI Instantiate
                GameObject skillUIInst = Instantiate(skillUI);
                skillUIInst.transform.SetParent(uiOwner.transform, false);
                Image skillImage = skillUIInst.GetComponent<Image>();
                skillImage.sprite = rSkillObj.GetComponentsInChildren<Image>()[1].sprite;
                break;
            case 1:
                int srIndex = UnityEngine.Random.Range(0, srSkill.Length);
                GameObject srSkillObj = Instantiate(srSkill[srIndex]);
                srSkillObj.transform.SetParent(owner.transform, false);

                // Shop SKill UI Instantiate
                GameObject srSkillUIInst = Instantiate(skillUI);
                srSkillUIInst.transform.SetParent(uiOwner.transform, false);
                Image srSkillImage = srSkillUIInst.GetComponent<Image>();
                srSkillImage.sprite = srSkillObj.GetComponentsInChildren<Image>()[1].sprite;
                break;
            case 2:
                int ssrIndex = UnityEngine.Random.Range(0, ssrSkill.Length);
                GameObject ssrSkillObj = Instantiate(ssrSkill[ssrIndex]);
                ssrSkillObj.transform.SetParent(owner.transform, false);

                // Shop SKill UI Instantiate
                GameObject ssrSkillUIInst = Instantiate(skillUI);
                ssrSkillUIInst.transform.SetParent(uiOwner.transform, false);
                Image ssrSkillImage = ssrSkillUIInst.GetComponent<Image>();
                ssrSkillImage.sprite = ssrSkillObj.GetComponentsInChildren<Image>()[1].sprite;
                break;
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
}
