using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupSelect : MonoBehaviour
{
    public void Select(GameObject[] objects)
    {
        foreach (var obj in objects)
            obj.SetActive(false);
    }
}
