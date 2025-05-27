using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cButtonSound : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => AudioManager.instance.PlayerSfx(AudioManager.Sfx.CLICK));
    }
}
