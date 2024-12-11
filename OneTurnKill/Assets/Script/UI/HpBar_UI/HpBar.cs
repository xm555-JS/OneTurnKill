using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] Slider slider;

    cMonster owner;
    float maxHP;
    float currentHP;
    float targetHP;
    float changeHpRate;

    Camera cam;
    Vector2 hpBarPosY = new Vector2(0,30);

    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        if (!owner)
        {
            Destroy(this.gameObject);
            //Debug.LogError("HPBar - owner is null");
            return;
        }

        Vector2 pos = cam.WorldToScreenPoint(owner.transform.position);
        this.transform.position = pos + hpBarPosY;
    }

    void OnDisable()
    {
        owner.OnDamage -= OnDamage;
    }

    public void Initialize(cMonster monster = null)
    {
        if (!owner)
        {
            owner = monster;
            owner.OnDamage += OnDamage;
        }

        maxHP = owner.MaxHP;
        targetHP = owner.CurrentHP;
        currentHP = targetHP;

        changeHpRate = targetHP / maxHP;
        slider.value = changeHpRate;
    }

    void OnDamage(object sender, float monsterHP)
    {
        targetHP = monsterHP;

        StopCoroutine(ChangeRate());
        StartCoroutine(ChangeRate());
    }

    IEnumerator ChangeRate()
    {
        while (Mathf.Abs(currentHP - targetHP) > 0.01f)
        {
            currentHP = Mathf.MoveTowards(currentHP, targetHP, Time.deltaTime * 100f);
            changeHpRate = currentHP / maxHP;
            slider.value = changeHpRate;

            yield return null;
        }

        if (Mathf.Approximately(targetHP, 0f))
            slider.value = 0f;
    }
}