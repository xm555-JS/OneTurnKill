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
    static int monsterIndex = 0;
    static int preMonsterIndex = 0;
    static bool isEnd;

    ObjectPool objPool;

    public bool IsEnd { get => isEnd; }
    public int MonsterCount { get => monsterCount; }
    public bool IsArrive { get => isArrive; }
    public void PrefabIndex(int prefabIndex)
    {
        monsterIndex = prefabIndex;
        PlayerPrefs.SetInt("monsterIndex", monsterIndex);
    }

    void Awake()
    {
        monsterCount = 0;
        monsterIndex = PlayerPrefs.GetInt("monsterIndex", monsterIndex);
    }

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

    void ISArriveMonster()
    {
        int numOfMonster = 6;
        if (monsterList.Count >= numOfMonster)
        {
            foreach (var monster in monsterList)
            {
                if (!monster.IsArrive)
                {
                    isArrive = false;
                    return;
                }
            }
            isArrive = true;
        }
    }

    public void StartSpawn()
    {
        if (monsterIndex != preMonsterIndex)
        {
            if (monsterIndex >= monsterPrefabs.Length)
            {
                isEnd = true;
                return;
            }
            if (monsterPrefabs[monsterIndex] == null)
                return;

            objPool.ChangeObjectPool(monsterPrefabs[monsterIndex]);
            preMonsterIndex = monsterIndex;
        }
        
        GameObject monsterObj = objPool.Spawn();
        cMonster monster = monsterObj.GetComponent<cMonster>();
        monster.transform.SetParent(this.transform);
        monster.transform.position = this.transform.position;
        if (this.gameObject.name == "Left_Top")
            monster.transform.localScale = new Vector3(-2f, 2f, 2f);
        else if (this.gameObject.name == "Left_Bottom")
            monster.transform.localScale = new Vector3(-2f, 2f, 2f);
        else
            monster.transform.localScale = new Vector3(2f, 2f, 2f);

        monster.OnDead += CheckMonsterDead;
        monsterList.Add(monster);
        //Debug.Log(monsterCount);
        monsterCount++;
    }

    public void ClearMonster()
    {
        cMonster monster = GetComponentInChildren<cMonster>();
        if (!monster)
        {
            Debug.LogError("monster is null");
            return;
        }
        objPool.Release(monster.gameObject);

        // 몬스터 count 초기화
        monster.OnDead -= CheckMonsterDead;
        monsterCount = 0;
        monsterList.Clear();
    }

    void CheckMonsterDead()
    {
        monsterCount--;
        //Debug.Log(monsterCount);

        foreach (var mon in monsterList)
            mon.OnDead -= CheckMonsterDead;

        if (monsterCount <= 0)
            monsterList.Clear();
    }
}
