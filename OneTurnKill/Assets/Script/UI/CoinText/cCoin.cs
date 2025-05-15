using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cCoin : MonoBehaviour
{
    cPlayer player;
    Text CoinTxt;

    void Start()
    {
        player = GameManager.instance.player.GetComponent<cPlayer>();
        CoinTxt = GetComponent<Text>();

        SetCoinTxt();
    }

    void LateUpdate()
    {
        SetCoinTxt();
    }

    void SetCoinTxt()
    {
        float coin = player.Coin;
        CoinTxt.text = coin.ToString();
    }
}
