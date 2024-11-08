using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0414

public class cSpawner : MonoBehaviour
{
    [SerializeField] GameObject monsterPrefab;

    static List<cMonster> monsterList = new List<cMonster>();

    static int monsterCount = 0;
    static bool isArrive;

    public int MonsterCount { get => monsterCount; }
    public bool IsArrive { get => isArrive; }

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
        if (monsterList.Count >= 6)
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

    public void StartSpawn()
    {
        // 몬스터 스폰
        GameObject monsterObj = Instantiate(monsterPrefab, this.transform.position, this.transform.rotation, this.transform);

        // 몬스터 이벤트 구독
        cMonster monster = monsterObj.GetComponent<cMonster>();
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

        Destroy(monster.gameObject);

        // 몬스터 count 초기화
        monsterCount = 0;
    }

    void CheckMonsterDead()
    {
        monsterCount--;
        Debug.Log(monsterCount);
    }
}
