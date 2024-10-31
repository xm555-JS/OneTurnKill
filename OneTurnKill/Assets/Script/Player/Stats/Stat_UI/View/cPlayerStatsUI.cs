using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class cPlayerStatsUI : MonoBehaviour
{
    // View
    protected Button statButton;
    protected Text statText;

    // present
    protected cPlayerStatsPresent present;

    protected abstract void StatUp();

    protected void Awake()
    {
        statButton = GetComponent<Button>();
        statText = GetComponentsInChildren<Text>()[1];
    }

    protected virtual void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        cPlayerStats playerStats = player.GetComponentInChildren<cPlayerStats>();

        present = new cPlayerStatsPresent(this, playerStats);

        statButton.onClick.AddListener(StatUp);
    }

    public void UpdateStat(float statValue, float nextStatValue)
    {
        statText.text = statValue.ToString() + " -> " + nextStatValue.ToString();
    }
}