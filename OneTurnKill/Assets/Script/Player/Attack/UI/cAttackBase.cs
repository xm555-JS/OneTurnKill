using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cAttackBase : MonoBehaviour
{
    Button skillButton;
    cPlayerAttack playerAttack;

    void Awake()
    {
        skillButton = GetComponent<Button>();
    }

    void Start()
    {
        playerAttack = new cPlayerAttack();
        skillButton.onClick.AddListener(() => playerAttack.Attack("Base"));
    }
}
