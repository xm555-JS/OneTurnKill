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
    // test
    ObjectPool objPool;

    public int MonsterCount { get => monsterCount; }
    //public void SetMonsterCount(int value) { monsterCount = value; }
    public bool IsArrive { get => isArrive; }
    public void PrefabIndex(int prefabIndex) { monsterIndex = prefabIndex; }

    void Awake()
    {
        monsterCount = 0;
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
        //test
        if (monsterIndex != preMonsterIndex)
        {
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

        // test
        monster.OnDead += CheckMonsterDead;
        monsterList.Add(monster);

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
        monsterCount = 0;
    }

    void CheckMonsterDead()
    {
        monsterCount--;

        foreach (var mon in monsterList)
            mon.OnDead -= CheckMonsterDead;
    }
}
