using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cInstanate : MonoBehaviour
{
    // inven류의 UI에서 객체를 계속 생성할 때 
    [Header("Ower")]
    [SerializeField] GameObject ower;

    [Header("Skill")]
    [SerializeField] GameObject rSkill;
    [SerializeField] GameObject srSkill;
    [SerializeField] GameObject ssrSkill;

    float[] skillProbs = { 60f, 30f, 10f };

    public void InstanateUI()
    {
        for (int i = 0; i < 10; i++)
        {
            float skill = Choice(skillProbs);

            switch (skill)
            {
                case 0:
                    GameObject rSkillObj = Instantiate(rSkill);
                    rSkillObj.transform.SetParent(ower.transform, false);
                    break;
                case 1:
                    GameObject srSkillObj = Instantiate(srSkill);
                    srSkillObj.transform.SetParent(ower.transform, false);
                    break;
                case 2:
                    GameObject ssrSkillObj = Instantiate(ssrSkill);
                    ssrSkillObj.transform.SetParent(ower.transform, false);
                    break;
            }
        }
    }

    float Choice(float[] probs)
    {
        float total = 0;
        foreach (var elem in probs)
            total += elem;

        float randomPoint = Random.value * total;

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
