using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cStoryScene : MonoBehaviour
{
    [SerializeField] Sprite[] SceneSprites;
    [SerializeField] cDialog dialog;
    [SerializeField] cStoryPanel panel;

    Image sceneImg;
    Color color;

    int sceneIndex;
    float time;
    float sceneTime = 2f;
    float alpha = 1f;
    bool isEnd;
    bool isDialog;
    void Awake()
    {
        bool isStoryEnd = System.Convert.ToBoolean(PlayerPrefs.GetInt("StoryEnd", 0));
        if (isStoryEnd)
            LevelManager.instance.GoToCustomLevel();

        sceneImg = GetComponent<Image>();
        color = sceneImg.color;
    }

    void Update()
    {
        if (!isEnd)
        {
            sceneImg.sprite = SceneSprites[sceneIndex];
            bool isFinish = StoryCondition(sceneIndex);
            if (isFinish)
            {
                sceneIndex++;
                if (SceneSprites.Length < sceneIndex)
                    isEnd = true;
            }
        }
        else
        {
            alpha -= Time.deltaTime;
            color.a = alpha;
            sceneImg.color = color;

            if (alpha <= 0f)
            {
                color.a = 0f;
                sceneImg.color = color;

                PlayerPrefs.SetInt("StoryEnd", 1);
                sceneImg.gameObject.SetActive(false);
            }
        }
    }

    bool StoryCondition(int index)
    {
        switch (index)
        {
            case 0:
                time += Time.deltaTime;
                if (time >= sceneTime)
                {
                    panel.whiteOut();
                    time = 0;
                    return panel.isFinish;
                }
                panel.SetBlack();
                break;
            case 1:
                panel.ReturnPanel();
                if (!panel.isFinish)
                {
                    dialog.SetDialog("여신", "오셨군요! \n 스킬을 드릴께요");
                    if (dialog.IsFinish)
                        return true;
                }
                break;
            case 2:
                dialog.SetDialog("여신", "어라라... 스킬이.. \n 이건가.. 아! 찾았다 이게 맞겠지? \n 그럼 이세계로 전송 시켜드릴꼐요!");
                if (dialog.IsFinish)
                    return true;
                break;
            case 3:
                dialog.SetDialog("여신", "엇? 이 스킬은..");
                if (dialog.IsFinish)
                {
                    panel.BlackOut();
                    return true;
                }
                break;
            default :
                return false;
        }
        return false;
    }
}
