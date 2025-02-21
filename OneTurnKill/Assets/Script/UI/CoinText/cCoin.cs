using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cCoin : MonoBehaviour
{
    cPlayer player;
    Text CoinTxt;

    void Awake()
    {
        player = GameManager.instance.player.GetComponent<cPlayer>();
        CoinTxt = GetComponent<Text>();
    }

    void LateUpdate()
    {
        float coin = player.Coin;
        CoinTxt.text = coin.ToString();
    }
}
