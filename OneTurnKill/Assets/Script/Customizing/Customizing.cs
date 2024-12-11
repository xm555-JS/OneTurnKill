using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customizing : MonoBehaviour
{
    [SerializeField] Sprite[] spriteHairs;
    [SerializeField] Sprite[] spriteCloths;
    [SerializeField] Sprite[] spritePants;

    SpriteRenderer hairSpriteRender;
    SpriteRenderer clothSpriteRender;
    SpriteRenderer pantSpriteRender;

    int hairIndex = 0;

    void Awake()
    {
        hairSpriteRender = GameObject.Find("7_Hair").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            hairIndex++;

            if (hairIndex >= spriteHairs.Length)
                hairIndex = 0;

            hairSpriteRender.sprite = spriteHairs[hairIndex];
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            hairIndex--;

            if (hairIndex < 0)
                hairIndex = spriteHairs.Length - 1;

            hairSpriteRender.sprite = spriteHairs[hairIndex];
        }
    }

    //public void NextHairs()
    //{
    //    hairSprite = 
    //}
}
