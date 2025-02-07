using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class cPlayerStatsUI : MonoBehaviour
{
    // View
    protected Button statButton;
    protected Text titleText;
    protected Text StatText;
    protected Text nextStatText;

    // present
    protected cPlayerStatsPresent present;

    protected abstract void StatUp();

    protected void Awake()
    {
        statButton = GetComponent<Button>();
        titleText = GetComponentsInChildren<Text>()[1];
        StatText = GetComponentsInChildren<Text>()[2];
        nextStatText = GetComponentsInChildren<Text>()[3];
    }

    protected virtual void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        cPlayerStats playerStats = player.GetComponentInChildren<cPlayerStats>();

        present = new cPlayerStatsPresent(this, playerStats);

        statButton.onClick.AddListener(StatUp);
    }

    public void UpdateStat(string Name, int level,float statValue, float nextStatValue)
    {
        switch (Name)
        {
            case "Str":
                titleText.text = "°ø°Ý·Â Lv." + level;
                break;

            case "CriChance":
                titleText.text = "Ä¡¸íÅ¸ È®·ü Lv." + level;
                break;

            case "CriDamage":
                titleText.text = "Ä¡¸íÅ¸ ÇÇÇØ·® Lv." + level;
                break;

            case "GoldAcq":
                titleText.text = "°ñµå È¹µæÁõ°¡ Lv." + level;
                break;

            case "ExpAcq":
                titleText.text = "°æÇèÄ¡ È¹µæÁõ°¡ Lv." + level;
                break;
        }
        
        StatText.text = statValue.ToString();
        nextStatText.text = nextStatValue.ToString();
    }

    public void UpdateCharStat(string Name,int level, float statValue, float nextStatValue)
    {
        switch (Name)
        {
            case "Str":
                titleText.text = "°ø°Ý·Â Lv." + level;
                break;

            case "CriChance":
                titleText.text = "Ä¡¸íÅ¸ È®·ü Lv." + level;
                break;

            case "CriDamage":
                titleText.text = "Ä¡¸íÅ¸ ÇÇÇØ·® Lv." + level;
                break;

            case "GoldAcq":
                titleText.text = "°ñµå È¹µæÁõ°¡ Lv." + level;
                break;

            case "ExpAcq":
                titleText.text = "°æÇèÄ¡ È¹µæÁõ°¡ Lv." + level;
                break;
        }

        StatText.text = statValue.ToString() + "%";
        nextStatText.text = nextStatValue.ToString() + "%";
    }
}