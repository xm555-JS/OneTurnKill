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
        isAttackReady = spawners[0].IsArrive;   // ��� ���Ͱ� �����⿡ �����ߴ��� Ȯ��
    }

    void Spawn()
    {
        if (spawners[0].MonsterCount <= 0 && isPlayerAttack == false)
        {
            foreach (var spawn in spawners)
                spawn.StartSpawn(stageNum);

            stageNum++;
            spawners[0].PrefabIndex(stageNum / 10);
            Debug.Log("���� ���������� " + stageNum);
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
            // �������� �� ���Ͱ� �����ִٸ� �ش� �������� �ٽ� ����
            foreach (var spawn in spawners)
                spawn.ClearMonster();
            
            stageNum--;
            Debug.Log("���� ���������� " + stageNum);
            isPlayerAttack = false;
        }
        else
        {
            // ��� ���Ͱ� �׾��ٸ� ������ ������ ���� ����������
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
