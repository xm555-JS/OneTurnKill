using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customizing : MonoBehaviour
{
    [System.Serializable]
    public struct TopCloth
    {
        public Sprite body;
        public Sprite left;
        public Sprite right;
    }

    [System.Serializable]
    public struct Pants
    {
        public Sprite left;
        public Sprite right;
    }

    [SerializeField] Sprite[] spriteHairs;
    [SerializeField] TopCloth[] spriteCloths;
    [SerializeField] Pants[] spritePants;

    SpriteRenderer hairSpriteRender;

    SpriteRenderer topBodySpriteRender;
    SpriteRenderer topLeftSpriteRender;
    SpriteRenderer topRightSpriteRender;

    SpriteRenderer pantLeftSpriteRender;
    SpriteRenderer pantRightSpriteRender;

    int hairIndex = 0;
    int clothIndex = 0;
    int pantIndex = 0;

    void Awake()
    {
        hairSpriteRender = GameObject.Find("7_Hair").GetComponent<SpriteRenderer>();
        
        topBodySpriteRender = GameObject.Find("ClothBody").GetComponent<SpriteRenderer>();
        topLeftSpriteRender = GameObject.Find("21_LCArm").GetComponent<SpriteRenderer>();
        topRightSpriteRender = GameObject.Find("-19_RCArm").GetComponent<SpriteRenderer>();

        pantLeftSpriteRender = GameObject.Find("_2L_Cloth").GetComponent<SpriteRenderer>();
        pantRightSpriteRender = GameObject.Find("_11R_Cloth").GetComponent<SpriteRenderer>();
    }

    public void NextHairs()
    {
        hairIndex++;

        if (hairIndex >= spriteHairs.Length)
            hairIndex = 0;

        hairSpriteRender.sprite = spriteHairs[hairIndex];
    }

    public void PreHairs()
    {
        hairIndex--;

        if (hairIndex < 0)
            hairIndex = spriteHairs.Length - 1;

        hairSpriteRender.sprite = spriteHairs[hairIndex];
    }

    public void NextTop()
    {
        clothIndex++;

        if (clothIndex >= spriteCloths.Length)
            clothIndex = 0;

        topBodySpriteRender.sprite = spriteCloths[clothIndex].body;
        topLeftSpriteRender.sprite = spriteCloths[clothIndex].left;
        topRightSpriteRender.sprite = spriteCloths[clothIndex].right;
    }

    public void PreTop()
    {
        clothIndex--;

        if (clothIndex < 0)
            clothIndex = spriteCloths.Length - 1;

        topBodySpriteRender.sprite = spriteCloths[clothIndex].body;
        topLeftSpriteRender.sprite = spriteCloths[clothIndex].left;
        topRightSpriteRender.sprite = spriteCloths[clothIndex].right;
    }

    public void NextPants()
    {
        pantIndex++;

        if (pantIndex >= spritePants.Length)
            pantIndex = 0;

        pantLeftSpriteRender.sprite = spritePants[pantIndex].left;
        pantRightSpriteRender.sprite = spritePants[pantIndex].right;
    }

    public void PrePants()
    {
        pantIndex--;

        if (pantIndex < 0)
            pantIndex = spritePants.Length - 1;

        pantLeftSpriteRender.sprite = spritePants[pantIndex].left;
        pantRightSpriteRender.sprite = spritePants[pantIndex].right;
    }
}
