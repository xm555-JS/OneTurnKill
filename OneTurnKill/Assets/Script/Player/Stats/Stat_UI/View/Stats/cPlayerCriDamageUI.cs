using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cPlayerCriDamageUI : cPlayerStatsUI
{
    protected override void StatUp()
    {
        present.OnCriDamageUp();
    }

    protected override void InitializeStat()
    {
        present.OnInitCriDamage();
    }
}

//// View
//Button hpButton;
//Text hpText;

//// present
//cPlayerStatsPresent present;

//void Awake()
//{
//    hpButton = GetComponent<Button>();
//    hpText = GetComponent<Text>();
//}

//void Start()
//{
//    GameObject player = GameObject.FindWithTag("Player");
//    cPlayerStats playerStats = player.GetComponentInChildren<cPlayerStats>();

//    //present = new cPlayerStatsPresent(this, playerStats);

//    hpButton.onClick.AddListener(present.OnHpUp);
//}

//public void UpdateHp(float hp)
//{
//    hpText.text = hp.ToString();
//}
