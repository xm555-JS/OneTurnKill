using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cStoryScene : MonoBehaviour
{
    [Header ("Scene__Sprite")]
    [SerializeField] Sprite[] SceneSprites;

    [Header ("UI")]
    [SerializeField] cDialog dialog;
    [SerializeField] cStoryPanel panel;
    [SerializeField] GameObject nextLevelBtn;

    Image sceneImg;

    int sceneIndex;
    float alpha = 1f;

    void Start()
    {
        bool isStoryEnd = System.Convert.ToBoolean(PlayerPrefs.GetInt("StoryEnd", 0));
        if (isStoryEnd)
            LevelManager.instance.GoToCustomLevel();

        sceneImg = GetComponent<Image>();

        StartCoroutine(StartStory());
    }
    IEnumerator StartStory()
    {
        sceneImg.sprite = SceneSprites[sceneIndex];

        yield return new WaitForSeconds(1f);

        // 트럭 씬
        bool isTruckSceneFinish = panel.ReturnPanel();
        yield return new WaitUntil(() => panel.isFinish == true);

        AudioManager.instance.PlayerSfx(AudioManager.Sfx.TRUCK);

        yield return new WaitForSeconds(2f);

        AudioManager.instance.PlayerSfx(AudioManager.Sfx.ACCIDENT);

        // 여신 환영 씬
        bool isWelecomSceneWhiteOutFinish = panel.whiteOut();
        yield return new WaitUntil(() => panel.isFinish == true);

        yield return new WaitForSeconds(3f);

        AudioManager.instance.PlayBgm(AudioManager.Bgm.STORY);

        panel.SetBlack();
        sceneIndex++;
        sceneImg.sprite = SceneSprites[sceneIndex];

        bool isWelecomSceneFinish = panel.ReturnPanel();
        yield return new WaitUntil(() => panel.isFinish == true);

        yield return new WaitForSeconds(0.5f);
        dialog.SetDialog("여신", "오셨군요! \n스킬을 드릴께요");


        // 여신 스킬 찾는 씬
        yield return new WaitUntil(() => dialog.IsFinish == true);
        sceneIndex++;
        sceneImg.sprite = SceneSprites[sceneIndex];

        yield return new WaitForSeconds(0.5f);
        dialog.SetDialog("여신", "어라라... 스킬이.. \n이건가.. 아! 찾았다 이게 맞겠지? \n 그럼 이세계로 전송 시켜드릴꼐요!");


        // 여신 급하게 붙잡는 씬
        yield return new WaitUntil(() => dialog.IsFinish == true);
        sceneIndex++;
        sceneImg.sprite = SceneSprites[sceneIndex];

        yield return new WaitForSeconds(0.5f);
        dialog.SetDialog("여신", "엇? 이 스킬은..");

        yield return new WaitUntil(() => dialog.IsFinish == true);

        bool isCatchSceneFinish = panel.BlackOut();
        yield return new WaitUntil(() => panel.isFinish == true);

        yield return new WaitForSeconds(2f);

        dialog.SetDialog("주인공", "..? \n일단 스킬을 확인해 볼까?");

        yield return new WaitUntil(() => dialog.IsFinish == true);

        // StoryScene 사라짐
        sceneImg.color = new Color(0f, 0f, 0f, 1f);
        panel.gameObject.SetActive(false);
        dialog.gameObject.SetActive(false);

        yield return null;

        Color color = sceneImg.color;
        while (color.a > 0f)
        {
            alpha -= Time.deltaTime;
            color.a = alpha;
            sceneImg.color = color;

            yield return null;
        }
        
        color.a = 0f;
        sceneImg.color = color;

        // 엉뚱한 스킬 받는 씬
        yield return new WaitForSeconds(1f);
        dialog.gameObject.SetActive(true);
        dialog.SetDialog("주인공", "???");
        nextLevelBtn.SetActive(true);
        sceneImg.gameObject.SetActive(false);
    }
}
