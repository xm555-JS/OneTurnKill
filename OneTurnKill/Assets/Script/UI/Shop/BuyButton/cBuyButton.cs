using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cBuyButton : MonoBehaviour
{
    [SerializeField] int price;
    cPlayer player;
    Button buyBtn;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<cPlayer>();
        buyBtn = this.GetComponent<Button>();
    }

    void Start()
    {
        buyBtn.onClick.AddListener(() => cPopupManager.instance.Push("MainPopup", "정말로 구입하시겠습니까?", () => player.SpendCoin(price)));
    }
}
