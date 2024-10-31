using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cSkillUI : MonoBehaviour
{
    Button skillButton;
    cPlayerAttack playerAttack;
    [SerializeField] string skillName;

    void Awake()
    {
        skillButton = GetComponent<Button>();
    }

    void Start()
    {
        GetPlayerAttack();
        SetAddListner();
    }

    void GetPlayerAttack()
    {
        playerAttack = GameObject.FindWithTag("Player").GetComponent<cPlayerAttack>();
        if (!playerAttack)
            Debug.LogError("cSkillUI - playerAttack is null.");
    }

    void SetAddListner()
    {
        skillButton.onClick.AddListener(() => playerAttack.Attack(skillName));
    }
}
