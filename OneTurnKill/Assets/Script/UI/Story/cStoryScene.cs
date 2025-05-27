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

        // Ʈ�� ��
        bool isTruckSceneFinish = panel.ReturnPanel();
        yield return new WaitUntil(() => panel.isFinish == true);

        AudioManager.instance.PlayerSfx(AudioManager.Sfx.TRUCK);

        yield return new WaitForSeconds(2f);

        AudioManager.instance.PlayerSfx(AudioManager.Sfx.ACCIDENT);

        // ���� ȯ�� ��
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
        dialog.SetDialog("����", "���̱���! \n��ų�� �帱����");


        // ���� ��ų ã�� ��
        yield return new WaitUntil(() => dialog.IsFinish == true);
        sceneIndex++;
        sceneImg.sprite = SceneSprites[sceneIndex];

        yield return new WaitForSeconds(0.5f);
        dialog.SetDialog("����", "����... ��ų��.. \n�̰ǰ�.. ��! ã�Ҵ� �̰� �°���? \n �׷� �̼���� ���� ���ѵ帱����!");


        // ���� ���ϰ� ����� ��
        yield return new WaitUntil(() => dialog.IsFinish == true);
        sceneIndex++;
        sceneImg.sprite = SceneSprites[sceneIndex];

        yield return new WaitForSeconds(0.5f);
        dialog.SetDialog("����", "��? �� ��ų��..");

        yield return new WaitUntil(() => dialog.IsFinish == true);

        bool isCatchSceneFinish = panel.BlackOut();
        yield return new WaitUntil(() => panel.isFinish == true);

        yield return new WaitForSeconds(2f);

        dialog.SetDialog("���ΰ�", "..? \n�ϴ� ��ų�� Ȯ���� ����?");

        yield return new WaitUntil(() => dialog.IsFinish == true);

        // StoryScene �����
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

        // ������ ��ų �޴� ��
        yield return new WaitForSeconds(1f);
        dialog.gameObject.SetActive(true);
        dialog.SetDialog("���ΰ�", "???");
        nextLevelBtn.SetActive(true);
        sceneImg.gameObject.SetActive(false);
    }
}
