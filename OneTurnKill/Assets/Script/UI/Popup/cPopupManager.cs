using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cPopupManager : MonoBehaviour
{
    public static cPopupManager instance;
    [SerializeField] GameObject Owner;
    List<GameObject> popupList = new List<GameObject>();

    void Awake()
    {
        if (!instance)
            instance = this;

        var popArray = Resources.LoadAll<GameObject>("UI/Popup");
        popupList.AddRange(popArray);
    }


    public void Push(string popupName, string mainText, UnityEngine.Events.UnityAction Action)
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
                popupCom.yesButton.onClick.AddListener(Action);
                popupCom.yesButton.onClick.AddListener(() => Destroy(popupCom.gameObject));
                popupCom.noButton.onClick.AddListener(() => Destroy(popupCom.gameObject));
            }
        }
    }
}
