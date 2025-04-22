using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkill1State : IState
{
    cBoss boss;
    Transform spawnerTrans;
    GameObject bossBullet;
    Coroutine attackCoroutine;

    public cSkill1State(cBoss boss) { this.boss = boss; }


    public void Enter()
    {
        Debug.Log("Skill1 Enter");
        spawnerTrans = boss.spawnerTrans;
        bossBullet = boss.bossBullet;
        attackCoroutine = boss.StartCoroutine(StartFire());
    }

    public void Update()
    {
        Debug.Log("Skill1 Update");
    }

    public void Exit()
    {
        Debug.Log("Skill1 Exit");
        if (attackCoroutine != null)
        {
            boss.StopCoroutine(attackCoroutine);
            boss.StateMachine.TransitionTo(boss.StateMachine.skill2State);
        }
    }

    GameObject InstanteBullet()
    {
        GameObject bullet = GameObject.Instantiate(bossBullet);
        Vector3 bulletPos = spawnerTrans.position;
        bullet.transform.localScale = new Vector3(2f, 2f, 2f);
        bullet.transform.position = new Vector3(bulletPos.x, bulletPos.y, bulletPos.z);

        Debug.Log("총알 생성");
        return bullet;
    }

    void RotateBullet(float angle, GameObject bullet)
    {
        // 객체 회전
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, -angle);

        // 이팩트 회전
        ParticleSystem test = bullet.GetComponentInChildren<ParticleSystem>();
        var mainTest = test.main;
        mainTest.startRotation3D = true;
        mainTest.startRotationZ = Mathf.Deg2Rad * angle;
        Debug.Log(angle + "만큼 회전");
    }

    IEnumerator StartFire()
    {
        int fireCount = 0;
        float angle = 0f;

        while (fireCount <= 36)
        {
            GameObject bullet = InstanteBullet();

            angle = fireCount * 10f;
            RotateBullet(angle, bullet);

            fireCount++;
            yield return new WaitForSeconds(0.2f);
        }

        boss.StateMachine.TransitionTo(boss.StateMachine.skill2State);
    }
}
