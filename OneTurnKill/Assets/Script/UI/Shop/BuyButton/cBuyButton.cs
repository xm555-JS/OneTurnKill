using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cBuyButton : MonoBehaviour
{
    enum Type { ARMOR, WEAPON, COIN, BOSSCOIN, CHANGE } 
    [SerializeField] Type matType;

    [SerializeField] int price;
    cPlayer player;
    Button buyBtn;

    void Awake()
    {
        player = GameManager.instance.playerCom;
        buyBtn = this.GetComponent<Button>();
    }

    void Start()
    {
        buyBtn.onClick.AddListener(() => cPopupManager.instance.Push("MainPopup", "정말로 구입하시겠습니까?", () => BuyItem()));
    }

    void BuyItem()
    {
        switch (matType)
        {
            case Type.ARMOR:
                player.SpendCoin(price);
                player.AddArmorMat(10);
                break;
            case Type.WEAPON:
                player.SpendCoin(price);
                player.AddWeaponMat(10);
                break;
            case Type.COIN:
                player.SpendCoin(price);
                player.AddCoin(5000);
                break;
            case Type.BOSSCOIN:
                player.SpendBossCoin(price);
                player.AddBossCoin(50);
                break;
            case Type.CHANGE:
                player.SpendBossCoin(price);
                player.AddCoin(1000);
                break;
        }
    }
}
