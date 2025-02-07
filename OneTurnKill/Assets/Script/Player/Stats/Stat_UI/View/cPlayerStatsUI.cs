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

    public void UpdateStat(int level,float statValue, float nextStatValue)
    {
        titleText.text = "°ø°Ý·Â Lv." + level;
        StatText.text = statValue.ToString();
        nextStatText.text = nextStatValue.ToString();
    }
}