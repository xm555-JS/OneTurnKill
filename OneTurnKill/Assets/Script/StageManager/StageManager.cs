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

    WaitForSeconds checkDeadTime = new WaitForSeconds(2f);

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

    void OnDisable()
    {
        playerAttack.OnAttack -= CheckPlayerAttack;
    }

    void Update()
    {
        Spawn();
        isAttackReady = spawners[0].IsArrive;   // 모든 몬스터가 목적기에 도착했는지 확인
    }

    void Spawn()
    {
        if (spawners[0].MonsterCount <= 0 && isPlayerAttack == false)
        {
            foreach (var spawn in spawners)
                spawn.StartSpawn(stageNum);

            stageNum++;
            spawners[0].PrefabIndex(stageNum / 10);
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
        yield return checkDeadTime;

        if (spawners[0].MonsterCount > 0)
        {
            // 공격했을 때 몬스터가 남아있다면 해당 스테이지 다시 시작
            foreach (var spawn in spawners)
                spawn.ClearMonster();
            
            stageNum--;
            Debug.Log("현재 스테이지는 " + stageNum);
            isPlayerAttack = false;
        }
        else
        {
            // 모든 몬스터가 죽었다면 공격이 끝나고 다음 스테이지로
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
