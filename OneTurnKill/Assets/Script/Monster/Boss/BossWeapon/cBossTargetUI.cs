using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cBossTargetUI : MonoBehaviour
{
    Camera cam;
    RectTransform rectTrasform;

    Image targetImg;
    Color objectColor;

    float speed = 800f;

    float targetTime = 0f;
    float duration = 3f;

    bool isReady = false;

    public bool IsReady { get => isReady; }

    void Awake()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        rectTrasform = GetComponent<RectTransform>();

        targetImg = GetComponent<Image>();
        objectColor = GetComponent<Image>().color;
    }

    void Update()
    {
        if (isReady == false)
        {
            // 시간
            targetTime += Time.deltaTime;
            if (targetTime >= duration)
            {
                objectColor = Color.red;
                StartCoroutine(ResetTargetUI());
                isReady = true;
            }

            // 플레이어 쫒아다니도록
            Vector3 playerScreenPos = cam.WorldToScreenPoint(GameManager.instance.player.transform.position);
            playerScreenPos = new Vector3(playerScreenPos.x, playerScreenPos.y + 0.5f, playerScreenPos.z);
            this.rectTrasform.position = Vector3.MoveTowards(this.rectTrasform.position, playerScreenPos, Time.deltaTime * speed);
        }
    }

    IEnumerator ResetTargetUI()
    {
        yield return new WaitForSeconds(0.5f);

        while (objectColor.a > 0f)
        {
            objectColor.a -= Time.deltaTime;
            targetImg.color = objectColor;

            yield return null;
        }

        this.gameObject.SetActive(false);

        objectColor.a = 1f;
        targetImg.color = objectColor;
        isReady = false;

        this.rectTrasform.position = Vector3.zero;
    }
}
