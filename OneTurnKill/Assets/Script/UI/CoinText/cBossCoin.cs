using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cBossCoin : MonoBehaviour
{
    cPlayer player;
    Text BossCoinTxt;

    void Start()
    {
        player = GameManager.instance.player.GetComponent<cPlayer>();
        BossCoinTxt = GetComponent<Text>();

        SetCoinTxt();
    }

    void LateUpdate()
    {
        SetCoinTxt();
    }

    void SetCoinTxt()
    {
        float coin = player.BossCoin;
        BossCoinTxt.text = coin.ToString();
    }
}
