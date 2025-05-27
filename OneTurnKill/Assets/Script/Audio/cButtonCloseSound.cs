using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cButtonCloseSound : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => AudioManager.instance.PlayerSfx(AudioManager.Sfx.CLOSE));
    }
}
