using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cInven : MonoBehaviour
{
    cPlayer player;
    cInvenBox[] invenBoxs;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<cPlayer>();
        invenBoxs = GetComponentsInChildren<cInvenBox>();
    }

    void OnEnable()
    {
        foreach (var box in invenBoxs)
        {
            foreach (var sprite in player.ReturnHelmetList())
            {
                Sprite invenSprite = sprite;
                if (invenSprite = null)
                    return;
                else
                {
                    box.gameObject.SetActive(true);
                    box.ChangeSprite(sprite);
                }
            }
        }
    }
}
