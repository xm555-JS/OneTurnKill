using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageManager : MonoBehaviour
{
    [SerializeField] cSceneBlind blind;
    [SerializeField] cBoss boss;

    bool isAttackReady;
    public bool IsAttackReady { get => isAttackReady; }

    void OnEnable()
    {
        boss.StateMachine.groggyState.OnGroggy += CheckBossGroggy;
    }

    void OnDisable()
    {
        boss.StateMachine.groggyState.OnGroggy -= CheckBossGroggy;
    }

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

    void CheckBossGroggy() { isAttackReady = true; }
}
