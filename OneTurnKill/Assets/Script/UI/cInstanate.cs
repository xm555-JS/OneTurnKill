using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkillInst : MonoBehaviour
{
    // inven���� UI���� ��ü�� ��� ������ �� 

    [SerializeField] GameObject obj;
    [SerializeField] GameObject ower;

    // 

    public void InstanateUI()
    {
        GameObject objUI = Instantiate(obj);
        objUI.transform.SetParent(ower.transform, false);
    }
}
