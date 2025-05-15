using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cPopupManager : MonoBehaviour
{
    public static cPopupManager instance;
    [SerializeField] GameObject Owner;
    [SerializeField] GameObject RewardPopup;
    List<GameObject> popupList = new List<GameObject>();

    void Awake()
    {
        if (!instance)
            instance = this;

        var popArray = Resources.LoadAll<GameObject>("UI/Popup");
        popupList.AddRange(popArray);
    }


    public void Push(string popupName, string mainText, UnityEngine.Events.UnityAction Action = null)
    {
        foreach (var popup in popupList)
        {
            if (popup.name == popupName)
            {
                GameObject popupInst = Instantiate(popup);
                popupInst.transform.SetParent(Owner.transform, false);
                cPopup popupCom = popupInst.GetComponent<cPopup>();
                if (popupCom == null)
                {
                    Debug.LogError("cPopupManager - popupCom is null");
                }

                // ÃÊ±âÈ­
                popupCom.mainText.text = mainText;
                if (Action != null)
                    popupCom.yesButton.onClick.AddListener(Action);
                popupCom.yesButton.onClick.AddListener(() => Destroy(popupCom.gameObject));
                popupCom.noButton.onClick.AddListener(() => Destroy(popupCom.gameObject));
            }
        }
    }

    public void RewardPush(int coinValue, int bossCoinValue, int armorValue, int weaponValue, UnityEngine.Events.UnityAction action = null)
    {
        GameObject popUp = Instantiate(RewardPopup);
        popUp.transform.SetParent(Owner.transform, false);
        cRewardPopUp rewardPopUp = popUp.GetComponent<cRewardPopUp>();

        rewardPopUp.coinRewardTxt.text = coinValue.ToString();
        rewardPopUp.bossRewardTxt.text = bossCoinValue.ToString();
        rewardPopUp.armorRewardTxt.text = armorValue.ToString();
        rewardPopUp.weaponRewawrdTxt.text = weaponValue.ToString();

        GameManager.instance.playerCom.AddCoin(coinValue);
        GameManager.instance.playerCom.AddBossCoin(bossCoinValue);
        GameManager.instance.playerCom.AddArmorMat(armorValue);
        GameManager.instance.playerCom.AddWeaponMat(weaponValue);

        if (action != null)
            rewardPopUp.mainButton.onClick.AddListener(action);
        rewardPopUp.mainButton.onClick.AddListener(() => Destroy(rewardPopUp.gameObject));
    }
}
