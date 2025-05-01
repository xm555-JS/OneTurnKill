using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkill3State : IState
{
    cBoss boss;
    GameObject bossBullet;


    public cSkill3State(cBoss boss) { this.boss = boss; }
    
    public void Enter()
    {
        bossBullet = boss.bossBullet;
        boss.StartCoroutine(ReadyAttack());
    }

    IEnumerator ReadyAttack()
    {
        boss.targetUI.gameObject.SetActive(true);

        yield return new WaitUntil(() => boss.targetUI.IsReady);

        // 발사
        GameObject bullet = GameObject.Instantiate(bossBullet);
        Vector3 bulletPos = boss.transform.position;
        bullet.transform.localScale = new Vector3(3f, 3f, 3f);
        bullet.transform.position = new Vector3(bulletPos.x, bulletPos.y, bulletPos.z);

        // 회전
        Vector2 dirToPlayer = GameManager.instance.player.transform.position - boss.transform.position;
        float angle = Mathf.Atan2(dirToPlayer.y, dirToPlayer.x) * Mathf.Rad2Deg;

        bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        ParticleSystem bulletParticle = bullet.GetComponentInChildren<ParticleSystem>();
        var particleMain = bulletParticle.main;
        particleMain.startRotation3D = true;
        particleMain.startRotationZ = -(Mathf.Deg2Rad * angle);

        if (boss.isDead == false)
            boss.StateMachine.TransitionTo(boss.StateMachine.groggyState);
    }
}
