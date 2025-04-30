using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageManager : MonoBehaviour
{
    [SerializeField] cSceneBlind blind;
    [SerializeField] cBoss boss;
    void Update()
    {
        if (GameManager.instance.playerCom.IsHit == true)
        {
            // reset player
            GameManager.instance.playerCom.ResetHit();

            blind.BlindScene();
            boss.ToIdle();
            StartCoroutine(Test());
        }
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(1f);
        boss.ResetPosition();

        yield return new WaitForSeconds(2f);
        boss.ResetInfo();
    }
}
