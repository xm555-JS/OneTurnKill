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
            boss.StopCoroutine(attackCoroutine);
    }

    GameObject InstanteBullet()
    {
        GameObject bullet = GameObject.Instantiate(bossBullet);
        Vector3 bulletPos = spawnerTrans.position;
        bullet.transform.localScale = new Vector3(2f, 2f, 2f);
        bullet.transform.position = new Vector3(bulletPos.x, bulletPos.y + 2f, bulletPos.z);
        Debug.Log("�Ѿ� ����");
        return bullet;
    }

    void RotateBullet(float angle, GameObject bullet)
    {
        // �����ʸ� ȸ����Ų��.
        spawnerTrans.rotation = Quaternion.Euler(0f, 0f, angle);
        // ���� ��ƼŬ�� rotation�̶� ��ƼŬ ��ü�� rotation�� ���ƾ��Ѵ�.
        // angle�� �������� �ٲ� ���� �״�� ��ü�� ���������� ����� �����Ͽ���
        // rotation�� ����  Mathf.Rad2Deg��
        float testAngle = Mathf.Deg2Rad * angle - 90f;
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Rad2Deg * testAngle);
        ParticleSystem test = bullet.GetComponent<ParticleSystem>();
        var mainTest = test.main;
        mainTest.startRotation = Mathf.Deg2Rad * angle - 90f;
        Debug.Log(angle + "��ŭ ȸ��");
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
            yield return new WaitForSeconds(2f);
        }

        boss.StateMachine.TransitionTo(boss.StateMachine.skill2State);
    }
}
