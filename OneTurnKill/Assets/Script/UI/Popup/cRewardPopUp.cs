using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cRewardPopUp : MonoBehaviour
{
    public Button mainButton;
    public Text coinRewardTxt;
    public Text armorRewardTxt;
    public Text weaponRewawrdTxt;
    public Text bossRewardTxt;

    void Awake()
    {
        mainButton = GetComponentInChildren<Button>();

        coinRewardTxt = this.GetComponentsInChildren<Text>()[1];
        armorRewardTxt = this.GetComponentsInChildren<Text>()[2];
        weaponRewawrdTxt = this.GetComponentsInChildren<Text>()[3];
        bossRewardTxt = this.GetComponentsInChildren<Text>()[4];

        AudioManager.instance.PlayerSfx(AudioManager.Sfx.ACQUIRE);
    }
}
