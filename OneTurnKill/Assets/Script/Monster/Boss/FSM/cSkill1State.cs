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
        spawnerTrans = boss.spawnerTrans;
        bossBullet = boss.bossBullet;
        attackCoroutine = boss.StartCoroutine(StartFire());
    }

    public void Exit()
    {
        if (attackCoroutine != null)
            boss.StopCoroutine(attackCoroutine);
    }

    GameObject InstanteBullet()
    {
        GameObject bullet = GameObject.Instantiate(bossBullet);
        Vector3 bulletPos = spawnerTrans.position;
        bullet.transform.localScale = new Vector3(2f, 2f, 2f);
        bullet.transform.position = new Vector3(bulletPos.x, bulletPos.y, bulletPos.z);

        return bullet;
    }

    void RotateBullet(float angle, GameObject bullet)
    {
        // °´Ã¼ È¸Àü
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, -angle);

        // ÀÌÆÑÆ® È¸Àü
        ParticleSystem bulletParticle = bullet.GetComponentInChildren<ParticleSystem>();
        var particleMain = bulletParticle.main;
        particleMain.startRotation3D = true;
        particleMain.startRotationZ = Mathf.Deg2Rad * angle;
    }

    IEnumerator StartFire()
    {
        int fireCount = 0;
        float angle = 0f;

        while (fireCount <= 36)
        {
            if (boss.StateMachine == null)
                break;

            GameObject bullet = InstanteBullet();

            angle = fireCount * 10f;
            RotateBullet(angle, bullet);

            fireCount++;
            yield return new WaitForSeconds(0.2f);
        }

        boss.StateMachine.TransitionTo(boss.StateMachine.skill2State);
    }
}
