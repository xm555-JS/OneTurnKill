using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] cMonster owner;
    [SerializeField] bool isBoss;
    
    float maxHP;
    float currentHP;
    float targetHP;
    float changeHpRate;

    float speed = 5000f;

    Camera cam;
    Vector2 hpBarPosY = new Vector2(0, 60);

    void Start()
    {
        if (isBoss == false)
        {
            cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
            if (cam == null)
                return;
        }
    }

    void Update()
    {
        if (isBoss == false)
        {
            if (!owner)
            {
                Destroy(this.gameObject);
                return;
            }

            Vector2 pos = cam.WorldToScreenPoint(owner.transform.position);
            this.transform.position = pos + hpBarPosY;
        }
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
            currentHP = Mathf.MoveTowards(currentHP, targetHP, Time.deltaTime * speed);
            changeHpRate = currentHP / maxHP;
            slider.value = changeHpRate;

            yield return null;
        }

        if (Mathf.Approximately(targetHP, 0f))
            slider.value = 0f;
    }
}