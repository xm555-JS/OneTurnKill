using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0414

public class cSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] monsterPrefabs;

    static List<cMonster> monsterList = new List<cMonster>();

    static int monsterCount = 0;
    static bool isArrive;

    // test
    ObjectPool objPool;

    public int MonsterCount { get => monsterCount; }
    public bool IsArrive { get => isArrive; }

    void Start()
    {
        objPool = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
    }

    void OnDisable()
    {
        foreach (var monster in monsterList)
            monster.OnDead -= CheckMonsterDead;

        monsterList.Clear();
    }

    void Update()
    {
        ISArriveMonster();
    }

    bool ISArriveMonster()
    {
        int numOfMonster = 6;
        if (monsterList.Count >= numOfMonster)
        {
            bool isMonsterArrive = false;
            foreach (var monster in monsterList)
            {
                isMonsterArrive = monster.IsArrive;

                if (!isMonsterArrive)
                    return isArrive = false;
            }
            return isArrive = true;
        }
        return false;
    }

    public void StartSpawn(int stageNum)
    {
        // ���� ����
        //GameObject monsterObj = Instantiate(monsterPrefabs[stageNum], this.transform.position, this.transform.rotation, this.transform);

        // ���� �̺�Ʈ ����
        //cMonster monster = monsterObj.GetComponent<cMonster>();

        //test
        GameObject monsterObj = objPool.Spawn();
        cMonster monster = monsterObj.GetComponent<cMonster>();
        monster.transform.SetParent(this.transform);
        monster.transform.position = this.transform.position;
        // test

        monster.OnDead += CheckMonsterDead;
        monsterList.Add(monster);

        monsterCount++;
        Debug.Log(monsterCount);
    }

    public void ResetMonster()
    {
        cMonster monster = GetComponentInChildren<cMonster>();
        if (!monster)
        {
            Debug.LogError("monster is null");
            return;
        }

        //Destroy(monster.gameObject);

        foreach (var mon in monsterList)
            mon.OnDead -= CheckMonsterDead;

        // test
        objPool.Release(monster.gameObject);

        // ���� count �ʱ�ȭ
        monsterCount = 0;
    }

    void CheckMonsterDead()
    {
        monsterCount--;
        Debug.Log(monsterCount);

        foreach (var mon in monsterList)
            mon.OnDead -= CheckMonsterDead;
    }
}
