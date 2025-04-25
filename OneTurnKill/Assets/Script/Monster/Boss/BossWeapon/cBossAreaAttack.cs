using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cBossAreaAttack : MonoBehaviour
{
    // attack ��ũ��Ʈ���� �ڱ� �ڽ��� alpha���� Ư�� ������ �÷��ְ�
    // Ư�� ���� ���������� ���� ����Ʈ�� �������Ѵ�.
    // �� �� tag�� ���� �ٸ��� �Ѵ�. ex) Tag - attackReady -> attack

    enum POSITION { TOP, BOTTOM, RIGHT, LEFT }

    [SerializeField] GameObject horizonEffect;
    [SerializeField] GameObject verticalEffect;
    [SerializeField] POSITION effectPosition;

    Color areaColor;

    bool isStart;

    public void AttackStart() { isStart = true; }

    void Awake()
    {
        areaColor = GetComponent<SpriteRenderer>().color;
        areaColor.a = 0f;
        isStart = false;
    }

    void Update()
    {
        if (isStart)
        {
            if (areaColor.a >= 0.4f)
            {
                areaColor.a = 0.4f;
                GetComponent<SpriteRenderer>().color = areaColor;
                StartCoroutine(Attack());
                isStart = false;
            }
            else
            {
                areaColor.a += Time.deltaTime;
                GetComponent<SpriteRenderer>().color = areaColor;
            }
        }
    }

    IEnumerator Attack()
    {
        switch (effectPosition)
        {
            case POSITION.TOP:
                GameObject topEffect = Instantiate(horizonEffect);
                topEffect.transform.position = new Vector2(0f, 3.4f);
                break;

            case POSITION.BOTTOM:
                GameObject bottomEffect = Instantiate(horizonEffect);
                bottomEffect.transform.position = new Vector2(0f, -3.4f);
                break;

            case POSITION.RIGHT:
                GameObject rightEffect = Instantiate(verticalEffect);
                rightEffect.transform.position = new Vector2(9f, 0f);
                break;

            case POSITION.LEFT:
                GameObject leftEffect = Instantiate(verticalEffect);
                leftEffect.transform.position = new Vector2(-9f, 0f);
                break;
        }

        this.tag = "MonsterSkill";

        yield return new WaitForSeconds(1f);

        while (areaColor.a > 0f)
        {
            areaColor.a -= Time.deltaTime;
            GetComponent<SpriteRenderer>().color = areaColor;
            yield return null;
        }

        areaColor.a = 0f;
        GetComponent<SpriteRenderer>().color = areaColor;
        this.tag = "MonsterSkill_idle";
    }
}
