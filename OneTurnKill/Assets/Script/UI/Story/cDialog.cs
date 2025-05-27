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

    string preDialog;

    public bool IsFinish { get => isFinish; }

    void Awake()
    {
        nameTxt = GetComponentsInChildren<Text>()[0];
        dialogTxt = GetComponentsInChildren<Text>()[1];
        this.gameObject.SetActive(false);
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
        if (dialog == preDialog)
            return;
        preDialog = dialog;

        Debug.Log("¥Î»≠¡ﬂ");

        nameTxt.text = name;
        dialogTxt.text = dialog;

        this.gameObject.SetActive(true);
        isFinish = false;

        StartCoroutine(HideTime());
    }

    IEnumerator HideTime()
    {
        yield return new WaitForSeconds(0.5f);
        isHide = true;
    }
}
