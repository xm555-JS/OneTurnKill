using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*��ų�� �θ� Ŭ���� - ��ų�� �������� ������ protected �����ڷ� �ڽĵ��� �̿��� �� �ֵ���,
  ������ �ʿ��� ����� ������ �� �ֵ��� �߻��Լ��� �����Ͽ� �ڽĵ��� ������ ����� �����ϵ���*/

public abstract class cPlayerSkill
{
    protected cPlayer player;
    protected Animator anim;
    protected Transform transform;

    public void SetPlayer(cPlayer PlayerObj) { player = PlayerObj; }
    public void SetAnim(Animator playerAnim) { anim = playerAnim; }
    public void SetTransform(Transform playerTransform) { transform = playerTransform; }

    protected abstract void PlayAnimation(SkillData skillData);
    protected abstract void PlayEffect(SkillData skillData);
    protected abstract void PlaySound(SkillData skillData);
}
