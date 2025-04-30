using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cSceneBlind : MonoBehaviour
{
    Image img;
    Color color;

    void Awake()
    {
        img = GetComponent<Image>();
        color = img.color;
    }

    public void BlindScene()
    {
        StartCoroutine(StartBlind());
    }

    IEnumerator StartBlind()
    {
        float alpha = 0f;
        while (img.color.a < 1f)
        {
            alpha += Time.deltaTime;
            color.a = alpha;
            img.color = color;

            yield return null;
        }

        color.a = 1f;
        img.color = color;

        yield return new WaitForSeconds(1f);

        while (img.color.a > 0f)
        {
            alpha -= Time.deltaTime;
            color.a = alpha;
            img.color = color;

            yield return null;
        }

        color.a = 0f;
        img.color = color;
    }
}
