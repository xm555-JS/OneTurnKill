using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cCustomLevelBtn : MonoBehaviour
{
    LevelManager levelManger;
    Button btn;

    void Awake()
    {
        levelManger = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        btn = GetComponent<Button>();

        btn.onClick.AddListener(() => levelManger.GoToGamePlay());
    }
}
