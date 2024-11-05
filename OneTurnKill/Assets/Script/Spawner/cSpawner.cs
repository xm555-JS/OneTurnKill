using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSpawner : MonoBehaviour
{
    [SerializeField] GameObject monster;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            StartSpawn();
    }

    public void StartSpawn()
    {
        // 몬스터 스폰
        Instantiate(monster, this.transform.position, this.transform.rotation, this.transform);
        GameObject mon1 = Instantiate(monster, this.transform.position, this.transform.rotation, this.transform);
        mon1.transform.position -= new Vector3(-1.5f, 0, 0);
        GameObject mon2 = Instantiate(monster, this.transform.position, this.transform.rotation, this.transform);
        mon2.transform.position -= new Vector3(1.5f, 0, 0);
    }
}
