using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0414

public class StageManager : MonoBehaviour
{
    [SerializeField] GameObject spawner;
    cSpawner[] spawners;

    cPlayerAttack playerAttack;
    bool isPlayerAttack;

    bool isAttackReady;

    public int stageNum { get; private set; }
    public bool IsAttackReady { get => isAttackReady; }

    void Awake()
    {
        StageInitialize();
    }

    void OnEnable()
    {
        playerAttack.OnAttack += CheckPlayerAttack;
    }

    void Update()
    {
        Spawn();
        isAttackReady = spawners[0].IsArrive;
    }

    void Spawn()
    {
        if (spawners[0].MonsterCount <= 0 && isPlayerAttack == false)
        {
            foreach (var spawn in spawners)
                spawn.StartSpawn();

            stageNum++;
            Debug.Log("현재 스테이지는 " + stageNum);
        }
    }

    void CheckPlayerAttack()
    {
        isPlayerAttack = true;

        StartCoroutine(CheckStageClear());
    }

    IEnumerator CheckStageClear()
    {
        yield return new WaitForSeconds(2f);

        if (spawners[0].MonsterCount > 0)
        {
            foreach (var spawn in spawners)
                spawn.ResetMonster();
            stageNum--;
            Debug.Log("현재 스테이지는 " + stageNum);
            isPlayerAttack = false;
        }
        else
        {
            isPlayerAttack = false;
        }
    }

    void StageInitialize()
    {
        stageNum = 0;
        isPlayerAttack = false;

        spawners = spawner.GetComponentsInChildren<cSpawner>();
        playerAttack = GameObject.FindWithTag("Player").GetComponent<cPlayerAttack>();
    }
}
