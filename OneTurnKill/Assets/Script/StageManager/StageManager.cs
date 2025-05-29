using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0414

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    [Header("Spawner")]
    [SerializeField] GameObject spawner;
    cSpawner[] spawners;

    [Header("PlayerAttack")]
    cPlayerAttack playerAttack;
    bool isPlayerAttack;
    bool isAttackReady;

    public event Action OnOpenOrcBoss;
    //public event Action OnOpenUndeadBoss;

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
        isAttackReady = spawners[0].IsArrive;
    }

    void Spawn()
    {
        if (spawners[0].MonsterCount <= 0 && isPlayerAttack == false)
        {
            if (spawners[0].IsEnd)
                return;

            //Debug.Log("�������� : " + stageNum);
            foreach (var spawn in spawners)
                spawn.StartSpawn();

            PlayerPrefs.SetInt("stageNum", stageNum);
            spawners[0].PrefabIndex(stageNum / 10);
            stageNum++;

            CheckOpenBoss();
        }
    }

    void CheckOpenBoss()
    {
        // Need To Boss Stage
        if (stageNum >= 70)
            OnOpenOrcBoss?.Invoke();
        //else if (stageNum == 160)
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
            //Debug.Log("���� ���������� " + stageNum);
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
        instance = this;

        stageNum = PlayerPrefs.GetInt("stageNum", stageNum);
        isPlayerAttack = false;

        spawners = spawner.GetComponentsInChildren<cSpawner>();
        playerAttack = GameManager.instance.player.GetComponent<cPlayerAttack>();
    }
}
