using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*스킬의 부모 클래스 - 스킬의 공통적인 정보는 protected 접근자로 자식들이 이용할 수 있도록,
  무조건 필요한 기능을 구현할 수 있도록 추상함수로 구현하여 자식들이 무조건 기능을 구현하도록*/

public abstract class cPlayerSkill
{
    protected Animator anim;
    protected Transform transform;

    public void SetAnim(Animator playerAnim) { anim = playerAnim; }
    public void SetTransform(Transform playerTransform) { transform = playerTransform; }

    protected abstract void PlayAnimation(SkillData skillData);
    protected abstract void PlayEffect(SkillData skillData);
    protected abstract void PlaySound(SkillData skillData);
}
