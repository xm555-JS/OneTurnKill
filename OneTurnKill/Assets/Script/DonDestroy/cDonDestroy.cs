using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cDonDestroy : MonoBehaviour
{
    public GameObject owner;

    void Awake()
    {
        DontDestroyOnLoad(owner);
    }
}
