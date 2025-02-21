using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkillInst : MonoBehaviour
{
    // inven류의 UI에서 객체를 계속 생성할 때 

    [SerializeField] GameObject obj;
    [SerializeField] GameObject ower;

    // 

    public void InstanateUI()
    {
        GameObject objUI = Instantiate(obj);
        objUI.transform.SetParent(ower.transform, false);
    }
}
