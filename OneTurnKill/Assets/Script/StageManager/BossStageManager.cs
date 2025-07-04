using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageManager : MonoBehaviour
{
    [SerializeField] cSceneBlind blind;
    [SerializeField] cBoss boss;

    static public BossStageManager instance;

    bool isAttackReady;
    public bool IsAttackReady { get => isAttackReady; }
    public void ReadyAttack() { isAttackReady = true; }

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (GameManager.instance.playerCom.IsHit == true)
        {
            // reset player
            GameManager.instance.playerCom.ResetHit();

            blind.BlindScene();
            boss.ToIdle();
            StartCoroutine(ResetBossInfo());
            StartCoroutine(ResetPlayerInfo());
        }
    }

    IEnumerator ResetBossInfo()
    {
        yield return new WaitForSeconds(1f);
        boss.ResetPosition();

        yield return new WaitForSeconds(2f);
        boss.ResetInfo();
    }

    IEnumerator ResetPlayerInfo()
    {
        yield return new WaitForSeconds(1f);

        GameManager.instance.player.transform.position = new Vector3(-2f, 0f, 0f);
        GameManager.instance.playerMoving.ResetIsCatch();
    }
}
