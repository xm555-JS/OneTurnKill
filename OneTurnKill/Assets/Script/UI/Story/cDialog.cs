using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cDialog : MonoBehaviour
{
    GameObject canvas;
    Text nameTxt;
    Text dialogTxt;

    bool isHide;
    bool isFinish;

    public bool IsFinish { get => isFinish; }

    void Awake()
    {
        nameTxt = GetComponentsInChildren<Text>()[0];
        dialogTxt = GetComponentsInChildren<Text>()[1];
    }

    void Update()
    {
        if (isHide)
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.gameObject.SetActive(false);
                isHide = false;
                isFinish = true;
            }
        }
    }

    public void SetDialog(string name, string dialog)
    {
        isFinish = false;

        if (name != "")
            return;

        nameTxt.text = name;
        dialogTxt.text = dialog;

        this.gameObject.SetActive(true);
        StartCoroutine(HideTime());
    }

    IEnumerator HideTime()
    {
        yield return new WaitForSeconds(0.5f);
        isHide = true;
    }
}
