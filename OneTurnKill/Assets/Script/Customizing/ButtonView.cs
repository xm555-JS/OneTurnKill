using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonView : MonoBehaviour
{
    [SerializeField] Image btnImage;
    [SerializeField] GameObject part;
    [SerializeField] bool isHairButton;

    SpriteRenderer partSpriteRenderer;

    Color hoHairColor = new Color(0.215f, 0.215f, 0.215f);
    Color hairColor = new Color(0.44f, 0.15f, 0.15f);
    Color basicColor = new Color(1f, 1f, 1f);

    void Awake()
    {
        partSpriteRenderer = part.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        ButtonColorChange();
        btnImage.sprite = partSpriteRenderer.sprite;
    }

    void ButtonColorChange()
    {
        if (btnImage.sprite == null)        // Image가 없을 때 배경 색상과 이미지 버튼 색깔이 같도록
            btnImage.color = hoHairColor;

        if (isHairButton && btnImage.sprite) // sprite이미지 색상을 머리색과 같도록
            btnImage.color = hairColor;
        else if (btnImage.sprite)
            btnImage.color = basicColor;
    }
}
