using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class cPlayerStatsUI : MonoBehaviour
{
    // View
    protected Button statButton;
    protected Text goldText;
    protected Text titleText;
    protected Text StatText;
    protected Text nextStatText;

    // default price
    protected int price = 1000;
    protected int priceIncreaseAmount = 100;

    // present
    protected cPlayerStatsPresent present;

    bool isSpend;

    protected abstract void StatUp();

    protected void Awake()
    {
        statButton = GetComponent<Button>();
        goldText = GetComponentsInChildren<Text>()[0];
        titleText = GetComponentsInChildren<Text>()[1];
        StatText = GetComponentsInChildren<Text>()[2];
        nextStatText = GetComponentsInChildren<Text>()[3];
    }

    protected virtual void Start()
    {
        cPlayerStats playerStats = GameManager.instance.playerStats;
        present = new cPlayerStatsPresent(this, playerStats);

        goldText.text = price.ToString();

        statButton.onClick.AddListener(StatUp);
    }

    public void UpdateStat(string Name, int level, float statValue, float nextStatValue)
    {
        switch (Name)
        {
            case "Str":
                titleText.text = "���ݷ� Lv." + level;
                break;

            case "CriChance":
                titleText.text = "ġ��Ÿ Ȯ�� Lv." + level;
                break;

            case "CriDamage":
                titleText.text = "ġ��Ÿ ���ط� Lv." + level;
                break;

            case "GoldAcq":
                titleText.text = "��� ȹ������ Lv." + level;
                break;

            case "ExpAcq":
                titleText.text = "����ġ ȹ������ Lv." + level;
                break;
        }

        StatText.text = statValue.ToString();
        nextStatText.text = nextStatValue.ToString();

        GameManager.instance.playerCom.SpendCoin(price);
        price += priceIncreaseAmount;
        goldText.text = price.ToString();
    }

    public void UpdateCharStat(string Name, int level, float statValue, float nextStatValue)
    {
        switch (Name)
        {
            case "Str":
                titleText.text = "���ݷ� Lv." + level;
                break;

            case "CriChance":
                titleText.text = "ġ��Ÿ Ȯ�� Lv." + level;
                break;

            case "CriDamage":
                titleText.text = "ġ��Ÿ ���ط� Lv." + level;
                break;

            case "GoldAcq":
                titleText.text = "��� ȹ������ Lv." + level;
                break;

            case "ExpAcq":
                titleText.text = "����ġ ȹ������ Lv." + level;
                break;
        }

        StatText.text = statValue.ToString() + "%";
        nextStatText.text = nextStatValue.ToString() + "%";

        GameManager.instance.playerCom.SpendCoin(price);
        price += priceIncreaseAmount;
        goldText.text = price.ToString();
    }

    public bool IsSpend()
    {
        if (GameManager.instance.playerCom.Coin < price)
            isSpend = false;
        else
            isSpend = true;

        return isSpend;
    }
}