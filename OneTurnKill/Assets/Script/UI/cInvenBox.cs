using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cInvenBox : MonoBehaviour
{
    Image boxImage;

    void Awake()
    {
    boxImage = GetComponent<Image>();

    }

    public void ChangeSprite(Sprite sprite)
    {
        boxImage.sprite = sprite;
    }
}
