using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour
{
    public void ActiveTrue()
    {
        this.gameObject.SetActive(true);
    }

    public void ActiveFalse()
    {
        this.gameObject.SetActive(false);
    }
}
