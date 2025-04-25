using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSkill3State : IState
{
    // 보스가 타겟을 고정시킨다.
    // 타겟이 고정되었다면 보스는 공격 준비를하고
    // 플레이어에게 타켓 ui가 나타난다.
    // 이 때 보스는 플레이어의 왼쪽 오른쪽을 구분하여 filpX를 시켜준다.

    // 몇 초 뒤 보스는 검기 공격을 한다.
    // 플레이어는 보스에게 최대한 멀리 떨어져 자신에게 빠르게 다가오는 검기를 피해야한다.

    // target하는 객체를 하나 만드는데
    // 일정 시간이 되면 bool값을 return을 하는 형태로 일단 생각해보자
    // 그 뒤 boss에서 target객체를 참조하도록 하고
    // target객체의 bool값이 true가 된다면
    // 그 position으로 이펙트를 날라가게한다.
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
        particleMain.startRotationZ = Mathf.Deg2Rad * angle;

        //boss.StateMachine.TransitionTo(boss.StateMachine.groggyState);
    }
}
