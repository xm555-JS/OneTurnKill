using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cDropItem : MonoBehaviour
{
    public float Drop_Item(float[] probs)
    {
        return Choice(probs);
    }

    float Choice(float[] probs)
    {
        float total = 0f;

        foreach (float elem in probs)
            total += elem;

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
                return i;
            else
                randomPoint -= probs[i];
        }

        // Random.value���� 1�� ���
        return probs.Length - 1;
    }
}
