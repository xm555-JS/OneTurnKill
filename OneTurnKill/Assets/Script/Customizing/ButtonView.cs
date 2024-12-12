using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonView : MonoBehaviour
{
    [SerializeField] Image btnImage;
    [SerializeField] GameObject part;

    SpriteRenderer partSpriteRenderer;

    void Awake()
    {
        partSpriteRenderer = part.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        btnImage.sprite = partSpriteRenderer.sprite;
    }
}
