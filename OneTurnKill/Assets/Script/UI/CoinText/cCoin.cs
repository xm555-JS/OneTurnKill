using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cCoin : MonoBehaviour
{
    [SerializeField] cPlayer player;
    Text CoinTxt;

    void Awake()
    {
        CoinTxt = GetComponent<Text>();
    }

    void LateUpdate()
    {
        float coin = player.Coin;
        CoinTxt.text = coin.ToString();
    }
}
