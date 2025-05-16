using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cStoryPanel : MonoBehaviour
{
    public bool isFinish;

    [SerializeField] GameObject panel;

    Image panelImg;
    Color panelColor;

    Color black = new Color(0f, 0f, 0f, 0f);
    Color white = new Color(1f, 1f, 1f, 0f);

    void Awake()
    {
        panelImg = GetComponent<Image>();
        panelColor = panelImg.color;
    }

    public void SetBlack() { panelImg.color = new Color(0f, 0f, 0f, 1f); }
    public void SetWhite() { panelImg.color = new Color(1f, 1f, 1f, 1f); }

    public void BlackOut()
    {
        StartCoroutine(StartBalckOut());
    }

    IEnumerator StartBalckOut()
    {
        panelColor = black;

        float alpha = 0f;
        while (panelImg.color.a <= 1f)
        {
            alpha += Time.deltaTime;
            panelColor.a = alpha;
            panelImg.color = panelColor;

            yield return null;
        }

        panelColor.a = 1f;
        panelImg.color = panelColor;
        isFinish = true;
    }

    public void whiteOut()
    {
        StartCoroutine(StartWhiteOut());
    }

    IEnumerator StartWhiteOut()
    {
        panelColor = white;

        float alpha = 0f;
        while (panelImg.color.a <= 1f)
        {
            alpha += Time.deltaTime;
            panelColor.a = alpha;
            panelImg.color = panelColor;

            yield return null;
        }

        panelColor.a = 1f;
        panelImg.color = panelColor;
        isFinish = true;
    }

    public void ReturnPanel()
    {
        StartCoroutine(StartReturn());
    }

    IEnumerator StartReturn()
    {
        float alpha = 1f;
        while (panelImg.color.a >= 0f)
        {
            alpha -= Time.deltaTime;
            panelColor.a = alpha;
            panelImg.color = panelColor;

            yield return null;
        }

        panelColor.a = 0f;
        panelImg.color = panelColor;
        isFinish = false;
    }
}
