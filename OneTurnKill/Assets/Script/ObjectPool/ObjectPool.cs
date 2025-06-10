using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    IObjectPool<GameObject> objectPool;
    [SerializeField] GameObject prefab;
    int defaultCapacity = 6;
    int maxSize = 12;

    void Awake()
    {
        objectPool = new ObjectPool<GameObject>(CreateObject, OnGetFromPool, OnReleaseFromPool, OnDestroyFromPool, true, defaultCapacity, maxSize);
    }

    GameObject CreateObject()
    {
        GameObject obj = Instantiate(prefab);
        cMonster monster = obj.GetComponent<cMonster>();
        monster.ObjectPool = objectPool;

        return monster.gameObject;
    }

    void OnGetFromPool(GameObject pooledMonster)
    {
        pooledMonster.SetActive(true);
    }

    void OnReleaseFromPool(GameObject pooledMonster)
    {
        Animator anim = pooledMonster.GetComponentInChildren<Animator>();
        anim.Rebind();
        anim.Update(0);
        pooledMonster.SetActive(false);
    }

    void OnDestroyFromPool(GameObject pooledMonster)
    {
        Destroy(pooledMonster);
    }

    public GameObject Spawn()
    {
        return objectPool.Get();
    }

    public void Release(GameObject mon)
    {
        objectPool.Release(mon);
    }

    public void ChangeObjectPool(GameObject monsterPrefab)
    {
        objectPool.Clear();
        prefab = monsterPrefab;
        objectPool = new ObjectPool<GameObject>(CreateObject,
                                                OnGetFromPool,
                                                OnReleaseFromPool,
                                                OnDestroyFromPool,
                                                true,
                                                defaultCapacity,
                                                maxSize);
    }
}
