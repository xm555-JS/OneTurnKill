using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cStage : MonoBehaviour
{
    [SerializeField] Text stageText;
    [SerializeField] StageManager stageManager;

    void Update()
    {
        stageText.text = "Stage : " + stageManager.stageNum.ToString();
    }
}
